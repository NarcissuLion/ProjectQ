BattleManager = {}

-- 战斗状态
BattleState = {}
BattleState.BattleStart = 1
BattleState.RoundStart = 2
BattleState.Round = 3
BattleState.RoundEnd = 4
BattleState.BattleEnd = 5

function BattleManager:Create(config)
    self:Init(config)
end

function BattleManager:Init(config)
    self.config = config
    self.view = BattleUI:Create()
    self.topView = TopUI:Create()
    self.state = BattleState.BattleStart

    self.ownTurn = false
    self:InitState()
    self.fsmManager:Start()
end

function BattleManager:InitState()
    self.fsmManager = FSMManager.Create(self)
    self.fsmManager:AddState(BattleStartState:Create(self))
    self.fsmManager:AddState(RoundStartState:Create(self))
    self.fsmManager:AddState(RoundState:Create(self))
    self.fsmManager:AddState(RoundEndState:Create(self))
    self.fsmManager:AddState(BattleEndState:Create(self))
end

function BattleManager:ChangeState(newState)
    self.fsmManager:ChangeState(newState)
end


------------------------------------------------------------
function BattleManager:GetHeroData(id)
    for uuid, data in pairs(self.hero) do
        if uuid == id then
            return data
        end
    end
    if id == nil then
        printError("id为空")
        return
    end
    printError("找不到uuid"..id.."的英雄")
end

function BattleManager:GetHeroSpd(id)
    local heroData = self:GetHeroData(id)
    return heroData.spd
end

function BattleManager:GetHeroMaxHp(id)
    local heroData = ConfigManager:GetConfig("Hero")
    if heroData ~= nil and heroData[id] ~= nil then
        return heroData[id].hp
    end
end

function BattleManager:GetHeroByPos(pos , useVol)
    useVol = useVol == nil and true or useVol
    for uuid, data in pairs(self.hero) do
        if data.pos == pos then
            return data
        end

        if useVol and data.vol == 3 then
            if data.pos + 1 == pos or data.pos - 1 == pos then
                return data
            end
        end
    end
    
    return nil
end

function BattleManager:AddHeroHp(pos , hp)
    for uuid, data in pairs(self.hero) do
        if data.pos == pos then
            local maxHp = self:GetHeroMaxHp(data.uid)
            self.hero[uuid].hp = math.max(0,math.min(self.hero[uuid].hp + hp , maxHp))
            if self.hero[uuid].hp == 0 then
                self.hero[uuid].isDead = true
            end
        end
    end
end

function BattleManager:UseSkillToHero(skillIndex,uuid)
    if self.state == BattleState.Round and self.ownTurn then
        self.fsmManager:GetNowState():OwnUseSkill(skillIndex,uuid)
        self.topView:SetSkillSelect()
    end
end

function BattleManager:OwnMove(moveTo)
    if self.state == BattleState.Round and self.ownTurn then
        self.fsmManager:GetNowState():OwnMove(moveTo)
    end
end

function BattleManager:ExchangeHero(pos1 , pos2)
    local uuid1
    local uuid2
    for uuid, data in pairs(self.hero) do
        if data.pos == pos1 then
            uuid1 = uuid
        end
        if data.pos == pos2 then
            uuid2 = uuid
        end
    end
    if uuid1 ~= nil then
        self.hero[uuid1].pos = pos2
    end
    if uuid2 ~= nil then
        self.hero[uuid2].pos = pos1
    end
end

-- function BattleManager:GetMoveAtkPos(isOwn , nowPos , skillConfig)
--     if skillConfig.typ == "cure" then
--         return skillConfig.atkPos
--     end

--     if skillConfig.range == "own" then
--         return skillConfig.atkPos
--     end

--     local atkPos = skillConfig.atkPos
--     local allData = self:GetOrderData()

--     if nowPos ~= 10 then
--         for i = nowPos + 1, 10 do
--             local charData = allData[i]
--             if charData ~= nil and charData.isDead == nil then
--                 break
--             end
--             if isOwn then
--                 atkPos[2] = math.min(4,atkPos[2]+1)
--             end
--             if not isOwn then
--                 atkPos[1] = math.max(1,atkPos[1]-1)
--             end
--         end        
--     end
--     if nowPos ~= 1 then
--         for i = nowPos - 1, 1,-1 do
--             local charData = allData[i]
--             if charData ~= nil and charData.isDead == nil then
--                 break
--             end
--             if isOwn then
--                 atkPos[1] = math.max(1,atkPos[1]-1)
--             end
--             if not isOwn then
--                 atkPos[2] = math.min(4,atkPos[2]+1)
--             end
--         end        
--     end
--     return atkPos
-- end

