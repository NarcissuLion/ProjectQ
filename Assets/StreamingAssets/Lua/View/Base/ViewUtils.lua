--region *.lua
--Date
--此文件由[BabeLua]插件自动生成

ViewUtils = {}

function ViewUtils.Logout()
    TcpHandler:Dispose()
    ChatManager:Destroy()
    LoginModel.OnLogout()
    SDKModel:Logout()
    BattleModel.OnLogout()
    GameUtil.LoadSceneByName("Login")
end

function ViewUtils.OnSDKLogout()
    ViewUtils.ShowInfoDialogByKey("hint_system", "login_expired", function()
        TcpHandler:Dispose()
        ChatManager:Destroy()
        LoginModel.OnLogout()
        BattleModel.OnLogout()
        GameUtil.LoadSceneByName("Login")
    end)
end

-- 提示框
function ViewUtils.ShowInfoDialog(title, content, callback, btnConfirm)
    local dialog = InfoDialogUI:Create(callback)
    if btnConfirm ~= nil then
        btnConfirm = ConfigManager:GetText(btnConfirm)
    end
    dialog:SetText(title, content, btnConfirm)
    return dialog
end

-- 提示框
function ViewUtils.ShowInfoDialogByKey(title, content, callback, btnConfirm)
    local dialog = InfoDialogUI:Create(callback)
    dialog:SetTextByKey(title, content, btnConfirm)
    return dialog
end

-- 确认框
function ViewUtils.ShowConfirmDialog(title, content, callback, btnConfirm, btnCancel)
    local dialog = ConfirmDialogUI:Create(callback)
    if btnConfirm ~= nil then
        btnConfirm = ConfigManager:GetText(btnConfirm)
    end
    if btnCancel ~= nil then
        btnCancel = ConfigManager:GetText(btnCancel)
    end
    dialog:SetText(title, content, btnConfirm, btnCancel)
    return dialog
end

-- 确认框
function ViewUtils.ShowConfirmDialogByKey(title, content, callback, btnConfirm, btnCancel)
    local dialog = ConfirmDialogUI:Create(callback)
    dialog:SetTextByKey(title, content, btnConfirm, btnCancel)
    return dialog
end

-- 继承viewBase的确认框
function ViewUtils.ShowViewConfirmDialog(title, content, callback, btnConfirm, btnCancel)
    local dialog = ConfirmDialogViewUI:Create(callback)
    if btnConfirm ~= nil then
        btnConfirm = ConfigManager:GetText(btnConfirm)
    end
    if btnCancel ~= nil then
        btnCancel = ConfigManager:GetText(btnCancel)
    end
    dialog:SetText(title, content, btnConfirm, btnCancel)
    return dialog
end

-- 继承viewBase的确认框
function ViewUtils.ShowViewConfirmDialogByKey(title, content, callback, btnConfirm, btnCancel)
    local dialog = ConfirmDialogViewUI:Create(callback)
    dialog:SetTextByKey(title, content, btnConfirm, btnCancel)
    return dialog
end

-- 购买确认框
function ViewUtils.ShowBuyConfirmDialog(title, content, costItems, itemType, callback, btnConfirm, btnCancel)
    local dialog = BuyConfirmDialogUI:Create(callback)
    if btnConfirm ~= nil then
        btnConfirm = ConfigManager:GetText(btnConfirm)
    end
    if btnCancel ~= nil then
        btnCancel = ConfigManager:GetText(btnCancel)
    end
    dialog:SetText(title, content, btnConfirm, btnCancel)
    dialog:SetCost(costItems, itemType)
    return dialog
end

-- 购买确认框
function ViewUtils.ShowBuyConfirmDialogByKey(title, content, costItems, itemType, callback, btnConfirm, btnCancel)
    local dialog = BuyConfirmDialogUI:Create(callback)
    dialog:SetTextByKey(title, content, btnConfirm, btnCancel)
    dialog:SetCost(costItems, itemType)
    return dialog
end

function ViewUtils.ShowBackToLoginConfirm()
    local dailogUI = ConfirmDialogUI:Create(function(confirm)
        if confirm then
            ViewUtils.Logout()
        end
    end)
    dailogUI:SetTextByKey("hint_system", "是否退出到登录界面?", "btn_confirm", "btn_cancel")
end

function ViewUtils.ShowResultDialog(title, content, callback, btnConfirm)
    local dialog = ConfirmDialogUI:Create(callback)
    dialog:SetBtnCancelState(false)
    dialog:SetTextByKey(title, content, btnConfirm, nil)
    return dialog
end

function ViewUtils.ScreenPosToAnchoredPos(pos)
    pos.x = (pos.x - Screen.width * 0.5) * Const.UI_SCALE
    pos.y = (pos.y - Screen.height * 0.5) * Const.UI_SCALE
    return pos
end

