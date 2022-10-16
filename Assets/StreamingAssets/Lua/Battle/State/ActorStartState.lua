local FSMachine = require 'Framework.FSMachine'
local Notifier = require 'Framework.Notifier'
ActorStartState = {}
ActorStartState.__index = ActorStartState
setmetatable(ActorStartState, FSMachine.State)

function ActorStartState:Create(battle)
    local copy = {}
    setmetatable(copy, ActorStartState)
    copy.battle = battle
    copy.id = BattleState.Round
    copy:Init()
    return copy
end

function ActorStartState:Init()
    
end

function ActorStartState:OnEnter()
    self.hero = self.battle.nowActionHero
    Notifier.Dispatch("SetHeroSelect" , self.hero.pos , "Select")
    Notifier.Dispatch("SetSkillSelect" )
    self.hero:OnActionStart()
    -- todoUpdate
    if self.hero.isOwn then
        -- add by lvfeng, 先按DD2的运镜来点意思
        Notifier.Dispatch("CameraFocusLeft")
        self.battle:ChangeState(BattleState.ActorInput)
    else
        -- add by lvfeng, 先按DD2的运镜来点意思
        Notifier.Dispatch("CameraFocusRight")
        self.battle:ChangeState(BattleState.ActorAI)
    end
end

function ActorStartState:Dispose()

end

function ActorStartState:OnUpdate()    
    if not self.hero.isPlayAction then
        if self.hero.isOwn then
            self.battle:ChangeState(BattleState.ActorInput)
        else
            self.battle:ChangeState(BattleState.ActorAI)
        end
    end
end

function ActorStartState:OnExit()

end