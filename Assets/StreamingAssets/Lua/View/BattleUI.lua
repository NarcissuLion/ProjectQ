local Notifier = require 'Framework.Notifier'
BattleUI = {}
BattleUI.__index = BattleUI
setmetatable(BattleUI, ViewBase)

BattleUI.instance = nil

IMG_HERO_PATH = "Prefab/SpriteAssets/Character/"

function BattleUI:Create()
    local copy = ViewBase:Create({canClose = false})
    setmetatable(copy, self)

    copy:Init()

    return copy
end

function BattleUI:Init()
    self.root = self:Add("Prefab/UI/Battle/BattleUI")
    self.hero = {}
    self:CreatePlayer()
    self:AddListener()
end

function BattleUI:AddListener()
    Notifier.AddListener("SetHeroSelectOff",self.SetHeroSelectOff, self)
    Notifier.AddListener("SetHeroSelectedOff",self.SetHeroSelectedOff, self)
    Notifier.AddListener("SetHeroSelect",self.SetHeroSelect, self)
    Notifier.AddListener("ShowCure",self.ShowCure, self)
    Notifier.AddListener("ShowDamage",self.ShowDamage, self)
    Notifier.AddListener("RefreshHero",self.RefreshHero, self)
    Notifier.AddListener("OnSelectSkill",self.OnSelectSkill, self)
    Notifier.AddListener("SetHeroTempMove",self.SetHeroTempMove, self)
    Notifier.AddListener("RefreshAllHero",self.RefreshAllHero, self)
    Notifier.AddListener("MoveHero",self.MoveHero, self)
    Notifier.AddListener("ShowDead",self.ShowDead, self)
    Notifier.AddListener("ShowEffectText",self.ShowEffectText, self)
    Notifier.AddListener("ShowBuff1",self.ShowBuff1, self)    
    Notifier.AddListener("SetHeroVol",self.SetHeroVol, self)    
end

function BattleUI:CreatePlayer()
    local parent = CommonUtil.GetChild(self.root,"Hero")
    for i = 1, 10 do
        self.hero[i] = GameUtil.CreatePrefabToParent("Prefab/Character/Player",parent,i)
        CommonUtil.SetActive(self.hero[i] , nil , false)
    end
end

function BattleUI:SetHeroVol(pos , vol)
    if vol == 1 then
        CommonUtil.SetlLocalScale(self.hero[pos] , "Img" , Vector3.one)
    else
        CommonUtil.SetlLocalScale(self.hero[pos] , "Img" , Vector3.one * 1.5)
    end
end

function BattleUI:SetHeroSelect(pos ,state )
    CommonUtil.SetActive(self.hero[pos] , state , true)
end

function BattleUI:SetHeroSelectOff()
    for key, player in pairs(self.hero) do
        CommonUtil.SetActive(player,"Select" , false)
        CommonUtil.SetActive(player,"Selected" , false)
        CommonUtil.SetActive(player,"SelectedCure" , false)
        CommonUtil.SetActive(player,"SelectedMove" , false)
    end
end

function BattleUI:SetHeroSelectedOff()
    for key, player in pairs(self.hero) do
        CommonUtil.SetActive(player,"Selected" , false)
        CommonUtil.SetActive(player,"SelectedCure" , false)
    end
end

function BattleUI:RefreshHero(pos)
    local heroData = BattleManager:GetHeroByPos(pos , false)
    local player = self.hero[pos]
    CommonUtil.SetActive(player,"Img",true)
    CommonUtil.SetActive(player,"Img2",false)
    if heroData == nil then
        CommonUtil.SetActive(player , nil , false)
        return
    end
    local configData = ConfigManager:GetConfig("Hero")
    local maxHp = configData[heroData.uid].hp
    if heroData.isDead then
        CommonUtil.SetActive(player , nil , false)
        return
    end
    CommonUtil.SetActive(player , nil , true)
    CommonUtil.SetActive(player,"Img",true)
    CommonUtil.SetActive(player,"Img2",false)
    CommonUtil.SetActive(player,"HpBar",true)
    CommonUtil.SetActive(player,"Damage",true)
    CommonUtil.SetActive(player,"Cure",true)
    CommonUtil.SetActive(player,"Select",false)
    CommonUtil.SetActive(player,"Selected",false)
    CommonUtil.SetActive(player,"SelectedCure",false)
    CommonUtil.SetActive(player,"SelectedMove",false)
    ImageLoader.SetImage(player,"Img" ,IMG_HERO_PATH..heroData.prefab)
    CommonUtil.SetText(player,"HpBar/Text" , heroData.hp .. "/" .. maxHp)
    CommonUtil.SetImageFillAmount(player, "HpBar/Image" , heroData.hp/maxHp)
    if heroData.isOwn then
        CommonUtil.AddButtonClick(player, "SelectedCure", BindFunction(self, self.OnClickUseSkillToHero, heroData.uuid))
        -- CommonUtil.AddButtonClick(player, "SelectedMove", BindFunction(self, self.OnSelectMove, heroData.pos))
    else
        CommonUtil.AddButtonClick(player, "Btn", BindFunction(self, BattleManager.topView.SetEnemyInfo, heroData.uuid))
        CommonUtil.AddButtonClick(player, "Selected", BindFunction(self, self.OnClickUseSkillToHero, heroData.uuid))
    end
