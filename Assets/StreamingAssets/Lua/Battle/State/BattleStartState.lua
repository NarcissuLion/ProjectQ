BattleStartState = {}
BattleStartState.__index = BattleStartState
setmetatable(BattleStartState, FSMState)

function BattleStartState:Create(battle)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.battle = battle
    copy.id = BattleState.BattleStart

    return copy
end

function BattleStartState:OnEnter()
    print("进入战斗")
    self:AddPlayer()
    self.battle.topView:SetOwnInfo()
    self.battle.topView:SetEnemyInfo()
    self.battle:ChangeState(BattleState.RoundStart)

    for key, hero in pairs(self.battle.hero) do
        hero:ChangeState(HeroState.HBattleStartState)
    end
end

function BattleStartState:CopyState()

end

function BattleStartState:Update()

end

function BattleStartState:OnLeave()

end


function BattleStartState:AddPlayer()
    local config = self.battle.config
    local uuid = 1
    self.battle.hero = {}

    for index, idArr in ipairs(config.BattlePlayer) do
        if index == 1 then
            for pos, id in ipairs(idArr) do
                if id ~= "-1" then
                    self.battle.hero[uuid] = HeroControler.Create(uuid,pos,id,true)
                    uuid = uuid + 1
                end
            end
        elseif index == 2 then
            for pos, id in ipairs(idArr) do
                if id ~= "-1" then
                    self.battle.hero[uuid] = HeroControler.Create(uuid,pos+5,id,false)
                    uuid = uuid + 1
                end
            end
        end        
    end
    self.battle.view:RefreshAllHero()
end
