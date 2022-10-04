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
    self.battle:ChangeState(BattleState.RoundEnd)
end

function RoundState:CopyState()

end

function RoundState:Update()

end

function RoundState:OnLeave()

end