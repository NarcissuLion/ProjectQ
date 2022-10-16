local FSMachine = require 'Framework.FSMachine'
ActorAIState = {}
ActorAIState.__index = ActorAIState
setmetatable(ActorAIState, FSMachine.State)

function ActorAIState:Create(battle)
    local copy = {}
    setmetatable(copy, ActorAIState)
    copy.battle = battle
    copy.id = BattleState.Round
    copy:Init()
    return copy
end

function ActorAIState:Init()
    
end

function ActorAIState:OnEnter()
    self.hero = self.battle.nowActionHero
    AsyncCall(function ()
        self:DoAI(self.hero)
    end,2)
end

function ActorAIState:Dispose()

end

function ActorAIState:OnUpdate()

end

function ActorAIState:OnExit()

end

function ActorAIState:DoAI(heroData)
    local skillId , skillIndex = self:RandomEnemyAction(heroData)
    if skillId ~= nil then
        local skillConfig = ConfigManager:GetConfig("Skill")[skillId]
        if skillConfig.cd ~= 0 then
            self.hero.skillCD[skillIndex] = skillConfig.cd + 1
        end
        local atkPos = self:RandomAtkPos(skillId , heroData.pos)
        printJson(atkPos)
        self.battle:ChangeState(BattleState.ActorAction , skillId , atkPos)
    else
        self.battle:ChangeState(BattleState.ActorEnd)
    end
end

function ActorAIState:RandomEnemyAction(heroData)
    local hpIsFull = self.battle:HpIsFull(heroData)
    local heroSkill = heroData.skill
    local skills = {}
    for index, value in ipairs(heroSkill) do
        table.insert(skills , value)
    end
    for index, skillId in ipairs(skills) do
        local skillConfig = ConfigManager:GetConfig("Skill")
        skillConfig = skillConfig[skillId]
        if skillConfig == nil then
            printError("技能" .. skillId .. "表中缺失")
            return
        end
        if self.hero.skillCD[index] ~= 0 then
            table.remove(skills,index)
        end
        --检查治疗
        if skillConfig.typ == "cure" and skillConfig.range == "own" and hpIsFull then
            table.remove(skills,index)
        else
            if skillConfig.range == "all" then
                return skillId , index
            end

            if skillConfig.typ == "cure" then
                for index, pos in ipairs(skillConfig.atkPos) do
                    local truePos = heroData.pos - pos
                    local otherHeroData = self.battle:GetHeroByPos(truePos)
                    if otherHeroData ~= nil and not otherHeroData.isDead and
                     not otherHeroData.isOwn and not self.battle:HpIsFull(otherHeroData) then
                        return skillId , index
                    end
                end
            end
        
            --检查被攻击的位置是否有人
            for index, pos in ipairs(skillConfig.atkPos) do
                local truePos = heroData.pos - pos
                local otherHeroData = self.battle:GetHeroByPos(truePos)
                if otherHeroData ~= nil and not otherHeroData.isDead and otherHeroData.isOwn then
                    return skillId , index
                end
            end

            table.remove(skills,index)
        end
    end 
    return nil
end

function ActorAIState:RandomAtkPos(skillId,selfPos)
    local skillConfig = ConfigManager:GetConfig("Skill")[skillId]
    if skillConfig == nil then
        printError("技能" .. skillId .. "表中缺失")
        return
    end

    if skillConfig.range == "own" then
        local tmp = {}
        table.insert(tmp , selfPos)
        return tmp
    elseif skillConfig.range == "all" then
        if skillConfig.typ == "atk" or skillConfig.typ == "special" then
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
            if heroData ~= nil and not heroData.isDead then
                if heroData.typ == "cure" then
                    if not heroData.isOwn then
                        table.insert(posArr , pos)
                    end
                else
                    if heroData.isOwn then
                        table.insert(posArr , pos)
                    end
                end
            end
        end

        if skillConfig.range == "aoe" then
            return posArr
        else
            for index, pos in ipairs(posArr) do
                local hero = BattleManager:GetHeroByPos(pos)
                if hero.buff ~= nil  then
                    for index, buff in ipairs(hero.buff) do
                        buff.name = "buff1"
                        local tmp 
                        table.insert(tmp , pos)
                        return tmp
                    end
                end                
            end
            return self:GetRandomOne(posArr)
        end
    end
end

function ActorAIState:GetRandomOne(arr)
    if #arr == 1 then
        return arr
    end
    local tmp = {}
    local index = math.random(1 , #arr)
    table.insert(tmp , arr[index])
    return tmp
end