function ViewUtils.CreateClickIcon(pos)
    local obj = GameUtil.CreatePrefab("Prefab/UI/Common/Other/ClickEffect")
    GameObject.Destroy(obj, 1)
    ViewManager:AddToTopCanvas(obj, false)
    
    obj.transform.anchoredPosition = ViewUtils.ScreenPosToAnchoredPos(pos)
end

-- 浮动提示
-- duration 持续时间，可为nil
function ViewUtils.ShowHint(message, duration)
    local obj = GameUtil.CreatePrefab("Prefab/UI/Common/Other/HintUI")
    ViewManager:AddToTopCanvas(obj)
    CommonUtil.SetText(obj, "Text", message)
    CommonUtil.ForceLayout(obj, nil)

    if duration ~= nil then
        GameObject.Destroy(obj, duration)
    else
        GameObject.Destroy(obj, 3.0)
    end
end

-- 浮动提示
function ViewUtils.ShowHintByKey(key)
    ViewUtils.ShowHint(ConfigManager:GetText(key))
end

-- 浮动提示
function ViewUtils.ShowHintByKeyWithParam(key, ...)
    ViewUtils.ShowHint(ConfigManager:GetFormatText(key, ...))
end

-- 向上滚动提示
function ViewUtils.ShowScrollHint(message)
    ViewManager:ShowScrollHint(message)
end

-- 向上滚动提示
function ViewUtils.ShowScrollHintByKey(key)
    ViewManager:ShowScrollHint(ConfigManager:GetText(key))
end

-- 提示返回登录
function ViewUtils.ShowBackToLoginDialog()
    if BattleModel.duringBattle and BattleManager.Instance ~= nil then
        BattleManager.Instance:SetSpeed(0)
    end
    ViewUtils.ShowInfoDialogByKey("hint_system", "hint_invalid_save_relogin", function()
        ViewUtils.Logout()
    end)
end

-- 提示有新版本需要下载
function ViewUtils.ShowNewVersionDialog()
    ViewUtils.ShowInfoDialogByKey("hint_system", "hint_new_version", function()
        ViewUtils.Logout()
    end)
end

-- 提示是否重连
function ViewUtils.ShowReconnectConfirm(err, onSuccess, onError)
    ViewUtils.ShowConfirmDialogByKey("hint_system", "hint_poor_network", function(isConfirm)
        if isConfirm then
            LoginModel.Relogin(onSuccess, onError)
        else
            ViewUtils.Logout()
        end
    end)
end

-- 提示是否重试
function ViewUtils.ShowRetryConfirm(onSuccess)
    ViewUtils.ShowConfirmDialogByKey("hint_system", "hint_poor_network_retry", function(isConfirm)
        if isConfirm then
            SafeCall(onSuccess)
        else
            ViewUtils.Logout()
        end
    end)
end

-- 创建一个价格图标
-- resId    价值资源id
-- num      价值数量
-- iconSize 图标大小，浮点数
function ViewUtils.CreatePriceIcon(resId, num, parent)
    
    local iconObj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/PriceIcon" ,parent , nil)
--    if parent ~= nil then
--        ViewUtils.SetParent(iconObj, parent, true)
--    end
--    if iconSize ~= nil then
--        iconObj:GetComponent("RectTransform").sizeDelta = Vector2.New(iconSize, iconSize)
--        ViewUtils.SetAnchoredPosition(iconObj, "TextValue", iconSize + 10, nil)
--    end
    ViewUtils.RefreshPriceIcon(iconObj, resId, num)
    return iconObj
end

-- 刷新价格图标
-- iconObj  图标对象
-- resId    价值资源id
-- num      价值数量
function ViewUtils.RefreshPriceIcon(iconObj, resId, num)
    if iconObj == nil then
        return
    end
    if resId ~= nil then
        local sprite = ImageLoader.LoadSprite(tostring(resId)) --TopGun.SpriteLoader.LoadIcon(tostring(resId))
        CommonUtil.SetActive(iconObj, "ImageIcon", sprite ~= nil)
        CommonUtil.SetImageAutoEnable(iconObj, "ImageIcon", sprite)
    end
    if num ~= nil then
        CommonUtil.SetText(iconObj, "TextValue", num)
    end
end

---- 初始化滚动条特效
--function ViewUtils.InitScrollbarEffect(root, scrollRectPath, effectPath)
--    local controller = CommonUtil.GetComponent(root, scrollRectPath, "ScrollbarController")
--    if controller == nil then
--        printError("Scroll View needs a ScrollbarController")
--        return
--    end
--    controller.onPointerDown = function()
--        CommonUtil.SetParticlePlay(controller, effectPath, true, false)
--    end
--    controller.onPointerUp = function()
--        CommonUtil.SetParticlePlay(controller, effectPath, false, false)
--    end
--end

