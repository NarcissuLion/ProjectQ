local FSMachine = require 'Framework.FSMachine'
local Notifier = require 'Framework.Notifier'
HurtState = {}
HurtState.__index = HurtState
setmetatable(HurtState, FSMachine.State)

function HurtState:Create(hero)
    local copy = {}
    setmetatable(copy, HurtState)
    copy.hero = hero
    copy.id = HeroState.HurtState
    copy:Init()
    return copy
end

function HurtState:Init()
    
end

function HurtState:OnEnter(dmg)
    if dmg > 0 then
        Notifier.Dispatch("ShowCure" , self.hero.pos , dmg)
    else
        Notifier.Dispatch("ShowDamage" , self.hero.pos , dmg)
    end
    self.hero:AddHeroHp(dmg)
    Notifier.Dispatch("RefreshHero" , self.hero.pos)

    AsyncCall(function ()
        self.hero:ChangeState(HeroState.IdelState)
    end , 1)
end

function HurtState:Dispose()

end

function HurtState:OnUpdate()

end

function HurtState:OnExit()

end