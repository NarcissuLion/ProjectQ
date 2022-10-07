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
    self.battle.view:SetCharSelectOff()
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
    local charData = self.battle:GetCharData(id)
    if charData.isDead then
        self:Pass()
        return
    end

    if charData.isOwn then
        self:DoOwn(charData)
    else
        self:DoEnemy(charData)
    end
end

function RoundState:DoOwn(charData)
    --显示信息
    self.battle.ownTurn = true
    self.battle.view:SetOwnInfo(charData.uuid)
    self.battle.view:SetCharSelect(true , charData.pos , "Select")
    print("自己" .. charData.pos)
end

function RoundState:DoEnemy(charData)
    print("敌人" .. charData.pos)
    self.battle.view:SetCharSelect(false , charData.pos , "Select")
    local skillId = self:RandomEnemyAction(charData)
    if skillId ~= nil then
        print("使用技能id:" .. skillId)
        local isOwn ,pos = self:RandomAtkPos(skillId , charData.pos)
        if type(pos) == "number" then
            -- 选中对象
            self.battle.view:SetCharSelect(isOwn , pos ,"Selected" )
            local dmg = self:GetDmg(charData , skillId)
            print("选中对象".. pos)
            -- 等1s
            AsyncCall(function ()
                -- 显示伤害
                self.battle.view:ShowDamage(isOwn , pos , dmg)
                -- 扣血，刷新界面ui
                self.battle:AddCharHp(isOwn ,pos , dmg)
                self.battle.view:RefreshChar(self.battle:GetCharByPos(isOwn , pos))
                AsyncCall(function ()
                    self:Pass()
                end , 1)
            end , 1)
        else
            for index, p in ipairs(pos) do
                -- 选中对象
                self.battle.view:SetCharSelect(isOwn , p ,"Selected" )
                print("选中对象"..  p)
            end
            
            -- 等1s
            AsyncCall(function ()
                for index, p in ipairs(pos) do
                    local dmg = self:GetDmg(charData , skillId)                
                    -- 显示伤害
                    self.battle.view:ShowDamage(isOwn , p , dmg)
                    -- 扣血，刷新界面ui
                    self.battle:AddCharHp(isOwn ,p , dmg)
                    self.battle.view:RefreshChar(self.battle:GetCharByPos(isOwn , p))
                end
                AsyncCall(function ()
                    self:Pass()
                end , 1)
            end , 1)
        end
    else
        --跳过或者移动
        self:Pass()
    end
end

function RoundState:Pass()
    table.remove(self.battle.sortBattleList,1)
    self.battle.view:SetCharSelectOff()
    if self:IsGameOver() then
        self.battle:ChangeState(BattleState.BattleEnd)
        return
    end 
    print("============")
    self:DoNext()
end

