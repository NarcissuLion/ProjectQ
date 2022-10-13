HBeAttackedState = {}
HBeAttackedState.__index = HBeAttackedState
setmetatable(HBeAttackedState, FSMState)

function HBeAttackedState:Create(hero)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.hero = hero
    copy.id = HeroState.HBeAttackedState

    return copy
end

function HBeAttackedState:OnEnter()
end

function HBeAttackedState:CopyState()

end

function HBeAttackedState:Update()

end

function HBeAttackedState:OnLeave()

end