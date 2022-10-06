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
    self.battle.view:SetOwnInfo()
    self.battle.view:SetEnemyInfo()
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
    local uuid = 1
    self.battle.own = {}
    self.battle.enemy = {}

    for index, idArr in ipairs(config.BattlePlayer) do
        if index == 1 then
            for pos, id in ipairs(idArr) do
                if id ~= "-1" then
                    self.battle.own[uuid] = {}
                    local charData = self:GetPlayerData(id)
                    self.battle.own[uuid].isOwn = true
                    self.battle.own[uuid].pos = pos
                    self.battle.own[uuid].uid = id
                    self.battle.own[uuid].uuid = uuid
                    self.battle.own[uuid].name = charData.name
                    self.battle.own[uuid].prefab = charData.prefab
                    self.battle.own[uuid].hp = charData.hp
                    self.battle.own[uuid].atk = charData.atk
                    self.battle.own[uuid].spd = charData.spd
                    self.battle.own[uuid].skill = charData.skill
                    self.battle.view:CreatePlayer(true , pos , charData)
                    uuid = uuid + 1
                end
            end
        elseif index == 2 then
            for pos, id in ipairs(idArr) do
                if id ~= "-1" then
                    self.battle.enemy[uuid] = {}
                    local charData = self:GetPlayerData(id)
                    self.battle.enemy[uuid].isOwn = false
                    self.battle.enemy[uuid].pos = pos
                    self.battle.enemy[uuid].uid = id
                    self.battle.enemy[uuid].uuid = uuid
                    self.battle.enemy[uuid].name = charData.name
                    self.battle.enemy[uuid].prefab = charData.prefab
                    self.battle.enemy[uuid].hp = charData.hp
                    self.battle.enemy[uuid].atk = charData.atk
                    self.battle.enemy[uuid].spd = charData.spd
                    self.battle.enemy[uuid].skill = charData.skill
                    self.battle.view:CreatePlayer(false , pos , charData)
                    uuid = uuid + 1
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
