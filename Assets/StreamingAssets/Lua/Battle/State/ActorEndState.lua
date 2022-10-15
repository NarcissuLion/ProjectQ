local FSMachine = require 'Framework.FSMachine'
ActorEndState = {}
ActorEndState.__index = ActorEndState
setmetatable(ActorEndState, FSMachine.State)

function ActorEndState:Create(battle)
    local copy = {}
    setmetatable(copy, ActorEndState)
    copy.battle = battle
    copy.id = BattleState.Round
    copy:Init()
    return copy
end

function ActorEndState:Init()
    
end

function ActorEndState:OnEnter()
    self.hero = self.battle.nowActionHero
    self.hero:OnActionEnd()
    -- todoUpdate
    self.battle:ChangeState(BattleState.Round)
end

function ActorEndState:Dispose()

end

function ActorEndState:OnUpdate()
    if not self.hero.isPlayAction then
        self.battle:ChangeState(BattleState.Round)
    end
end

function ActorEndState:OnExit()
    
end