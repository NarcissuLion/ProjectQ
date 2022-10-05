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
        self.own = {}
        local parent = CommonUtil.GetChild(self.root,"Character/Own")
        self.own[pos] = GameUtil.CreatePrefabToParent("Prefab/Character/Player",parent,pos)
        player = self.own[pos]
    else
        self.enemy = {}
        local parent = CommonUtil.GetChild(self.root,"Character/Enemy")
        self.enemy[pos] = GameUtil.CreatePrefabToParent("Prefab/Character/Player",parent,pos)
        player = self.enemy[pos]
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
    
end

function BattleUI:SetEnemyInfo(charData)
    
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