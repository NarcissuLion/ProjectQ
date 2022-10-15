local FSMachine = require 'Framework.FSMachine'
local Notifier = require 'Framework.Notifier'
BattleStartState = {}
BattleStartState.__index = BattleStartState
setmetatable(BattleStartState, FSMachine.State)

function BattleStartState:Create(battle)
    local copy = {}
    setmetatable(copy, BattleStartState)
    copy.battle = battle
    copy.id = BattleState.BattleStart
    copy:Init()
    return copy
end

function BattleStartState:Init()
    
end

function BattleStartState:OnEnter()
    print("进入战斗")
    self:AddPlayer()
    self.orderHero = self.battle:OrderHero()
    Notifier.Dispatch("SetOwnInfo")
    Notifier.Dispatch("SetEnemyInfo")

    for key, hero in pairs(self.battle.hero) do
        hero:ChangeState(HeroState.IdelState)
    end
    -- todoUpdate
    for index, hero in ipairs(self.orderHero) do
        hero:OnBattleStart()
    end
    self.battle:ChangeState(BattleState.RoundStart)
end

function BattleStartState:Dispose()

end

function BattleStartState:OnUpdate()
    self:PlayBuff()
end

function BattleStartState:OnExit()

end


function BattleStartState:AddPlayer()
    local config = self.battle.config

    for index, idArr in ipairs(config.BattlePlayer) do
        if index == 1 then
            for pos, id in ipairs(idArr) do
                if id ~= "-1" then
                    BattleManager:CreatePlayer(pos,id,true)
                end
            end
        elseif index == 2 then
            for pos, id in ipairs(idArr) do
                if id ~= "-1" then
                    BattleManager:CreatePlayer(pos + 5,id,false)
                end
            end
        end        
    end
    Notifier.Dispatch("RefreshAllHero")
end

function BattleStartState:PlayBuff()
    if #self.orderHero == 0 then
        self.battle:ChangeState(BattleState.RoundStart)
        return
    end
    self.orderHero[1]:OnBattleStart()
    if self.orderHero[1].isPlayAction then
        return
    else
        table.remove(self.orderHero , 1)
    end
end