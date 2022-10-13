RoundStartState = {}
RoundStartState.__index = RoundStartState
setmetatable(RoundStartState, FSMState)

function RoundStartState:Create(battle)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.battle = battle
    copy.id = BattleState.RoundStart

    return copy
end
--回合数、顺序入栈
function RoundStartState:OnEnter()
    self.battle.roundIndex = self.battle.roundIndex == nil and 1 or self.battle.roundIndex + 1
    print("进入第"..self.battle.roundIndex.."回合")
    self.battle.topView:SetRound(self.battle.roundIndex)
    self:InitSortBattleList()

    for key, hero in pairs(self.battle.hero) do
        hero:ChangeState(HeroState.HRoundStartState)
    end

    self.battle:ChangeState(BattleState.Round)
end

function RoundStartState:CopyState()

end

function RoundStartState:Update()

end

function RoundStartState:OnLeave()

end

function RoundStartState:InitSortBattleList()
    self.battle.sortBattleList = {}
    for uuid, data in pairs(self.battle.hero) do
        table.insert(self.battle.sortBattleList , uuid)
    end

    table.sort(self.battle.sortBattleList,function (a,b)
        return self.battle:GetHeroSpd(a) > self.battle:GetHeroSpd(b)
    end)
end