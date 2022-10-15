local FSMachine = require 'Framework.FSMachine'
local Notifier = require 'Framework.Notifier'
DyingState = {}
DyingState.__index = DyingState
setmetatable(DyingState, FSMachine.State)

function DyingState:Create(hero)
    local copy = {}
    setmetatable(copy, DyingState)
    copy.hero = hero
    copy.id = HeroState.DyingState
    copy:Init()
    return copy
end

function DyingState:Init()
    
end

function DyingState:OnEnter()
    self.hero.isPlayAction = true
    Notifier.Dispatch("ShowDead" , self.hero.pos)
    AsyncCall(function ()
        self.hero.isPlayAction = false
        self.hero:ChangeState(HeroState.DeadState)
    end , 1)
    
end

function DyingState:Dispose()

end

function DyingState:OnUpdate()

end

function DyingState:OnExit()

end