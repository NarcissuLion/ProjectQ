RoundState = {}
RoundState.__index = RoundState
setmetatable(RoundState, FSMState)

function RoundState:Create(battle)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.battle = battle
    copy.id = BattleState.Round

    return copy
end

function RoundState:OnEnter()
    print("第"..self.battle.roundIndex .. "回合中...")
    self.battle.view:SetHeroSelectOff()

    for key, hero in pairs(self.battle.hero) do
        hero:ChangeState(HeroState.HIdelState)
    end

    self:DoNext()
end

function RoundState:CopyState()

end

function RoundState:Update()

end

function RoundState:OnLeave()

end

function RoundState:DoNext()
    if #self.battle.sortBattleList<=0 then
        self.battle:ChangeState(BattleState.RoundEnd)
        return
    end


    local id = self.battle.sortBattleList[1]
    local heroData = self.battle:GetHeroData(id)
    if heroData.isDead then
        self:Pass()
        return
    end

    if heroData.isOwn then
        self:DoOwn(heroData)
    else
        self:DoEnemy(heroData)
    end
end

function RoundState:DoOwn(heroData)
    --显示信息
    self.battle.ownTurn = true
    self.battle.ownUuid = heroData.uuid
    self.battle.topView:SetOwnInfo(heroData)
    self.battle.view:SetHeroSelect(heroData.pos , "Select")
    self.battle.view:SetHeroTempMove(heroData.pos)
end

function RoundState:DoEnemy(heroData)
    self.battle.view:SetHeroSelect( heroData.pos , "Select")
    local skillId = self:RandomEnemyAction(heroData)
    if skillId ~= nil then
        local atkPos = self:RandomAtkPos(skillId , heroData.pos)
        for index, p in ipairs(atkPos) do
            -- 选中对象
            self.battle.view:SetHeroSelect(p ,"Selected" )
        end
        
        -- 等1s
        AsyncCall(function ()
            local minPos = 8
            for index, p in ipairs(atkPos) do
                local dmg = self:GetDmg(heroData , skillId)                
                -- 显示伤害
                if dmg > 0 then
                    self.battle.view:ShowCure(p , dmg)
                else
                    self.battle.view:ShowDamage(p , dmg)
                end
                -- 扣血，刷新界面ui
                self.battle:AddHeroHp(p , dmg)
                self.battle.view:RefreshHero(p)
                self.battle.topView:SetOwnInfo(self.battle:GetHeroData(self.battle.ownUuid))
                if p<minPos then
                    minPos = p
                end
            end
            BattleManager:MoveCamera(heroData.pos , minPos)
            AsyncCall(function ()
                self:Pass()
            end , 1)
        end , 1)
    else
        --跳过或者移动
        self:Pass()
    end
end

function RoundState:Pass()
    table.remove(self.battle.sortBattleList,1)
    self.battle.view:SetHeroSelectOff()
    if self:IsGameOver() then
        self.battle:ChangeState(BattleState.BattleEnd)
        return
    end 
    print("============")
    self:DoNext()
end

