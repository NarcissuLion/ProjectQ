local FSMachine = require 'Framework.FSMachine'
local Notifier = require 'Framework.Notifier'
local Timer = require 'Framework.Timer'
RoundStartState = {}
RoundStartState.__index = RoundStartState
setmetatable(RoundStartState, FSMachine.State)

function RoundStartState:Create(battle)
    local copy = {}
    setmetatable(copy, RoundStartState)
    copy.battle = battle
    copy.id = BattleState.RoundStart
    copy:Init()
    return copy
end

function RoundStartState:Init()
end

--回合数、顺序入栈
function RoundStartState:OnEnter()
    self.orderHero = self.battle:OrderHero()
    self.battle.roundIndex = self.battle.roundIndex == nil and 1 or self.battle.roundIndex + 1
    print("进入第"..self.battle.roundIndex.."回合")
    Notifier.Dispatch("SetRound" , self.battle.roundIndex)
    -- todoUpdate
    for index, hero in ipairs(self.orderHero) do
        hero:OnRoundStart()
    end

    if self.timerCallback == nil then
        self.timerCallback = function()
            self.battle:ChangeState(BattleState.Round , self.orderHero)
        end
    end
    local timer = Timer.Create(1, 1, self.timerCallback)
end

function RoundStartState:Dispose()

end

function RoundStartState:OnUpdate()
    self:PlayBuff()
end

function RoundStartState:OnExit()

end

function RoundStartState:PlayBuff()
    if #self.orderHero == 0 then
        self.battle:ChangeState(BattleState.Round , self.orderHero)
        return
    end
    self.orderHero[1]:OnRoundStart()
    if self.orderHero[1].isPlayAction then
        return
    else
        table.remove(self.orderHero , 1)
    end
end