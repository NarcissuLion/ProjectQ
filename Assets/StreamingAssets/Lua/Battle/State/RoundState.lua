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
    if charData.isOwn then
        self:DoOwn(charData)
    else
        self:DoEnemy(charData)
    end
end

function RoundState:DoOwn(charData)
    --显示信息
    self.battle.view:SetOwnInfo(charData)
    self.battle.view:SetCharSelect(true , charData.pos , "Select")
    print("自己" .. charData.pos)
    ------
    AsyncCall(function ()
        self:Pass()
    end , 1)
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
    end
end

function RoundState:Pass()
    table.remove(self.battle.sortBattleList,1)
    self.battle.view:SetCharSelectOff()
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
        if skillConfig == nil then
            printError("技能" .. skillId .. "表中缺失")
            return
        end

        local skillConfig = skillConfig[skillId]
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
                        if charData ~= nil and not self:EnemyHpIsFull(charData) then
                            return skillId
                        end
                    end
                end
            
                --检查被攻击的位置是否有人
                for index, pos in ipairs(skillConfig.atkPos) do
                    local charData = self.battle:GetCharByPos(true,pos)
                    if charData ~= nil then
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
    if skillConfig == nil then
        printError("技能" .. skillId .. "表中缺失")
        return
    end

    local skillConfig = skillConfig[skillId]
    if skillConfig.typ == "atk" then
        local posArr = self:GetAtkPosHaveChar(skillConfig.atkPos,true)
        if skillConfig.range == "one" then
            return true , self:GetRandomOne(posArr)
        elseif skillConfig.range == "aoe" then
            return true , posArr
        end
    elseif skillConfig.typ == "cure" then
        local posArr = self:GetAtkPosHaveChar(skillConfig.atkPos,false)
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
    if skillConfig == nil then
        printError("技能" .. skillId .. "表中缺失")
        return
    end

    local skillConfig = skillConfig[skillId]
    if skillConfig.typ == "atk" then
        return -math.random(skillConfig.dmg[1] ,skillConfig.dmg[2] ) * 0.01 * charData.atk
    elseif skillConfig.typ == "cure" then
        return math.random(skillConfig.dmg[1] ,skillConfig.dmg[2] )
    end
end