function RoundState:RandomEnemyAction(charData)
    local hpIsFull = self:EnemyHpIsFull(charData)
    local skills = charData.skill
    while #skills >= 1 do
        local index = math.random(1 , #skills)
        local skillId = skills[index]
        local skillConfig = ConfigManager:GetConfig("Skill")        
        local skillConfig = skillConfig[skillId]
        if skillConfig == nil then
            printError("技能" .. skillId .. "表中缺失")
            return
        end
        -- 检查站位
        local posRight = false
        for index, pos in ipairs(skillConfig.pos) do
            if charData.pos == pos then
                posRight = true
                break
            end
        end
        if not posRight then
            table.remove(skills,index)
        else
            
            --检查治疗
            if skillConfig.typ == "cure" and skillConfig.range == "own" and hpIsFull then
                table.remove(skills,index)
            else
                if skillConfig.typ == "cure" then
                    for index, pos in ipairs(skillConfig.atkPos) do
                        local charData = self.battle:GetCharByPos(false,pos)
                        if charData ~= nil and charData.isDead == nil and not self:EnemyHpIsFull(charData) then
                            return skillId
                        end
                    end
                end
            
                --检查被攻击的位置是否有人
                for index, pos in ipairs(skillConfig.atkPos) do
                    local charData = self.battle:GetCharByPos(true,pos)
                    if charData ~= nil and charData.isDead == nil then
                        return skillId
                    end
                end

                table.remove(skills,index)
            end
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
    if skillConfig.typ == "atk" then
        local tmp = self:GetAtkPosHaveChar(skillConfig.atkPos,true)
        local posArr = {}
        for index, pos in ipairs(tmp) do
            local charData = self.battle:GetCharByPos(true , pos)
            local isDead = true
            if charData ~= nil then
                isDead = charData.isDead
            end
            if not isDead then
                table.insert(posArr , pos)
            end
        end
        if skillConfig.range == "one" then
            return true , self:GetRandomOne(posArr)
        elseif skillConfig.range == "aoe" then
            return true , posArr
        end
    elseif skillConfig.typ == "cure" then
        local tmp = self:GetAtkPosHaveChar(skillConfig.atkPos,false)
        local posArr = {}
        for index, pos in ipairs(tmp) do
            local charData = self.battle:GetCharByPos(true , pos)
            local isDead = true
            if charData ~= nil then
                isDead = charData.isDead
            end
            if not isDead then
                table.insert(posArr , pos)
            end
        end

        if skillConfig.range == "one" then
            return false , self:GetRandomOne(posArr)
        elseif skillConfig.range == "aoe" then
            return false , posArr
        elseif skillConfig.range == "own" then
            return false , selfPos
        end
    end
end

function RoundState:EnemyHpIsFull(charData)
    local maxHp = self.battle:GetCharMaxHp(charData.uid)
    return charData.hp >= maxHp
end

function RoundState:GetAtkPosHaveChar(atkPos,isOwn)
    local tmp = {}
    for _, pos in ipairs(atkPos) do
        local charData = self.battle:GetCharByPos(isOwn,pos)
        if charData ~= nil then
            table.insert(tmp , pos)
        end                
    end
    return tmp
end

function RoundState:GetRandomOne(arr)
    if #arr == 1 then
        return arr
    end

    local index = math.random(1 , #arr)
    return arr[index]
end

function RoundState:GetDmg(charData , skillId)
    local skillConfig = ConfigManager:GetConfig("Skill")    
    local skillConfig = skillConfig[skillId]
    if skillConfig == nil then
        printError("技能" .. skillId .. "表中缺失")
        return
    end
    if skillConfig.typ == "atk" then
        return -math.ceil(math.random(skillConfig.dmg[1] ,skillConfig.dmg[2] ) * 0.01 * charData.atk)
    elseif skillConfig.typ == "cure" then
        return math.random(skillConfig.dmg[1] ,skillConfig.dmg[2] )
    end
end

function RoundState:OwnUseSkill(skillIndex,targetUuid)
    local id = self.battle.sortBattleList[1]
    local charData = self.battle:GetCharData(id) 
    local skillId = charData.skill[skillIndex]
    local skillConfig = ConfigManager:GetConfig("Skill")
    local skillConfig = skillConfig[skillId]

    if skillConfig.typ == "atk" then
        if skillConfig.range == "aoe" then
            for index, p in ipairs(skillConfig.atkPos) do
                local dmg = self:GetDmg(charData , skillId)                
                self.battle.view:ShowDamage(false , p , dmg)
                self.battle:AddCharHp(false ,p , dmg)
                self.battle.view:RefreshChar(self.battle:GetCharByPos(false , p))
            end
        elseif skillConfig.range == "one" then
            local targetCharData = self.battle:GetCharData(targetUuid)            
            local dmg = self:GetDmg(charData , skillId)
            self.battle.view:ShowDamage(false , targetCharData.pos , dmg)
            self.battle:AddCharHp(false ,targetCharData.pos , dmg)
            self.battle.view:RefreshChar(self.battle:GetCharByPos(false , targetCharData.pos))
        end
        
    elseif skillConfig.typ == "cure" then
        if skillConfig.range == "aoe" then
            for index, p in ipairs(skillConfig.atkPos) do
                local dmg = self:GetDmg(charData , skillId)                
                self.battle.view:ShowDamage(true , p , dmg)
                self.battle:AddCharHp(true ,p , dmg)
                self.battle.view:RefreshChar(self.battle:GetCharByPos(true , p))
            end
        elseif skillConfig.range == "one" then
            local targetCharData = self.battle:GetCharData(targetUuid)            
            local dmg = self:GetDmg(charData , skillId)
            self.battle.view:ShowDamage(true , targetCharData.pos , dmg)
            self.battle:AddCharHp(true ,targetCharData.pos , dmg)
            self.battle.view:RefreshChar(self.battle:GetCharByPos(true , targetCharData.pos))
        elseif skillConfig.range == "own" then
            local dmg = self:GetDmg(charData , skillId)
            self.battle.view:ShowDamage(true , charData.pos , dmg)
            self.battle:AddCharHp(true ,charData.pos , dmg)
            self.battle.view:RefreshChar(self.battle:GetCharByPos(true , charData.pos))
        end
    end

    AsyncCall(function ()
        self.battle.ownTurn = false
        self.battle.view:SetOwnInfo(charData.uuid)
        self:Pass()
    end , 1)
end

function RoundState:IsGameOver()
    local ownAllDead = true
    for uuid, data in pairs(self.battle.own) do
        if data.isDead == nil then
            ownAllDead = false
        end
    end

    local enemyAllDead = true
    for uuid, data in pairs(self.battle.enemy) do
        if data.isDead == nil then
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

--待完成项：
-- 我方角色的面板刷新
-- 角色攻击时的移动判断
-- 角色移动
-- bug我方操作时可重复点击
-- 动画
