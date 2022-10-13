HRoundStartState = {}
HRoundStartState.__index = HRoundStartState
setmetatable(HRoundStartState, FSMState)

function HRoundStartState:Create(hero)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.hero = hero
    copy.id = HeroState.HRoundStartState

    return copy
end

function HRoundStartState:OnEnter()
end

function HRoundStartState:CopyState()

end

function HRoundStartState:Update()

end

function HRoundStartState:OnLeave()

end