HIdelState = {}
HIdelState.__index = HIdelState
setmetatable(HIdelState, FSMState)

function HIdelState:Create(hero)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.hero = hero
    copy.id = HeroState.HIdelState

    return copy
end

function HIdelState:OnEnter()
end

function HIdelState:CopyState()

end

function HIdelState:Update()

end

function HIdelState:OnLeave()

end