-- 播放按钮点击特效
function ViewUtils.PlayButtonClickEffect(root, effectPath)
--    CommonUtil.SetActive(root, effectPath, false)
--    CommonUtil.SetActive(root, effectPath, true)
    CommonUtil.SetAnimatorTrigger(root, effectPath, "Play")
end

-- 检查资源是否足够
function ViewUtils.CheckResource(id, needNum)
    if not ModelCommon.CheckResource(id, needNum) then
        ViewUtils.ShowHint(ViewUtils.GetLackMessage(id))
        return false
    end
    return true
end

-- 得到资源不足消息
function ViewUtils.GetLackMessage(resourceId)
    local resType = ModelCommon.GetResourceType(resourceId)
    if resType == RES_TYPE_DRAWING then
        return ConfigManager:GetText("hint_not_enough_drawing")
    elseif resType == RES_TYPE_FRAGMENT then
        return ConfigManager:GetText("hint_not_enough_fragment")
    end

    if resourceId == RES_GOLD then
        return ConfigManager:GetText("hint_not_enough_gold")
    elseif resourceId == RES_DIAMOND then
        return ConfigManager:GetText("hint_not_enough_diamond")
    elseif resourceId == RES_NORMAL_SUPER_DRAWING then
        return ConfigManager:GetText("hint_not_enough_normal_drawing")
    elseif resourceId == RES_SENIOR_SUPER_DRAWING then
        return ConfigManager:GetText("hint_not_enough_senior_drawing")
    elseif resourceId == RES_ACTION then
        return ConfigManager:GetText("hint_not_enough_action")
    elseif resourceId == RES_ENERGY then
        return ConfigManager:GetText("hint_not_enough_energy")
    elseif resourceId == RES_ARENACROSS_ACTION then
        return ConfigManager:GetText("hint_not_enough_ac_action")
    else
        return ConfigManager:GetNameText(resourceId) .. ConfigManager:GetText("hint_not_enough")
    end
end

-- 检查特权类型的vip等级是否满足
-- prevelegeType    特权类型
-- showHint         是否弹出提示，默认true
function ViewUtils.CheckVipLevel(prevelegeType, showHint)
    local vipLevel = ConfigManager:PrevilegeToVip(prevelegeType)
    if vipLevel == nil or Save.player.vip == nil then
        return false
    end
    if Save.player.vip.level < vipLevel then
        if showHint ~= false then
            local hint = ConfigManager:GetFormatText("hint_need_vip", vipLevel)
            ViewUtils.ShowHint(hint)
        end
        return false
    end
    return true
end

-- 检查玩家等级和vip等级是否满足
-- prevelegeType    特权类型
-- showHint         是否弹出提示，默认true
function ViewUtils.CheckLevelAndVipLevel(prevelegeType, showHint)
    local unlockLevel = ConfigManager:GetUnlockLevel(prevelegeType)
    local vipLevel = ConfigManager:PrevilegeToVip(prevelegeType)

    -- 配置老乱改，这里兼容一下
    if unlockLevel == 0 then
        return ViewUtils.CheckVipLevel(prevelegeType, showHint)
    end

    if Save.player.vip.level < vipLevel and Save.player.level < unlockLevel then
        if showHint ~= false then
            local hint = ConfigManager:GetText("hint_unlock_level_and_vip")
            ViewUtils.ShowHintByKey(CommonUtil.FormatText(hint, unlockLevel, vipLevel))
        end
        return false
    end
    return true
end

-- 创建道具图标
-- showName 是否显示名字，默认显示
-- showNum 是否显示数量，默认显示
function ViewUtils.CreateItemIcon(parent, path, showName, showNum)
    local obj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/ItemIcon", parent, path)
    CommonUtil.SetActive(obj, "TextName", showName ~= false)
    CommonUtil.SetActive(obj, "ImageNum", showNum ~= false)
    return obj
end

-- 创建道具图标(小)
function ViewUtils.CreateItemIconSmall(parent, path)
    local obj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/ItemIconSmall", parent, path)
    return obj
end

-- 创建战机图标
function ViewUtils.CreateFighterIcon(parent, path)
    local obj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/FighterIcon", parent, path)
    return obj
end

-- 创建配件图标
function ViewUtils.CreateAccessoryIcon(parent, path)
    local obj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/AccessoryIcon", parent, path)
    return obj
end

-- 创建涂装图标
function ViewUtils.CreatePaintingIcon(parent, path)
    local obj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/PaintingIcon", parent, path)
    return obj
end

-- 创建飞行员图标
function ViewUtils.CreatePilotIcon(parent, path)
    local obj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/PilotIcon", parent, path)
    return obj
end

-- 创建战术机动图标
function ViewUtils.CreateManeuverIcon(parent, path)
    local obj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/ManeuverIcon", parent, path)
    return obj