end

function BattleUI:RefreshAllHero()
    for i = 1, 10 do
        self:RefreshHero(i)
    end
end

function BattleUI:ShowDamage(pos , damage)
    CommonUtil.SetText(self.hero[pos],"Damage" ,damage)
    CommonUtil.DOLocalMoveY(self.hero[pos],"Damage" , 380 , 1.6)
    CommonUtil.DoTextFadeFromTo(self.hero[pos],"Damage" , 1 , 0 ,1.6)
    CommonUtil.DoImageColor(self.hero[pos],"Img" ,Color.red , 0.2)
    CommonUtil.DOShake(self.hero[pos],"Img" , 0.2,10,10)        
    AsyncCall(function ()
        CommonUtil.DoImageColor(self.hero[pos],"Img" ,Color.white, 0.2)
    end , 0.2)
    AsyncCall(function ()
        CommonUtil.SetAnchoredPositionY(self.hero[pos],"Damage" , 90)
    end , 1.8)
    
end

function BattleUI:ShowCure(pos , cure)
    CommonUtil.SetText(self.hero[pos],"Cure" ,"+" .. cure)
    CommonUtil.DOLocalMoveY(self.hero[pos],"Cure" , 380 , 1.6)
    CommonUtil.DoTextFadeFromTo(self.hero[pos],"Cure" , 1 , 0 ,1.6)
    CommonUtil.DoImageColor(self.hero[pos],"Img" ,Color.green , 0.2)
    AsyncCall(function ()
        CommonUtil.DoImageColor(self.hero[pos],"Img" ,Color.white, 0.2)
    end , 0.2)
    AsyncCall(function ()
        CommonUtil.SetAnchoredPositionY(self.hero[pos],"Cure" , 90)
    end , 1.8)
end


function BattleUI:SetHeroTempMove(nowPos , newPos)
    if newPos == nil then
        newPos = nowPos
    end
    local canMovePos = BattleManager:GetHeroTempMovePos(nowPos)
    if #canMovePos == 0 then
        return
    end
    self:SetHeroSelectedOff()
    local heroData = BattleManager:GetHeroByPos(nowPos)
    local configData = ConfigManager:GetConfig("Hero")
    local maxHp = configData[heroData.uid].hp
    for index, pos in ipairs(canMovePos) do
        local player = self.hero[pos]
        CommonUtil.SetActive(player,nil,true)
        if pos ~= newPos then
            CommonUtil.SetActive(player,"Img",false)
            CommonUtil.SetActive(player,"Img2",true)
            CommonUtil.SetActive(player,"HpBar",false)
            CommonUtil.SetActive(player,"Select",false)
            CommonUtil.SetActive(player,"Damage",false)
            CommonUtil.SetActive(player,"Cure",false)
            CommonUtil.SetActive(player,"Btn",false)
            CommonUtil.SetActive(player,"Selected",false)
            CommonUtil.SetActive(player,"SelectedCure",false)
            CommonUtil.SetActive(player,"SelectedMove",true)
            ImageLoader.SetImage(player,"Img2" ,IMG_HERO_PATH..heroData.prefab)
            CommonUtil.AddButtonClick(player, "SelectedMove", BindFunction(self, self.SetHeroTempMove , nowPos , pos))
        else
            CommonUtil.SetActive(player,"Img",true)
            CommonUtil.SetActive(player,"Img2",false)
            CommonUtil.SetActive(player,"HpBar",true)
            CommonUtil.SetActive(player,"Select",true)
            CommonUtil.SetActive(player,"Damage",false)
            CommonUtil.SetActive(player,"Cure",false)
            CommonUtil.SetActive(player,"Btn",false)
            CommonUtil.SetActive(player,"Selected",false)
            CommonUtil.SetActive(player,"SelectedCure",false)
            CommonUtil.SetActive(player,"SelectedMove",false)
            ImageLoader.SetImage(player,"Img" ,IMG_HERO_PATH..heroData.prefab)
            CommonUtil.SetText(player,"HpBar/Text" , heroData.hp .. "/" .. maxHp)
            CommonUtil.SetImageFillAmount(player, "HpBar/Image" , heroData.hp/maxHp)
        end        
    end
    BattleManager.topView:SetOwnInfo(heroData , newPos)
    BattleManager.topView:SetSkillSelect()
