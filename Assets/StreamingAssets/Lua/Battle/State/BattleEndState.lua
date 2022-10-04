BattleEndState = {}
BattleEndState.__index = BattleEndState
setmetatable(BattleEndState, FSMState)

function BattleEndState:Create(battle)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.battle = battle
    copy.id = BattleState.BattleEnd

    return copy
end

function BattleEndState:OnEnter()
    print("退出战斗")
    
end

function BattleEndState:CopyState()

end

function BattleEndState:Update()

end

function BattleEndState:OnLeave()

end
