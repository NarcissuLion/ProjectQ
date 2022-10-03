RoundEndState = {}
RoundEndState.__index = RoundEndState
setmetatable(RoundEndState, FSMState)

function RoundEndState:Create(battle)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.battle = battle
    copy.id = BattleState.BattleStart

    return copy
end

function RoundEndState:OnEnter()
    print(self.battle.roundIndex .. "回合结束")
    
end

function RoundEndState:CopyState()

end

function RoundEndState:Update()

end

function RoundEndState:OnLeave()

end