end

-- 创建精研核心图标
function ViewUtils.CreateFighterCoreIcon(parent, path)
    local obj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/FighterCoreIcon", parent, path)
    return obj
end

-- 尝试得到图标配置的品质
function ViewUtils.GetIconQuality(id)
    if id == nil then
        printError("Image id is nil")
        return nil
    end

    local config = ConfigManager:GetIcon(id)
    if config ~= nil and config.frame_quality ~= nil then
        return config.frame_quality
    end
    return ModelCommon.GetQuality(id)
end

--function ViewUtils.RefreshItemIcon(obj, id, num, numPrefix, onClick, isAsync,highLight)
-- 刷新道具图标
-- param { numPrefix = string, isAsync = bool, highlight = bool, isDouble = bool, src = string, score = bool }
function ViewUtils.RefreshItemIcon(obj, id, num, onClick, param)
    if IsNilOrEmptyStr(id) then
        printError("Item id is nil")
        return
    end

    if param == nil then
        param = {}
    end
    if param.isAsync == nil then
        param.isAsync = true
    end
    if param.score == nil then
        param.score = false
    end
    if param.isDouble == nil then
        param.isDouble = false
    end
   
    -- 如果是xx碎片，则显示原始id图标，再盖一个碎片图片
    local isPiece = ModelCommon.IsPieceId(id)
    CommonUtil.SetActive(obj, "Piece", isPiece)

    -- 高亮显示特效
    CommonUtil.SetActive(obj, "Effect", param.highlight == true)

    -- 来源src, firstDouble：首充翻倍，christmas：充值返利，first：首次
    CommonUtil.SetActive(obj, "ImageFirst", param.src == "first")
    CommonUtil.SetActive(obj, "Title", param.src == "firstDouble" or param.src == "christmas")
    if param.src == "firstDouble" then
        CommonUtil.SetText(obj, "Title/Text", ConfigManager:GetText("hint_first_charge_double"))
    elseif param.src == "christmas" then
        CommonUtil.SetText(obj, "Title/Text", ConfigManager:GetText("hint_charge_rebate"))
    end

    -- 双倍

    if param.isDouble ~= nil then
        ViewUtils.SetDouble(obj, "ImageDouble", obj, "ImageNum/Text", param.isDouble)
    end

    local iconId = id
    if isPiece then
        iconId = ModelCommon.GetPieceIconId(id)
    end

    local isFighter = ModelCommon.IsFighterId(iconId)
    local quality = ViewUtils.GetIconQuality(iconId)
    if isPiece then
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Piece/Image" .. i, i == quality)
        end
    end

    -- 如果带评分，显示评分
    local hasScore = param.score and (isPiece or ModelCommon.IsScoreId(id))
    CommonUtil.SetActive(obj, "Imagescore", hasScore)
    if hasScore then
        local config = ConfigManager:GetBaseConfig(Choose(isPiece, iconId, id))
        CommonUtil.SetText(obj, "Imagescore/TextScore", ConfigManager:GetText("overall_score") .. config.overall_score)
    end

    if param.isAsync then
        if isFighter then
            ImageLoader.SetFighterIconAsync(obj, "ImageIcon", iconId, ImageLoader.FIGHTER_CR)
        else
            ImageLoader.SetImageAsync(obj, "ImageIcon", iconId)
        end    
    else
        if isFighter then
            ImageLoader.SetFighterIcon(obj, "ImageIcon", iconId, ImageLoader.FIGHTER_CR)
        else
            ImageLoader.SetImage(obj, "ImageIcon", iconId)
        end
    end

    for i = 1, 6 do
        CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, i == quality)
    end

    CommonUtil.SetText(obj, "TextName", ConfigManager:GetNameText(id))

    if num ~= nil then
        if param.numPrefix == nil then
            CommonUtil.SetText(obj, "ImageNum/Text", ModelCommon.GetNumDesc(num))
        else
            CommonUtil.SetText(obj, "ImageNum/Text", param.numPrefix .. ModelCommon.GetNumDesc(num))
        end
    end

    CommonUtil.SetActive(obj, "Button", onClick ~= nil)
    if onClick ~= nil then
        CommonUtil.AddButtonClick(obj, "Button", onClick)
    end
end

-- 刷新道具图标ByPath
function ViewUtils.RefreshItemIconByPath(parent, path, id, num, onClick, param)
    local obj = CommonUtil.GetChild(parent, path)
    if obj ~= nil then
        ViewUtils.RefreshItemIcon(obj, id, num, onClick, param)
    end
end

-- 刷新道具图标(小)
function ViewUtils.RefreshItemIconSmall(obj, id, onClick)
    local quality = ViewUtils.GetIconQuality(id)

    for i = 1, 6 do
        CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, i == quality)
    end
    
    CommonUtil.SetImage(obj, "ImageIcon", ImageLoader.LoadResourceSmall(id))

    CommonUtil.SetActive(obj, "Button", onClick ~= nil)
    if onClick ~= nil then
        CommonUtil.AddButtonClick(obj, "Button", onClick)
    end
