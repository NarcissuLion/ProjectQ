local FSMachine = require 'Framework.FSMachine'
BattleEndState = {}
BattleEndState.__index = BattleEndState
setmetatable(BattleEndState, FSMachine.State)

function BattleEndState:Create(battle)
    local copy = {}
    setmetatable(copy, BattleEndState)
    copy.battle = battle
    copy.id = BattleState.BattleEnd
    copy:Init()
    return copy
end

function BattleEndState:Init()
    
end

function BattleEndState:OnEnter()
    print("退出战斗")
    self.orderHero = self.battle:OrderHero()    
    for key, hero in pairs(self.orderHero) do
        hero:OnBattleEnd()
    end
end

function BattleEndState:Dispose()

end

function BattleEndState:OnUpdate()

end

function BattleEndState:OnExit()

end
