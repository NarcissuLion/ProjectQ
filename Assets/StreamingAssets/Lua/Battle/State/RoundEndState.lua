local FSMachine = require 'Framework.FSMachine'
RoundEndState = {}
RoundEndState.__index = RoundEndState
setmetatable(RoundEndState, FSMachine.State)

function RoundEndState:Create(battle)
    local copy = {}
    setmetatable(copy, RoundEndState)
    copy.battle = battle
    copy.id = BattleState.RoundEnd
    copy:Init()
    return copy
end

function RoundEndState:Init()
end

function RoundEndState:OnEnter()
    self.orderHero = self.battle:OrderHero()    
    print(self.battle.roundIndex .. "回合结束")
    -- todoUpdate
    for index, hero in ipairs(self.orderHero) do
        hero:OnRoundEnd()
    end
    self.battle:ChangeState(BattleState.RoundStart)
end

function RoundEndState:Dispose()

end

function RoundEndState:OnUpdate()
    self:PlayBuff()
end

function RoundEndState:OnExit()

end

function RoundEndState:PlayBuff()
    if #self.orderHero == 0 then
        self.battle:ChangeState(BattleState.RoundStart)
        return
    end
    self.orderHero[1]:OnRoundEnd()
    if self.orderHero[1].isPlayAction then
        return
    else
        table.remove(self.orderHero , 1)
    end
end