end

-- 刷新道具图标(小)
function ViewUtils.RefreshItemIconSmallByPath(parent, path, id, onClick)
    local obj = CommonUtil.GetChild(parent, path)
    if obj ~= nil then
        ViewUtils.RefreshItemIconSmall(obj, id, onClick)
    end
end

-- 刷新战机图标
function ViewUtils.RefreshFighterIcon(obj, save, showTypeIcon, onClick)
    CommonUtil.SetActive(obj, "Button", onClick ~= nil)
    if onClick ~= nil then
        CommonUtil.AddButtonClick(obj, "Button", onClick)
    end

    if save ~= nil then
        local quality = ModelCommon.GetQuality(save.id)
        local star = save.star or 0
        CommonUtil.SetTextAndQuality(obj, "ImageLvBg/TextLv", save.level, quality)

        CommonUtil.SetText(obj, "ImageReformLv/Text", save.reformLevel)
        ImageLoader.SetFighterIconAsync(obj, "ImageIcon", save.id, ImageLoader.FIGHTER_C)
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, i == quality)
            CommonUtil.SetActive(obj, "Star/Star" .. i, i <= star ) 
        end

        CommonUtil.SetActive(obj, "ImageIcon", true)
        CommonUtil.SetActive(obj, "ImageLvBg", true)
        CommonUtil.SetActive(obj, "ImageReformLv", true)
        CommonUtil.SetActive(obj, "AssistIcon", showTypeIcon and FighterModel.IsAssistId(save.id))
    else
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, false)
            CommonUtil.SetActive(obj, "Star/Star" .. i, false)            
        end
        CommonUtil.SetActive(obj, "ImageIcon", false)
        CommonUtil.SetActive(obj, "ImageLvBg", false)
        CommonUtil.SetActive(obj, "ImageReformLv", false)
        CommonUtil.SetActive(obj, "AssistIcon", false)
    end
    
end

-- 刷新战机图标
function ViewUtils.RefreshFighterIconByPath(parent, path, save, showTypeIcon, onClick)
    local obj = CommonUtil.GetChild(parent, path)
    if obj ~= nil then
        ViewUtils.RefreshFighterIcon(obj, save, showTypeIcon, onClick)
    end
end

-- 刷新配件图标
function ViewUtils.RefreshAccessoryIcon(obj, save, onClick)
    CommonUtil.SetActive(obj, "Button", onClick ~= nil)
    if onClick ~= nil then
        CommonUtil.AddButtonClick(obj, "Button", onClick)
    end

    if save ~= nil then
        local quality = ModelCommon.GetQuality(save.id)
        local star = save.star
        CommonUtil.SetTextAndQuality(obj, "ImageLvBg/TextLv", save.level, quality)

        CommonUtil.SetText(obj, "ImageReformLv/Text", "+"..save.reformLevel)
        ImageLoader.SetImageAsync(obj, "ImageIcon", save.id)

        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, i == quality)
            CommonUtil.SetActive(obj, "Star/Star" .. i, i <= star ) 
        end

        CommonUtil.SetActive(obj, "ImageIcon", true)
        CommonUtil.SetActive(obj, "ImageLvBg", true)
        CommonUtil.SetActive(obj, "ImageReformLv", true)
    else
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, false)
            CommonUtil.SetActive(obj, "Star/Star" .. i, false)            
        end
        CommonUtil.SetActive(obj, "ImageIcon", false)
        CommonUtil.SetActive(obj, "ImageLvBg", false)
        CommonUtil.SetActive(obj, "ImageReformLv", false)
    end
    
end

-- 刷新配件图标
function ViewUtils.RefreshAccessoryIconByPath(parent, path, save, onClick)
    local obj = CommonUtil.GetChild(parent, path)
    if obj ~= nil then
        ViewUtils.RefreshAccessoryIcon(obj, save, onClick)
    end
end

-- 刷新涂装图标
function ViewUtils.RefreshPaintingIcon(obj, save, onClick)
    CommonUtil.SetActive(obj, "Button", onClick ~= nil)
    if onClick ~= nil then
        CommonUtil.AddButtonClick(obj, "Button", onClick)
    end

    if save ~= nil then
        local quality = ModelCommon.GetQuality(save.id)
        local star = save.star
        CommonUtil.SetTextAndQuality(obj, "ImageLvBg/TextLv", save.level, quality)

        CommonUtil.SetText(obj, "ImageReformLv/Text", save.improveLevel)
        ImageLoader.SetImageAsync(obj, "ImageIcon", save.id)

        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, i == quality)
        end

        CommonUtil.SetActive(obj, "ImageIcon", true)
        CommonUtil.SetActive(obj, "ImageLvBg", true)
        CommonUtil.SetActive(obj, "ImageReformLv", true)
    else
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, false)
        end
        CommonUtil.SetActive(obj, "ImageIcon", false)
        CommonUtil.SetActive(obj, "ImageLvBg", false)
        CommonUtil.SetActive(obj, "ImageReformLv", false)
    end
    
