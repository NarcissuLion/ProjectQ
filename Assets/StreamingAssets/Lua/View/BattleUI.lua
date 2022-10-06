BattleUI = {}
BattleUI.__index = BattleUI
setmetatable(BattleUI, ViewBase)

BattleUI.instance = nil

function BattleUI:Create()
    local copy = ViewBase:Create({canClose = false})
    setmetatable(copy, self)

    copy:Init()

    return copy
end

function BattleUI:Init()
    self.root = self:Add("Prefab/UI/Battle/BattleUI")
    self.own = {}
    self.enemy = {}
end

function BattleUI:CreatePlayer(isOwn , pos , charData)
    local player
    if isOwn then
        local parent = CommonUtil.GetChild(self.root,"Character/Own")
        self.own[pos] = GameUtil.CreatePrefabToParent("Prefab/Character/Player",parent,pos)
        player = self.own[pos]
        CommonUtil.AddButtonClick(player, "Btn", BindFunction(self, self.SetOwnInfo, charData))
    else
        local parent = CommonUtil.GetChild(self.root,"Character/Enemy")
        self.enemy[pos] = GameUtil.CreatePrefabToParent("Prefab/Character/Player",parent,pos)
        player = self.enemy[pos]
        CommonUtil.AddButtonClick(player, "Btn", BindFunction(self, self.SetEnemyInfo, charData))
    end
    ImageLoader.SetImage(player,"Img" ,"Prefab/SpriteAssets/Character/"..charData.prefab)
    CommonUtil.SetText(player,"HpBar/Text" , charData.hp .. "/" .. charData.hp)
    CommonUtil.SetImageFillAmount(player,pos .. "/HpBar/Image" , charData.hp/charData.hp)
    CommonUtil.SetActive(player,"Select" , false)
    CommonUtil.SetActive(player,"Selected" , false)
end

function BattleUI:SetRound(index)
    CommonUtil.SetText(self.root,"Top/RoundIndex","第"..index.."回合")
end

function BattleUI:SetOwnInfo(charData)
    local ownInfo = CommonUtil.GetChild(self.root,"UI/Own")
    CommonUtil.SetActive(ownInfo , charData ~= nil)
    if charData == nil then
        return
    end
    --BattleManager不唯一，要不弄成单例，要不在状态机中处理点击事件
    local configData = ConfigManager:GetConfig("Character")
    local maxHp = configData[charData.uid].hp

    ImageLoader.SetImage(ownInfo,"Icon" ,"Prefab/SpriteAssets/Character/"..charData.prefab)
    CommonUtil.SetText(ownInfo,"Name" , charData.name)
    CommonUtil.SetText(ownInfo,"Hp" ,"HP:" .. charData.hp .. "/" .. maxHp)
    CommonUtil.SetText(ownInfo,"Hp" ,"SPD:" .. charData.spd)
    CommonUtil.SetText(ownInfo,"Hp" ,"ATK:" .. charData.atk)

    for i = 1, 4 do
        local skillId = charData.skill[i]
        CommonUtil.SetActive(ownInfo,"Skill/" .. i , skillId ~= nil)
        if skillId ~= nil then
            local skillConfig = ConfigManager:GetConfig("Skill")
            CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/name", skillConfig[skillId].name)
        end
    end

end

function BattleUI:SetEnemyInfo(uuid)
    local enemyInfo = CommonUtil.GetChild(self.root,"UI/Enemy")
    CommonUtil.SetActive(enemyInfo , uuid ~= nil)
    if uuid == nil then
        return
    end
    local charData = BattleManager:GetCharData(uuid)
    local configData = ConfigManager:GetConfig("Character")
    local maxHp = configData[charData.uid].hp

    ImageLoader.SetImage(enemyInfo,"Icon" ,"Prefab/SpriteAssets/Character/"..charData.prefab)
    CommonUtil.SetText(enemyInfo,"Name" , charData.name)
    CommonUtil.SetText(enemyInfo,"Hp" ,"HP:" .. charData.hp .. "/" .. maxHp)
    CommonUtil.SetText(enemyInfo,"Hp" ,"SPD:" .. charData.spd)
    CommonUtil.SetText(enemyInfo,"Hp" ,"ATK:" .. charData.atk)

    for i = 1, 4 do
        local skillId = charData.skill[i]
        CommonUtil.SetActive(enemyInfo,"Skill/" .. i , skillId ~= nil)
        if skillId ~= nil then
            local skillConfig = ConfigManager:GetConfig("Skill")
            CommonUtil.SetText(enemyInfo,"Skill/" .. i .. "/name", skillConfig[skillId].name)
        end
    end
