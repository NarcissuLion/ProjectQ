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

function BattleUI:CreatePlayer(isOwn , pos , img ,hp)
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
    ImageLoader.SetImage(player,"Img" ,"Prefab/SpriteAssets/Character/"..img)
    CommonUtil.SetText(player,"HpBar/Text" , hp .. "/" .. hp)
    CommonUtil.SetText(player,"HpBar/Text" , hp .. "/" .. hp)
    CommonUtil.SetImageFillAmount(player,pos .. "/HpBar/Image" , hp/hp)
end

function BattleUI:OnClickButton()

end