end

-- 刷新涂装图标
function ViewUtils.RefreshPaintingIconByPath(parent, path, save, onClick)
    local obj = CommonUtil.GetChild(parent, path)
    if obj ~= nil then
        ViewUtils.RefreshPaintingIcon(obj, save, onClick)
    end
end


-- 刷新飞行员图标
function ViewUtils.RefreshPilotIcon(obj, save, onClick)
    CommonUtil.SetActive(obj, "Button", onClick ~= nil)

    if onClick ~= nil then
        CommonUtil.AddButtonClick(obj, "Button", onClick)
    end

    if save ~= nil then
        CommonUtil.SetText(obj, "ImageLvBg/TextLv", save.level)
        CommonUtil.SetText(obj, "ImageReformLv/Text","+"..save.promotionLevel)
        ImageLoader.SetImageAsync(obj, "ImageIcon", save.id)

        local quality = ModelCommon.GetQuality(save.id)
        local star = save.star
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, i == quality)
        end

        CommonUtil.SetActive(obj, "ImageLvBg", true)
        CommonUtil.SetActive(obj, "ImageReformLv", true)
    else
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, false)
        end
        CommonUtil.SetActive(obj, "ImageIcon", false)
        CommonUtil.SetActive(obj, "ImageLvBg", false)
        CommonUtil.SetActive(obj, "ImageReformLv", false)
    end
end

-- 刷新飞行员图标
function ViewUtils.RefreshPilotIconByPath(parent, path, save, onClick)
    local obj = CommonUtil.GetChild(parent, path)
    if obj ~= nil then
        ViewUtils.RefreshPilotIcon(obj, save, onClick)
    end
end


function ViewUtils.GetQualityColor(quality)
    local values = ConfigManager:GetGlobal("quality_color_" .. quality)
    local array = values:split(",")
    return Color.New(array[1] / 255, array[2] / 255, array[3] / 255, 1)
end

function ViewUtils.SetViewTabText(root, tabPath, index, text, quality)
    if quality == nil then
        CommonUtil.SetText(root, tabPath .. "/Button" .. index .. "/Select/Text", text)
        CommonUtil.SetText(root, tabPath .. "/Button" .. index .. "/Deselect/Text", text)
    else
        CommonUtil.SetTextAndQuality(root, tabPath .. "/Button" .. index .. "/Select/Text", text, quality)
        CommonUtil.SetTextAndQuality(root, tabPath .. "/Button" .. index .. "/Deselect/Text", text, quality)
    end
end

function ViewUtils.SetMultilevelTabText(root, tabPath, index, text, quality)
    if quality == nil then
        CommonUtil.SetText(root, tabPath .. "/Tab" .. index .. "/Select/Text", text)
        CommonUtil.SetText(root, tabPath .. "/Tab" .. index .. "/Deselect/Text", text)
    else
        CommonUtil.SetTextAndQuality(root, tabPath .. "/Tab" .. index .. "/Select/Text", text, quality)
        CommonUtil.SetTextAndQuality(root, tabPath .. "/Tab" .. index .. "/Deselect/Text", text, quality)
    end
end

-- 设置拥有消耗文本，根据是否足够设置颜色，可传文本格式的key
function ViewUtils.SetHaveCostWithColor(parent, path, have, cost, formatKey)
    local text = nil
    if formatKey ~= nil then
        text = ConfigManager:GetFormatText(formatKey, ModelCommon.GetNumDesc(have), ModelCommon.GetNumDesc(cost))
    else
        text = ModelCommon.GetNumDesc(have) .. "/" .. ModelCommon.GetNumDesc(cost)
    end

    if have >= cost then
        CommonUtil.SetTextAndColor(parent, path, text, Const.WHITE_COLOR)
    else
        CommonUtil.SetTextAndColor(parent, path, text, Const.RED_COLOR)
    end
end

-- 刷新战术机动图标
function ViewUtils.RefreshManeuverIcon(obj, save, onClick)
    CommonUtil.SetActive(obj, "Button", onClick ~= nil)

    if onClick ~= nil then
        CommonUtil.AddButtonClick(obj, "Button", onClick)
    end

    if save ~= nil then
        ImageLoader.SetImageAsync(obj, "ImageIcon", save.id)
        CommonUtil.SetText(obj,"ImageLvBg/TextLv",save.level)

        local quality = ModelCommon.GetQuality(save.id)
        local star = save.star
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, i == quality)
        end
        for i = 1, ManeuverModel.maxStar do
            CommonUtil.SetActive(obj, "Star/Star" .. i, i <= star)
        end
    else
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, false)
        end
        for i = 1, ManeuverModel.maxStar do
            CommonUtil.SetActive(obj, "Star/Star" .. i, false)            
        end
        CommonUtil.SetActive(obj, "ImageIcon", false)      
    end
