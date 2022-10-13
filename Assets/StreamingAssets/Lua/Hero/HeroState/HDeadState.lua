HDeadState = {}
HDeadState.__index = HDeadState
setmetatable(HDeadState, FSMState)

function HDeadState:Create(hero)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.hero = hero
    copy.id = HeroState.HDeadState

    return copy
end

function HDeadState:OnEnter()
end

function HDeadState:CopyState()

end

function HDeadState:Update()

end

function HDeadState:OnLeave()

end