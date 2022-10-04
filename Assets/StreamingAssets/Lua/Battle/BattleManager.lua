BattleManager = {}
BattleManager.__index = BattleManager

-- 战斗状态
BattleState = {}
BattleState.BattleStart = 1
BattleState.RoundStart = 2
BattleState.Round = 3
BattleState.RoundEnd = 4
BattleState.BattleEnd = 5

function BattleManager:Create(config)
    local copy = {}
    setmetatable(copy, BattleManager)

    copy:Init(config)
    return copy
end

function BattleManager:Init(config)
    self.config = config
    self.view = BattleUI:Create()
    local battle = {}
    battle.state = BattleState.BattleStart
    self:InitState(battle)
    self.fsmManager:Start()
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