end

-- 刷新战术机动图标
function ViewUtils.RefreshManeuverIconByPath(parent, path, save, onClick)
    local obj = CommonUtil.GetChild(parent, path)
    if obj ~= nil then
        ViewUtils.RefreshManeuverIcon(obj, save, onClick)
    end
end

-- 刷新精研核心图标
function ViewUtils.RefreshFighterCoreIcon(obj, save, onClick)
    CommonUtil.SetActive(obj, "Button", onClick ~= nil)

    if onClick ~= nil then
        CommonUtil.AddButtonClick(obj, "Button", onClick)
    end

    if save ~= nil then
        ImageLoader.SetImageAsync(obj, "ImageIcon", save.id)
        CommonUtil.SetText(obj,"ImageLvBg/TextLv",save.level)

        local quality = ModelCommon.GetQuality(save.id)
        local star = save.star
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, i == quality)
        end
        for i = 1, FighterCoreModel.maxStar do
            CommonUtil.SetActive(obj, "Star/Star" .. i, i <= star)
        end
    else
        for i = 1, 6 do
            CommonUtil.SetImageEnabled(obj, "Quality/Image" .. i, false)
        end
        for i = 1, FighterCoreModel.maxStar do
            CommonUtil.SetActive(obj, "Star/Star" .. i, false)            
        end
        CommonUtil.SetActive(obj, "ImageIcon", false)      
    end
end

-- 刷新精研核心图标
function ViewUtils.RefreshFighterCoreIconByPath(parent, path, save, onClick)
    local obj = CommonUtil.GetChild(parent, path)
    if obj ~= nil then
        ViewUtils.RefreshFighterCoreIcon(obj, save, onClick)
    end
end

-- 检查消耗物品库存，没有则购买，有则使用
function ViewUtils.CheckCostItem(shopId, itemId, callback)
    local item = ConfigManager:GetItem(itemId)
    if item == nil then
        ViewUtils.ShowHint(ViewUtils.GetLackMessage(itemId))
    else
        item.amount = ModelCommon.GetResource(itemId)
        if item.amount == 0 then
            local showcase = ShopModel.GetShowcaseItem(shopId, itemId)
            if showcase == nil then
                ViewUtils.ShowHint(ViewUtils.GetLackMessage(itemId))
            else
                BatchBuyUI:Create(shopId, showcase.showcase_id, callback)
            end
        else
            BatchUseUI:Create(item, item.amount, callback)
        end
    end
end

-- 创建拥有/消耗物品
function ViewUtils.CreateCostItem(parent, path)
    local item = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/CostItem", parent, path)
    ViewUtils.CreateItemIcon(item, "ImageIcon", false, false)
    return item
end

-- 刷新拥有/消耗物品
function ViewUtils.RefreshCostItem(item, id, have, cost)
    ViewUtils.RefreshItemIconByPath(item, "ImageIcon/ItemIcon", id, have, function()
        ItemInfoUI:Create(id)
    end)

    CommonUtil.SetTextAndQuality(item, "TextName", ConfigManager:GetNameText(id), ModelCommon.GetQuality(id))

    local costText = ConfigManager:GetText("own_cost") .. ": " .. ModelCommon.GetNumDesc(have) .. "/" .. ModelCommon.GetNumDesc(cost)
    local costColor = Choose(have >= cost, Color.white, Color.red)
    CommonUtil.SetTextAndColor(item, "TextCost", costText, costColor)
end

-- 创建玩家头像图标
function ViewUtils.CreatePlayerAvatar(parent, path)
    local obj = CommonUtil.GetChild(parent, path .. "/AvatarItem")
    if obj == nil then
        obj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Item/AvatarItem", parent, path)
    end
    CommonUtil.SetImageEnabled(obj, "ImageAvatar", false)
    CommonUtil.SetImageEnabled(obj, "ImageFrame", false)
    CommonUtil.SetActive(obj, "ButtonVip", false)
    return obj
end

