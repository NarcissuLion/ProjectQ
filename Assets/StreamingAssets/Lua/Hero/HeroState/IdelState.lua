local FSMachine = require 'Framework.FSMachine'
IdelState = {}
IdelState.__index = IdelState
setmetatable(IdelState,  FSMachine.State)

function IdelState:Create(hero)
    local copy = {}
    setmetatable(copy, IdelState)
    copy.hero = hero
    copy.id = HeroState.IdelState
    copy:Init()
    return copy
end

function IdelState:Init()
    
end

function IdelState:OnEnter()

end

function IdelState:Dispose()

end

function IdelState:OnUpdate()

end

function IdelState:OnExit()

end