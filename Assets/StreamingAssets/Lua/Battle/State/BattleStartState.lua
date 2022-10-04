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
    self.battle:ChangeState(BattleState.RoundStart)
end

function BattleStartState:CopyState()

end

function BattleStartState:Update()

end

function BattleStartState:OnLeave()

end


function BattleStartState:AddPlayer()
    local config = self.battle.config
    local view = self.battle.view

    for index, idArr in ipairs(config.BattlePlayer) do
        if index == 1 then
            for pos, id in ipairs(idArr) do
                if id ~= "-1" then
                    self.battle.own = {}
                    self.battle.own[pos] = {}
                    local charData = self:GetPlayerData(id)
                    self.battle.own[pos].name = charData.name
                    self.battle.own[pos].prefab = charData.prefab
                    self.battle.own[pos].hp = charData.hp
                    self.battle.own[pos].atk = charData.atk
                    self.battle.own[pos].spd = charData.spd
                    self.battle.view:CreatePlayer(true , pos , charData.prefab , charData.hp)
                end
            end
        elseif index == 2 then
            for pos, id in ipairs(idArr) do
                if id ~= "-1" then
                    self.battle.enemy = {}
                    self.battle.enemy[pos] = {}
                    local charData = self:GetPlayerData(id)
                    self.battle.enemy[pos].name = charData.name
                    self.battle.enemy[pos].prefab = charData.prefab
                    self.battle.enemy[pos].hp = charData.hp
                    self.battle.enemy[pos].atk = charData.atk
                    self.battle.enemy[pos].spd = charData.spd
                    self.battle.view:CreatePlayer(false , pos , charData.prefab , charData.hp)
                end
            end
        end        
    end
end

function BattleStartState:GetPlayerData(id)
    local config = ConfigManager:GetConfig("Character")
    if config ~= nil then
        return config[id]
    end
    print(id .. " id is not found")
end
