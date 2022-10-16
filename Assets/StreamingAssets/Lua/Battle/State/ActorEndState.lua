local FSMachine = require 'Framework.FSMachine'
local Timer = require 'Framework.Timer'
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

    -- add by lvfeng. 暂时在这里加一点时间来缓冲一下回合间节奏
    if self.delayTimer == nil then
        self.delayTimer = Timer.Create(2, 1, function()
            -- todoUpdate
            self.battle:ChangeState(BattleState.Round)
        end)
    end
    self.delayTimer:Play()
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