function RoundState:RandomEnemyAction(heroData)
    local hpIsFull = self:HpIsFull(heroData)
    local heroSkill = heroData.skill
    local skills = {}
    for index, value in ipairs(heroSkill) do
        table.insert(skills , value)
    end
    while #skills >= 1 do
        local index = math.random(1 , #skills)
        local skillId = skills[index]
        local skillConfig = ConfigManager:GetConfig("Skill")        
        skillConfig = skillConfig[skillId]
        if skillConfig == nil then
            printError("技能" .. skillId .. "表中缺失")
            return
        end
        --检查治疗
        if skillConfig.typ == "cure" and skillConfig.range == "own" and hpIsFull then
            table.remove(skills,index)
        else
            if skillConfig.range == "all" then
                return skillId
            end

            if skillConfig.typ == "cure" then
                for index, pos in ipairs(skillConfig.atkPos) do
                    local truePos = heroData.pos - pos
                    local heroData = self.battle:GetHeroByPos(truePos)
                    if heroData ~= nil and heroData.isDead == nil and not heroData.isOwn and not self:HpIsFull(heroData) then
                        return skillId
                    end
                end
            end
        
            --检查被攻击的位置是否有人
            for index, pos in ipairs(skillConfig.atkPos) do
                local truePos = heroData.pos - pos
                local heroData = self.battle:GetHeroByPos(truePos)
                if heroData ~= nil and heroData.isDead == nil and heroData.isOwn then
                    return skillId
                end
            end

            table.remove(skills,index)
        end
    end 
    return nil
end

function RoundState:RandomAtkPos(skillId,selfPos)
    local skillConfig = ConfigManager:GetConfig("Skill")    
    local skillConfig = skillConfig[skillId]
    if skillConfig == nil then
        printError("技能" .. skillId .. "表中缺失")
        return
    end

    if skillConfig.range == "own" then
        local tmp = {}
        table.insert(tmp , selfPos)
        return tmp
    elseif skillConfig.range == "all" then
        if skillConfig.typ == "atk" then
            return self.battle:GetAllOwnPos()
        elseif skillConfig.typ == "cure" then
            return self.battle:GetAllEnemyPos()
        end
    elseif skillConfig.range == "aoe" or skillConfig.range == "one" then
        local trueAtkPos = {}
        for index, pos in ipairs(skillConfig.atkPos) do
            local truePos = selfPos - pos
            if truePos >= 1 and truePos <= 10 then
                table.insert(trueAtkPos , truePos)
            end
        end
        local posArr = {}
        for index, pos in ipairs(trueAtkPos) do
            local heroData = self.battle:GetHeroByPos(pos)
            if heroData ~= nil and heroData.isDead == nil then
                table.insert(posArr , pos)
            end
        end

        if skillConfig.range == "aoe" then
            return posArr
        else
            return self:GetRandomOne(posArr)
        end
    end
end

function RoundState:HpIsFull(heroData)
    local maxHp = self.battle:GetHeroMaxHp(heroData.uid)
    return heroData.hp >= maxHp
end

function RoundState:GetAtkPosHaveHero(atkPos)
    local tmp = {}
    for _, pos in ipairs(atkPos) do
        local heroData = self.battle:GetHeroByPos(pos)
        if heroData ~= nil then
            table.insert(tmp , pos)
        end                
    end
    return tmp
end

function RoundState:GetRandomOne(arr)
    if #arr == 1 then
        return arr
    end
    local tmp = {}
    local index = math.random(1 , #arr)
    table.insert(tmp , arr[index])
    return tmp
end

function RoundState:GetDmg(heroData , skillId)
    local skillConfig = ConfigManager:GetConfig("Skill")    
    local skillConfig = skillConfig[skillId]
    if skillConfig == nil then
        printError("技能" .. skillId .. "表中缺失")
        return
    end
    if skillConfig.typ == "atk" then
        return -math.ceil(math.random(skillConfig.dmg[1] ,skillConfig.dmg[2] ) * 0.01 * heroData.atk)
    elseif skillConfig.typ == "cure" then
        return math.random(skillConfig.dmg[1] ,skillConfig.dmg[2] )
    end
end

function RoundState:OwnUseSkill(skillIndex,targetUuid)
    local function Atk(heroData , nowPos , newPos)
        local skillId = heroData.skill[skillIndex]
        local skillConfig = ConfigManager:GetConfig("Skill")
        skillConfig = skillConfig[skillId]
        if skillConfig.typ == "atk" then
            if skillConfig.range == "aoe" or skillConfig.range == "all" then
                local atkPos = self.battle:GetNowAtkPos(nowPos , newPos , skillConfig)
                for index, p in ipairs(atkPos) do
                    local dmg = self:GetDmg(heroData , skillId)                
                    self.battle.view:ShowDamage( p , dmg)
                    self.battle:AddHeroHp(p , dmg)
                    self.battle.view:RefreshHero(p)
                end
            elseif skillConfig.range == "one" then
                local targetHeroData = self.battle:GetHeroData(targetUuid)            
                local dmg = self:GetDmg(heroData , skillId)
                self.battle.view:ShowDamage(targetHeroData.pos , dmg)
                self.battle:AddHeroHp(targetHeroData.pos , dmg)
                self.battle.view:RefreshHero(targetHeroData.pos)
            end

        elseif skillConfig.typ == "cure" then
            if skillConfig.range == "aoe" or skillConfig.range == "all" then
                local atkPos = self.battle:GetNowAtkPos(nowPos , newPos , skillConfig)
                for index, p in ipairs(atkPos) do
                    local dmg = self:GetDmg(heroData , skillId)                
                    self.battle.view:ShowCure(p , dmg)
                    self.battle:AddHeroHp(p , dmg)
                    self.battle.view:RefreshHero(p)
                end
            elseif skillConfig.range == "one" then
                local targetHeroData = self.battle:GetHeroData(targetUuid)            
                local dmg = self:GetDmg(heroData , skillId)
                self.battle.view:ShowCure(targetHeroData.pos , dmg)
                self.battle:AddHeroHp(targetHeroData.pos , dmg)
                self.battle.view:RefreshHero(targetHeroData.pos)
            elseif skillConfig.range == "own" then
                local dmg = self:GetDmg(heroData , skillId)
                self.battle.view:ShowCure(heroData.pos , dmg)
                self.battle:AddHeroHp(heroData.pos , dmg)
                self.battle.view:RefreshHero(heroData.pos)
            end
        end       
    end

    self.battle.ownTurn = false
    local id = self.battle.sortBattleList[1]
    local heroData = self.battle:GetHeroData(id) 
    local nowPos = heroData.pos
    local newPos = self.battle.topView.newPos
    local skillId = heroData.skill[skillIndex]
    local skillConfig = ConfigManager:GetConfig("Skill")
    skillConfig = skillConfig[skillId]
    if skillConfig.cd ~= 0 then
        heroData.skillCD[skillIndex] = skillConfig.cd + 1
    end
    BattleManager:MoveCamera(nowPos , self.battle:GetHeroData(targetUuid).pos)
    if newPos == nil or nowPos == newPos or skillConfig.range == "own" or skillConfig.range == "all" then
        Atk(heroData , nowPos , newPos)
        self.battle.view:RefreshAllHero()
        AsyncCall(function ()
            self.battle.topView:SetOwnInfo(heroData)
            self:Pass()
        end , 1)
    else
        local nowPositon = self.battle.view.hero[heroData.pos].transform.position
        local targetPos= self.battle.view.hero[newPos].transform.position
        CommonUtil.DOMove(self.battle.view.hero[heroData.pos],nil , targetPos , 0.8)
        self.battle.view:RefreshAllHero()
        AsyncCall(function ()
            Atk(heroData, nowPos , newPos)
            self.battle.view.hero[heroData.pos].transform.position = nowPositon
            self.battle:ExchangeHero(heroData.pos , newPos)
            self.battle.view:RefreshAllHero()
            AsyncCall(function ()
                self.battle.topView:SetOwnInfo(heroData)
                self:Pass()
            end , 1)
        end , 0.8)
    end
end

function RoundState:OwnMove(moveTo)
    self.battle.ownTurn = false
    local id = self.battle.sortBattleList[1]
    local heroData = self.battle:GetHeroData(id)
    local orgPos = heroData.pos
    self.battle.view:ExchangeHero(heroData.pos , moveTo)
    self.battle:ExchangeHero(heroData.pos , moveTo)

    AsyncCall(function ()
        self.battle.view:RefreshHero(orgPos)
        self.battle.view:RefreshHero(moveTo)
        self.battle.topView:SetOwnInfo(heroData)
        self:Pass()
    end , 0.8)
end

function RoundState:IsGameOver()
    local ownAllDead = true
    local enemyAllDead = true
    for uuid, data in pairs(self.battle.hero) do
        if data.isOwn and data.isDead == nil then
            ownAllDead = false
        end
        if not data.isOwn and data.isDead == nil then
            enemyAllDead = false
        end
    end

    if ownAllDead then
        print("输了")
        return true
    end

    if enemyAllDead then
        print("赢了")
        return true
    end

    return false
end
