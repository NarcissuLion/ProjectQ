RoundStartState = {}
RoundStartState.__index = RoundStartState
setmetatable(RoundStartState, FSMState)

function RoundStartState:Create(battle)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.battle = battle
    copy.id = BattleState.BattleStart

    return copy
end

function RoundStartState:OnEnter()
    self.battle.roundIndex = self.battle.roundIndex == nil and 1 or self.battle.roundIndex + 1
    print("进入第"..self.battle.roundIndex.."回合")
    -- 这个战斗的数据不能共享……
    
end

function RoundStartState:CopyState()

end

function RoundStartState:Update()

end

function RoundStartState:OnLeave()

end