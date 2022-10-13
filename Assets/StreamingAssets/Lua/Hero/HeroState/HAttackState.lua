HAttackState = {}
HAttackState.__index = HAttackState
setmetatable(HAttackState, FSMState)

function HAttackState:Create(hero)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.hero = hero
    copy.id = HeroState.HAttackState

    return copy
end

function HAttackState:OnEnter()
end

function HAttackState:CopyState()

end

function HAttackState:Update()

end

function HAttackState:OnLeave()

end