function BattleManager:GetHeroTempMovePos(nowPos)
    local canMovePos = {}
    local allData = self:GetOrderData()

    if nowPos ~= 10 then
        for i = nowPos + 1, 10 , 1 do
            local charData = self:GetHeroByPos(i)
            if charData ~= nil and charData.isDead == nil then
                break
            end
            table.insert(canMovePos , i)
        end        
    end
    if nowPos ~= 1 then
        for i = nowPos - 1, 1,-1 do
            local charData = self:GetHeroByPos(i)
            if charData ~= nil and charData.isDead == nil then
                break
            end
            table.insert(canMovePos , i)
        end        
    end
    
    if #canMovePos ~= 0 then
        table.insert(canMovePos , nowPos)
    end
    return canMovePos
end

-- function BattleManager:GetOrderPos(isOwn , nowPos)
--     local posIndex
--     if isOwn then
--         if nowPos == 1 then
--             posIndex = 4
--         elseif nowPos == 2 then
--             posIndex = 3
--         elseif nowPos == 3 then
--             posIndex = 2
--         elseif nowPos == 4 then
--             posIndex = 1
--         end
--     else
--         if nowPos == 1 then
--             posIndex = 5
--         elseif nowPos == 2 then
--             posIndex = 6
--         elseif nowPos == 3 then
--             posIndex = 7
--         elseif nowPos == 4 then
--             posIndex = 8
--         end
--     end

--     return posIndex
-- end

-- function BattleManager:GetCampPos(orderPos)
--     if orderPos == 1 then
--         return true , 4
--     elseif orderPos == 2 then
--         return true , 3
--     elseif orderPos == 3 then
--         return true , 2
--     elseif orderPos == 4 then
--         return true , 1
--     end

--     if orderPos == 5 then
--         return false , 1
--     elseif orderPos == 6 then
--         return false , 2
--     elseif orderPos == 7 then
--         return false , 3
--     elseif orderPos == 8 then
--         return false , 4
--     end
-- end

function BattleManager:GetAllOwnPos()
    local tmp = {}
    for index, data in ipairs(self.hero) do
        if data.isOwn and data.isDead == nil then
            table.insert(tmp , data.pos)
        end
    end
    return tmp
end

function BattleManager:GetAllEnemyPos()
    local tmp = {}
    for index, data in ipairs(self.hero) do
        if not data.isOwn and data.isDead == nil then
            table.insert(tmp , data.pos)
        end
    end
    return tmp
end

function BattleManager:GetOrderData()
    local allData = {}
    for uuid, data in pairs(self.hero) do
        local index = data.pos
        allData[index] = data
    end
    return allData
end

function BattleManager:GetNowAtkPos(nowOrderPos , newOrderPos , skillConfig)
    local atkPos = {}   
    if skillConfig.range == "all" then
        if skillConfig.typ == "cure" then
            atkPos = self:GetAllOwnPos()
        end
        if skillConfig.typ == "atk" then
            atkPos = self:GetAllEnemyPos()
        end
        return atkPos
    end

    if skillConfig.range == "own" then
        table.insert(atkPos , nowOrderPos)
        return atkPos
    end

    local tmp = {}
    if newOrderPos ~= nil and newOrderPos ~= nowOrderPos then
        local step = newOrderPos - nowOrderPos
        for index, pos in ipairs(skillConfig.atkPos) do                
            if skillConfig.typ == "cure" then
                pos = pos - step
            else
                pos = pos + step
            end
            table.insert(tmp , pos)
        end
    else
        tmp = skillConfig.atkPos
    end

    for index, pos in ipairs(tmp) do
        local truePos = nowOrderPos + pos
        if truePos >= 1 and truePos <= 10 then
            table.insert(atkPos,truePos)
        end        
    end

    return atkPos
end

function BattleManager:MoveCamera(pos1 , pos2)
    --x -11 11
    --z 16 26
    local avg = (pos1 + pos2)/2
    local dif = math.abs(pos1 - pos2)
    local x = -13.4 + avg * 2.4
    local z = 26 - dif * 1.1
    ViewManager:MoveCamera( x , z)
    AsyncCall(function ()
        ViewManager:ResetCamera()
    end,0.8)
end

