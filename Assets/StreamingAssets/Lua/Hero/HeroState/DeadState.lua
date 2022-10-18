local FSMachine = require 'Framework.FSMachine'
local Notifier = require 'Framework.Notifier'
DeadState = {}
DeadState.__index = DeadState
setmetatable(DeadState, FSMachine.State)

function DeadState:Create(hero)
    local copy = {}
    setmetatable(copy, DeadState)
    copy.hero = hero
    copy.id = HeroState.DeadState
    copy:Init()
    return copy
end

function DeadState:Init()
    
end

function DeadState:OnEnter()
    self.hero.isDead = true
    Notifier.Dispatch("RefreshHero" , self.hero.pos)
    Notifier.Dispatch("SetHeroVol" , self.hero.pos , 1)
end

function DeadState:Dispose()

end

function DeadState:OnUpdate()

end

function DeadState:OnExit()

end