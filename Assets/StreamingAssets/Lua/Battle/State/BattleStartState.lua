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
    self.battle.hero = {}

    for index, idArr in ipairs(config.BattlePlayer) do
        if index == 1 then
            for pos, id in ipairs(idArr) do
                if id ~= "-1" then
                    self.battle.hero[uuid] = {}
                    local charData = self:GetPlayerData(id)
                    self.battle.hero[uuid].isOwn = true
                    self.battle.hero[uuid].pos = pos
                    self.battle.hero[uuid].uid = id
                    self.battle.hero[uuid].uuid = uuid
                    self.battle.hero[uuid].name = charData.name
                    self.battle.hero[uuid].prefab = charData.prefab
                    self.battle.hero[uuid].hp = charData.hp
                    self.battle.hero[uuid].atk = charData.atk
                    self.battle.hero[uuid].spd = charData.spd
                    self.battle.hero[uuid].skill = charData.skill
                    uuid = uuid + 1
                end
            end
        elseif index == 2 then
            for pos, id in ipairs(idArr) do
                if id ~= "-1" then
                    self.battle.hero[uuid] = {}
                    local charData = self:GetPlayerData(id)
                    self.battle.hero[uuid].isOwn = false
                    self.battle.hero[uuid].pos = pos + 4
                    self.battle.hero[uuid].uid = id
                    self.battle.hero[uuid].uuid = uuid
                    self.battle.hero[uuid].name = charData.name
                    self.battle.hero[uuid].prefab = charData.prefab
                    self.battle.hero[uuid].hp = charData.hp
                    self.battle.hero[uuid].atk = charData.atk
                    self.battle.hero[uuid].spd = charData.spd
                    self.battle.hero[uuid].skill = charData.skill
                    uuid = uuid + 1
                end
            end
        end        
    end
    self.battle.view:RefreshAllHero()
end

function BattleStartState:GetPlayerData(id)
    local config = ConfigManager:GetConfig("Hero")
    if config ~= nil then
        return config[id]
    end
    print(id .. " id is not found")
end
