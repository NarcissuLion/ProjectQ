local FSMachine = require 'Framework.FSMachine'
local Notifier = require 'Framework.Notifier'
ActorActionState = {}
ActorActionState.__index = ActorActionState
setmetatable(ActorActionState, FSMachine.State)

function ActorActionState:Create(battle)
    local copy = {}
    setmetatable(copy, ActorActionState)
    copy.battle = battle
    copy.id = BattleState.Round
    copy:Init()
    return copy
end

function ActorActionState:Init()
    
end

function ActorActionState:OnEnter(skillId , atkPos , movePos)
    self.hero = self.battle.nowActionHero
    self.skillId = skillId
    self.atkPos = atkPos
    self.movePos = movePos
    self.hero:ChangeState(HeroState.ActionState , skillId , movePos)

    -- add by lvfeng. 先按DD2的运镜来点意思
    Notifier.Dispatch("CameraFocusAction")
    self:PlaySkillEffect(skillId)
end

function ActorActionState:Dispose()

end

function ActorActionState:OnUpdate()
    for index, hero in ipairs(self.hero) do
        if hero.state ~= HeroState.IdelState or hero.state ~= HeroState.DeadState then
            return
        end
    end

    self.battle:ChangeState(BattleState.ActorEnd)    
end

function ActorActionState:OnExit()

end

function ActorActionState:PlaySkillEffect(skillId)
    if skillId == "s1" then
        local eatNum = 0
        for index, hero in ipairs(self.battle.hero) do
            if not hero.isOwn and hero ~= self.hero then
                eatNum = eatNum + 1
                hero:ChangeState("HurtState" , -hero.hp)
            end
        end

        if eatNum > 0 then
            local text = "献祭：本次伤害增加" .. eatNum *100 .."%"
            Notifier.Dispatch("ShowEffectText" , self.hero.pos , text)
        end            
        AsyncCall(function ()
            -- 选中对象
            local minPos = 8
            for index, p in ipairs(self.atkPos) do
                Notifier.Dispatch("SetHeroSelect" , p , "Selected")
                
                local dmg = self.hero:GetDmg(skillId) * (eatNum+1)
                local otherHero = self.battle:GetHeroByPos(p)
                otherHero:ChangeState("HurtState" , dmg)
                if p<minPos then
                    minPos = p
                end
            end
        end , 1)

        --刷新自己面板
        Notifier.Dispatch("SetOwnInfo" , self.battle:GetHeroData(self.battle.ownInfoUuid))
    elseif skillId == "b1" or skillId == "warrior_skill2" then
        local text = "嘲讽"
        Notifier.Dispatch("ShowEffectText" , self.hero.pos , text)
        Notifier.Dispatch("ShowBuff1" , self.hero.pos , true)
        self.hero:SetBuff("嘲讽" , 1)
    else
        -- 选中对象
        for index, p in ipairs(self.atkPos) do
            local otherHero = self.battle:GetHeroByPos(p)
            if otherHero~= nil and not otherHero.isDead then
                Notifier.Dispatch("SetHeroSelect" , p , "Selected")
            
                local dmg = self.hero:GetDmg(skillId)                
                otherHero:ChangeState("HurtState" , dmg)
            end
        end
        --动摄像机
        -- BattleManager:MoveCamera(self.hero.pos , minPos)
        --刷新自己面板
        Notifier.Dispatch("SetOwnInfo" , self.battle:GetHeroData(self.battle.ownInfoUuid))
    end
end