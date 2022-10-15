local FSMachine = require 'Framework.FSMachine'
local Notifier = require 'Framework.Notifier'
ActionState = {}
ActionState.__index = ActionState
setmetatable(ActionState, FSMachine.State)

function ActionState:Create(hero)
    local copy = {}
    setmetatable(copy, ActionState)
    copy.hero = hero
    copy.id = HeroState.ActionState
    copy:Init()
    return copy
end

function ActionState:Init()
    
end

function ActionState:OnEnter(skillId , movePos)
    local time = 0
    if movePos ~= nil and movePos ~= self.hero.pos then
        Notifier.Dispatch("MoveHero",self.hero.pos,movePos,1)
        time = 1
    end
    Notifier.Dispatch("RefreshAllHero")
    AsyncCall(function ()
        self.hero:ChangeState(HeroState.IdelState)
    end , time)
end

function ActionState:Dispose()

end

function ActionState:OnUpdate()

end

function ActionState:OnExit()

end