end

function BattleUI:SetCharSelect(isOwn , pos ,state )
    if isOwn then
        CommonUtil.SetActive(self.own[pos],state , true)
    else
        CommonUtil.SetActive(self.enemy[pos],state , true)
    end
end

function BattleUI:SetCharSelectOff()
    for key, player in pairs(self.own) do
        CommonUtil.SetActive(player,"Select" , false)
        CommonUtil.SetActive(player,"Selected" , false)
    end
    for key, player in pairs(self.enemy) do
        CommonUtil.SetActive(player,"Select" , false)
        CommonUtil.SetActive(player,"Selected" , false)
    end
end

function BattleUI:RefreshChar(charData)
    local configData = ConfigManager:GetConfig("Character")
    local maxHp = configData[charData.uid].hp
    if charData.isOwn then
        CommonUtil.SetText(self.own[charData.pos],"HpBar/Text" , charData.hp .. "/" .. maxHp)
        CommonUtil.SetImageFillAmount(self.own[charData.pos], "HpBar/Image" , charData.hp/maxHp)
    else
        CommonUtil.SetText(self.enemy[charData.pos],"HpBar/Text" , charData.hp .. "/" .. maxHp)
        CommonUtil.SetImageFillAmount(self.enemy[charData.pos] , "HpBar/Image" , charData.hp/maxHp)
    end
end

function BattleUI:ShowDamage(isOwn , pos , damage)
    if isOwn then
        CommonUtil.SetText(self.own[pos],"Damage" ,damage)
        CommonUtil.DOLocalMoveY(self.own[pos],"Damage" , 380 , 1.6)
        CommonUtil.DoTextFadeFromTo(self.own[pos],"Damage" , 1 , 0 ,1.6)
        AsyncCall(function ()
            CommonUtil.SetAnchoredPositionY(self.own[pos],"Damage" , 90)
        end , 1.8)
    else
        CommonUtil.SetText(self.enemy[pos],"Damage" ,damage)
        CommonUtil.DOLocalMoveY(self.enemy[pos],"Damage" , 380 , 1.6)
        CommonUtil.DoTextFadeFromTo(self.enemy[pos],"Damage" , 1 , 0 ,1.6)
        AsyncCall(function ()
            CommonUtil.SetAnchoredPositionY(self.enemy[pos],"Damage" , 90)
        end , 1.8)
    end
end

function BattleUI:ShowCure(isOwn , pos , cure)
    if isOwn then
        CommonUtil.SetText(self.own[pos],"Cure" ,"+" .. cure)
        CommonUtil.DOLocalMoveY(self.own[pos],"Cure" , 380 , 1.6)
        CommonUtil.DoTextFadeFromTo(self.own[pos],"Cure" , 1 , 0 ,1.6)
        AsyncCall(function ()
            CommonUtil.SetAnchoredPositionY(self.own[pos],"Damage" , 90)
        end , 1.8)
    else
        CommonUtil.SetText(self.enemy[pos],"Cure" ,"+" .. cure)
        CommonUtil.DOLocalMoveY(self.enemy[pos],"Cure" , 380 , 1.6)
        CommonUtil.DoTextFadeFromTo(self.enemy[pos],"Cure" , 1 , 0 ,1.6)
        AsyncCall(function ()
            CommonUtil.SetAnchoredPositionY(self.enemy[pos],"Cure" , 90)
        end , 1.8)
    end
end