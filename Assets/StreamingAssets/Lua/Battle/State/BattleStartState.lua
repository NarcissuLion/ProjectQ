BattleStartState = {}
BattleStartState.__index = BattleStartState
setmetatable(BattleStartState, FSMState)

function BattleStartState:Create(battle)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.battle = battle
    copy.id = BattleState.BattleStart

    return copy
end

function BattleStartState:OnEnter()
    print("进入战斗")
    
end

function BattleStartState:CopyState()

end

function BattleStartState:Update()

end

function BattleStartState:OnLeave()

end
