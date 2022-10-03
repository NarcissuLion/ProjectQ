--region *.lua
--Date
--此文件由[BabeLua]插件自动生成

ViewBase = {}
ViewBase.__index = ViewBase

function ViewBase:Create(config)
    local copy = {}
    setmetatable(copy, self)

    copy:_InitView(config)

    return copy
end

----------------- 内部方法 -----------------
function ViewBase:_InitView(config)
    self._base = {}
    self._base.root = GameUtil.CreatePrefab("Prefab/UI/Common/ViewBase/ViewLayer")
    self._base.background = nil
    self._base.index = 0
    self._base.sortingOrder = 0     -- 每两层ViewLayer之前至少相差10
    self._base.destroyed = false    -- 是否已经调用过销毁
    self._base.destroyDelay = 0
    self._base.isActived = true     -- 当前是否激活
    self._base.storedActived = nil  -- 存储的是否激活状态，nil代表没有存储的值
    self._base.tabs = nil
    self._base.tabClickCallback = nil   -- 点击页签回调，参数：点击页签索引，返回值：是否中断切换页签
    self._base.selectTab = 0
    self._base.customTopBarCount = 0    -- 自定义资源条数量，0为默认资源条

    -- 创建view时可传递的配置
    self._config = {}
    self._config.name                = self:_GetConfigValue(config, "name", "DefaultView")    -- 名称
    self._config.inactiveOnInvisible = self:_GetConfigValue(config, "inactiveOnInvisible", true)    -- 不可见时是否自动设置为inactive
    self._config.destroyOnClickMask  = self:_GetConfigValue(config, "destroyOnClickMask", false)    -- 点击遮罩时自动关闭
    self._config.isFirstLevel        = self:_GetConfigValue(config, "isFirstLevel", false)  -- 是否是一级界面，如果是，会先关闭其他所有界面
    self._config.isFullScreen        = self:_GetConfigValue(config, "isFullScreen", true)   -- 是否是全屏界面，全屏界面会完全挡住后面的界面
    self._config.showTopBar          = self:_GetConfigValue(config, "showTopBar", true) -- 是否显示顶部栏
    self._config.canClose            = self:_GetConfigValue(config, "canClose", true)  -- 是否可以关闭(按返回按钮、返回键可以关闭界面)
    self._config.hasBackButton       = self:_GetConfigValue(config, "hasBackButton", true)  -- canClose时是否带返回按钮
    self._config.canDeactivate       = self:_GetConfigValue(config, "canDeactivate", true)  -- 被覆盖后是否可以自动取消激活

    if self._config.isFirstLevel then
--        ViewManager:DeleteAllView()
        ViewManager:ReplaceSameView(self)
    end
    ViewManager:InsertView(self)

    if self._config.isFullScreen or self._config.isFirstLevel then
        self:ShowMask(false)
    end

    CommonUtil.AddButtonClick(self._base.root, "Mask", BindDelegate(self, self._OnClickMask))
    if self._config.canClose and self._config.hasBackButton then
        CommonUtil.AddButtonClick(self._base.root, "ButtonBack", BindDelegate(self, self.Destroy))
    else
        self:ToggleBackButton(false)
    end
end

-- 实际删除操作
function ViewBase:_DestroyView()
    -- 恢复默认资源条
    if self._base.customTopBarCount > 0 then
        --MainUI:ToggleCustomTopBar(false)
    end

    self:OnDestroy()
    if self._base.root ~= nil then
        GameObject.Destroy(self._base.root)
        self._base.root = nil
    end
    if self._base.background ~= nil then
        GameObject.Destroy(self._base.background)
        self._base.background = nil
    end
    self._base.tabs = nil
    self._base.tabClickCallback = nil
end

function ViewBase:_GetConfigValue(config, key, default)
    if config ~= nil and config[key] ~= nil then
        return config[key]
    end
    return default
end

function ViewBase:_SetActive(isActive)
    if self._base.isActived ~= isActive then
        self._base.isActived = isActive

        if self._base.root ~= nil then
            self._base.root:SetActive(isActive)
        end
        if self._base.background ~= nil then
            self._base.background:SetActive(isActive)
        end

        if isActive then
            self:OnActive()

            if self._base.customTopBarCount > 0 then
                --MainUI:ToggleCustomTopBar(true, self._base.customTopBarCount)
                self:RefreshCustomTopBar()
            end
        else
            self:OnInActive()

            if self._base.customTopBarCount > 0 then
                --MainUI:ToggleCustomTopBar(false)
            end
        end
    end
end

-- 点击遮罩层
function ViewBase:_OnClickMask()
    self:OnClickMask()

    if self._config.destroyOnClickMask then
        self:Destroy(false)
    end
end

-- 点击页签
function ViewBase:_OnClickTab(index, playSound)
    local oldIndex = self._base.selectTab 
    self._base.selectTab = index
    if self._base.tabClickCallback ~= nil then
        -- 如果回调返回true，则中断切换页签
        if self._base.tabClickCallback(self, index) then
            self._base.selectTab  = oldIndex
            return
        end
    end

    if playSound then
        AudioManager.GetInstance():PlaySound("click_button")
    end
    for i, tab in ipairs(self._base.tabs) do
        CommonUtil.SetBtnInteractable(tab, nil, i ~= index)
        CommonUtil.SetActive(tab, "Select", i == index)
        CommonUtil.SetActive(tab, "Deselect", i ~= index)
        if i == index then
            CommonUtil.SetButtonTargetGraphic(tab, nil, tab, "Select")
        else
            CommonUtil.SetButtonTargetGraphic(tab, nil, tab, "Deselect")
        end
    end
end

----------------- 内部方法 -----------------


