HBattleStartState = {}
HBattleStartState.__index = HBattleStartState
setmetatable(HBattleStartState, FSMState)

function HBattleStartState:Create(hero)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.hero = hero
    copy.id = HeroState.HBattleStartState

    return copy
end

function HBattleStartState:OnEnter()
end

function HBattleStartState:CopyState()

end

function HBattleStartState:Update()

end

function HBattleStartState:OnLeave()

end