end

function BattleUI:OnSelectSkill(selectSkillIndex , newPos)
    self.selectSkillIndex = selectSkillIndex
    self.newPos = newPos
end
function BattleUI:OnClickUseSkillToHero(targetUuid)
    Notifier.Dispatch("InputOver" , self.selectSkillIndex , targetUuid , self.newPos)
    -- BattleManager:UseSkillToHero(self.selectSkillIndex , uuid)
end

-- function BattleUI:OnClickMove(heroData)
--     BattleManager.topView:SetSkillSelect()
--     if heroData.move == 0 then
--         return
--     end
--     self:ShowMoveSelect(heroData)
-- end

function BattleUI:ShowMoveSelect(heroData)
    self:SetHeroSelectedOff()
    local pos = heroData.pos 
    local step = heroData.move
    if step == 1 then
        for i = 1, 3 do
            if i == pos - step or i == pos + step then
                self:SetHeroSelect(i , "SelectedMove")
            end
        end
    end

    if step == 2 then
        for i = 1, 3 do
            if i ~= pos then
                self:SetHeroSelect(i , "SelectedMove")
            end
        end
    end
end

-- function BattleUI:OnSelectMove(moveTo)
--     BattleManager:OwnMove(moveTo)
-- end

function BattleUI:ExchangeHero(pos1 , pos2)
    --播动画
    local position1 = self.hero[pos1].transform.position
    local position2 = self.hero[pos2].transform.position
    CommonUtil.DOMove(self.hero[pos1],nil , position2 , 0.8)
    CommonUtil.DOMove(self.hero[pos2],nil , position1 , 0.8)
    --还原
    AsyncCall(function ()
        self.hero[pos1].transform.position = position1
        self.hero[pos2].transform.position = position2
    end,0.8) 
end

function BattleUI:MoveHero(pos1 , pos2 , time)
    local nowPositon = self.hero[pos1].transform.position
    local targetPos= self.hero[pos2].transform.position
    CommonUtil.DOMove(self.hero[pos1],nil , targetPos , 0.8)
    if time ~= nil then
        AsyncCall(function ()
            self.hero[pos1].transform.position = nowPositon
            BattleManager:ExchangeHero(pos1,pos2)
            self:RefreshAllHero()
        end,time)
    end     
end

function BattleUI:ShowDead(pos)
    CommonUtil.DoImageFade(self.hero[pos],"Img" , 0 ,1)
    CommonUtil.DoImageFade(self.hero[pos],"HpBar" , 0 ,1)
    CommonUtil.DoImageFade(self.hero[pos],"HpBar/Image" , 0 ,1)
    AsyncCall(function ()
        CommonUtil.DoImageFade(self.hero[pos],"Img" , 1 ,0)
        CommonUtil.DoImageFade(self.hero[pos],"HpBar" , 1 ,0)
        CommonUtil.DoImageFade(self.hero[pos],"HpBar/Image" ,1 ,0)
    end , 1)
end

function BattleUI:ShowEffectText(pos , text)
    CommonUtil.SetText(self.hero[pos],"EffectText" ,text)
    CommonUtil.DOLocalMoveY(self.hero[pos],"EffectText" , 380 , 3)
    CommonUtil.DoTextFadeFromTo(self.hero[pos],"EffectText" , 1 , 0 ,3)
    AsyncCall(function ()
        CommonUtil.SetAnchoredPositionY(self.hero[pos],"EffectText" , 90)
    end , 4)
end

function BattleUI:ShowBuff1(pos , isShow)
    CommonUtil.SetActive(self.hero[pos] , "Buff1" , isShow)
end