--刷新用户头像
--avatarId:头像id
--frameId: 头像框id
function ViewUtils.RefreshPlayerAvatar(parent, path, avatarId, frameId, vipLevel)
    if IsNilOrBlankStr(path) then
        path = "AvatarItem"
    else
        path = path .. "/AvatarItem"
    end

    CommonUtil.SetImageAutoEnable(parent, path .. "/ImageAvatar", PlayerInfoModel.GetAvatarImage(avatarId or 0))
    CommonUtil.SetImageAutoEnable(parent, path .. "/ImageFrame", PlayerInfoModel.GetAvatarFrame(frameId))
    
    CommonUtil.SetActive(parent, path .. "/ButtonVip", vipLevel ~= nil)
    if vipLevel ~= nil then
        for i = 1, 15 do
            CommonUtil.SetImageEnabled(parent, path .. "/ButtonVip/Image" .. i, i == vipLevel)
        end
    end
end

-- 刷新物品列表，在指定的父节点下创建多个物品图标，已存在则刷新
function ViewUtils.RefreshItemList(parent, path, items, itemType, showName, showNum, hasDefaultClick, isAsync, showScore)
    if isAsync == nil then
        isAsync = true
    end

    local array = items
    if itemType == Const.ITEMS_TYPE_KV then
        array = ModelCommon.ItemTableToArray(items)
    end
    if array == nil then
        printError("Item list is nil")
        array = {}
    end

    local container = CommonUtil.GetChild(parent, path)
    local existCount = container.childCount
    local count = table.getCount(array)

    for i = 1, count - existCount do
        ViewUtils.CreateItemIcon(container, nil, showName, showNum)
    end

    for i = 1, container.childCount do
        local data = array[i]

        local icon = container:GetChild(i - 1)
        icon.gameObject:SetActive(data ~= nil)

        if data ~= nil then
            if data.callback == nil and hasDefaultClick then
                data.callback = function()
                    ItemInfoUI:Create(data.id)
                end
            end

            ViewUtils.RefreshItemIcon(icon, data.id, Choose(showNum, data.num, nil), data.callback, {
                isAsync = isAsync, highlight = data.isflashy == 1, src = data.src, score = showScore
            })
        end
    end
end

-- 添加帮助按钮
function ViewUtils.AddHelpButton(uiRoot,hType,callBack)
    if uiRoot == nil then
        return
    end
    local btn = CommonUtil.GetChild(uiRoot, "Label/Text/HelpButton")
    if btn == nil then
        btn = GameUtil.AddHelpButton(uiRoot, "Label/Text", Vector2.New(24, 0), "Prefab/UI/Common/Other/HelpButton", Vector2.New(100, 0))
    end
    CommonUtil.AddButtonClick(btn, nil, function()
        HelpUI:Create(hType,callBack)
    end)
end

-- 同时设置双倍掉落/经验的标签和文本颜色
-- labelParent 双倍图标
-- labelPath 双倍图标
-- textParent 数量文本
-- textPath 数量文本
-- isDouble 是否双倍
function ViewUtils.SetDouble(labelParent, labelPath, textParent, textPath, isDouble)
    if labelParent ~= nil then
        CommonUtil.SetActive(labelParent, labelPath, isDouble)
    end

    if isDouble and textParent ~= nil then
        CommonUtil.SetTextColor(textParent, textPath, Const.YELLOW_COLOR)
    end
end

function ViewUtils.SmartShowItemInfo(itemId)
    -- 礼包，需要显示礼包内容
    local itemConfig = ConfigManager:GetConfig("item")[tostring(itemId)] 
    if itemConfig ~= nil and itemConfig.is_show_item == 1 then
        PackagePreviewUI:Create(itemId)
        return
    end

    -- 养成线对象，需要显示对象的详情
    local resType = ModelCommon.GetResourceType(itemId)
    if resType == Const.RES_TYPE_FIGHTER_PART or resType == Const.RES_TYPE_FIGHTER then
        FighterDetailMaskUI:CreateById(ModelCommon.GetFighterId(itemId))
        return
    elseif resType == Const.RES_TYPE_PILOT_PIECE or resType == Const.RES_TYPE_PILOT then
        PilotDetailMaskUI:CreateById(ModelCommon.GetPilotId(itemId))
        return
    elseif resType == Const.RES_TYPE_ACCESSORY_PIECE or resType == Const.RES_TYPE_ACCESSORY then
        AccessoryDetailMaskUI:CreateById(ModelCommon.GetAccessoryId(itemId))
        return
    elseif resType == Const.RES_TYPE_PAINTING_PIECE or resType == Const.RES_TYPE_PAINTING then
        PaintingDetailMaskUI:CreateById(ModelCommon.GetPaintingId(itemId))
        return
    elseif resType == Const.RES_TYPE_MANEUVER_PIECE or resType == Const.RES_TYPE_MANEUVER then
        ManeuverDetailMaskUI:CreateById(ModelCommon.GetManeuverId(itemId))
        return
    elseif resType == Const.RES_TYPE_FIGHTER_CORE then
        FighterCoreDetailMaskUI:CreateById(itemId)
        return
    end

    -- 其他的，只能显示物品信息了
    ItemInfoUI:Create(itemId)
end

--endregion
