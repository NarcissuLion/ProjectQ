HBattleEndState = {}
HBattleEndState.__index = HBattleEndState
setmetatable(HBattleEndState, FSMState)

function HBattleEndState:Create(hero)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.hero = hero
    copy.id = HeroState.HBattleEndState

    return copy
end

function HBattleEndState:OnEnter()
end

function HBattleEndState:CopyState()

end

function HBattleEndState:Update()

end

function HBattleEndState:OnLeave()

end