----------------- 对外接口 -----------------

-- 实例化一个预设并加入到当前视图中，返回实例GameObject
function ViewBase:Add(prefabPath)
    return GameUtil.CreatePrefabToParent(prefabPath, self._base.root, "Content")
end

-- 异步实例化一个预设并加入到当前视图中，由callback回传实例GameObject
function ViewBase:AddAsync(prefabPath, callback)
    GameUtil.CreatePrefabToParentAsync(prefabPath, self._base.root, "Content", callback)
end

-- 手动添加一个全屏背景图，覆盖默认的背景图，关闭时会自动销毁
function ViewBase:AddBackground(prefabPath)
    if self._base.background ~= nil then
        GameObject.Destroy(self._base.background)
    end

    self._base.background = GameUtil.CreatePrefab(prefabPath)
    if self._base.background ~= nil then
        ViewManager:AddToBottomBackground(self._base.background)
        return self._base.background
    end
    return nil
end

-- 删除view
function ViewBase:Destroy(createViewAfter)
    if self._base.destroyed then
        return
    end
    if self:OnBeforeDestroy() == false then
        return
    end
    self._base.destroyed = true

    -- 是否延迟销毁
    if self._base.destroyDelay == nil or self._base.destroyDelay == 0 then
        ViewManager:DeleteView(self, createViewAfter)
    else
        ViewManager:BlockInput(true)
        AsyncCall(function()
            ViewManager:BlockInput(false)
            ViewManager:DeleteView(self, createViewAfter)
        end, self._base.destroyDelay, self._base.root)
    end
end

function ViewBase:ToggleBackButton(show)
    CommonUtil.SetActive(self._base.root, "ButtonBack", show)
end


-- 设置延迟销毁时长
function ViewBase:SetDestroyDelay(delay)
    self._base.destroyDelay = delay
end

-- 得到当前的基础sortingOrder
function ViewBase:GetBaseSortingOrder()
    return self._base.sortingOrder
end

-- 是否激活
function ViewBase:GetRootObject()
    return self._base.root
end

-- 设置粒子的sortingOrder为当前层的基础sortingOrder + 1
function ViewBase:SetParticleSortingOrder(parent, path)
    CommonUtil.SetChildrenRendererSortingOrder(parent, path, "Default", self._base.sortingOrder + 1)
end

-- 是否显示遮罩
function ViewBase:ShowMask(visible)
    CommonUtil.SetActive(self._base.root, "Mask", visible ~= false)
end

-- 设置遮罩颜色
function ViewBase:SetMaskColor(color)
    CommonUtil.SetImageColor(self._base.root, "Mask", color)
end

-- 设置遮罩图
function ViewBase:SetMaskImage(image)
    CommonUtil.SetImage(self._base.root, "Mask", image)
end

-- 是否在顶层
function ViewBase:IsOnTop()
    return self._base.index == ViewManager:GetViewCount()
end

-- 是否激活
function ViewBase:IsActived()
    return self._base.isActived
end

-- 初始化点击页签
-- 结构：
--   Tab    页签根节点
--    - Button1     第一个页签
--       - Select   按下状态
--       - Deselect 没有按下状态
--    - Button2
--       - Select
--       - Deselect
function ViewBase:InitTab(tabParent, tabPath, callback)
    self._base.tabs = {}
    self._base.tabClickCallback = callback

    local tabs = CommonUtil.GetChild(tabParent, tabPath)
    for i = 1, tabs.childCount do
        local tab = tabs:GetChild(i - 1)
        self._base.tabs[i] = tab

        CommonUtil.AddButtonClick(tab, nil, BindFunction(self, self._OnClickTab, i, true))
    end
end

-- 点击页签
function ViewBase:ClickTab(index)
    self:_OnClickTab(index, false)
end

-- 得到当前选中页签索引，从1开始
function ViewBase:GetSelectTab()
    return self._base.selectTab
end

-- 显示自定义资源条
function ViewBase:ShowCustomTopBar(count)
    self._base.customTopBarCount = count
    --MainUI:ToggleCustomTopBar(true, count)
    self:RefreshCustomTopBar()
end

----------------- 对外接口 -----------------


----------------- 抽象接口 -----------------

-- 刷新自定义资源条
function ViewBase:RefreshCustomTopBar()
    
end

-- 点击手机返回键
-- return true 则自动调用Destroy， return false 则什么也不做
function ViewBase:OnClickReturn()
    return true
end

-- 销毁前，如果没有延时则和OnDestroy同时调用
-- return true 则继续调用OnDestroy， return false 则什么也不做
function ViewBase:OnBeforeDestroy()
    return true
end

-- 销毁时，当前view层级已移除，但GameObject还未销毁，整个UI层级冒泡事件还未执行
function ViewBase:OnDestroy()

end

-- 销毁后，所有销毁操作全部完成，UI上层事件已触发
function ViewBase:OnAfterDestroy()

end

-- 被其他层级挡住
function ViewBase:OnViewCover()
    --print("OnViewCover: " .. self._base.root.name)
end

-- 返回到顶层
function ViewBase:OnViewTop()
    --print("OnViewTop: " .. self._base.root.name)
end

-- 变为激活
function ViewBase:OnActive()
    --print("OnActive: " .. self._base.root.name)
end

-- 变为非激活
function ViewBase:OnInActive()
    --print("OnInActive: " .. self._base.root.name)
end

-- 点击遮罩层
function ViewBase:OnClickMask()

end

-- 失去焦点、切到后台
function ViewBase:OnLoseFocus()

end

-- 获得焦点、切到前台
function ViewBase:OnFocus()

end
----------------- 接口方法 -----------------


--endregion
