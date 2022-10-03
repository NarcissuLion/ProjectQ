BattleManager = {}
BattleManager.__index = BattleManager

-- 战斗状态
BattleState = {}
BattleState.BattleStart = 1
BattleState.RoundStart = 2
BattleState.Round = 3
BattleState.RoundEnd = 4
BattleState.BattleEnd = 4

function BattleManager:Create(config)
    local copy = {}
    setmetatable(copy, BattleManager)

    copy:Init(config)
    return copy
end

function BattleManager:Init(config)
    local battle = {}
    battle.config = config
    battle.state = BattleState.BattleStart
    battle.view = BattleUI:Create()
    self:InitState(battle)
    self.fsmManager:Start()
    self:ChangeState(BattleState.BattleStart)
end

function BattleManager:InitState(battle)
    self.fsmManager = FSMManager.Create(battle)
    self.fsmManager:AddState(BattleStartState:Create(self))
    self.fsmManager:AddState(RoundStartState:Create(self))
    self.fsmManager:AddState(RoundState:Create(self))
    self.fsmManager:AddState(RoundEndState:Create(self))
    self.fsmManager:AddState(BattleEndState:Create(self))
end

function BattleManager:ChangeState(newState)
    self.fsmManager:ChangeState(newState)
end