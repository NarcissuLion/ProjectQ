--region *.lua
--Date
--此文件由[BabeLua]插件自动生成

ViewManager = {}
ViewManager.instance = nil

local CKEY_MINIMIZE_TOP_BAR = "minimize_main_top_bar"   -- 当前会最小化大厅3D场景的view数量
local CKEY_HIDE_CONTENT = "hide_main_content"           -- 当前会隐藏大厅内容UI的view数量
local CKEY_HIDE_MAIN_3D_CAMERA  = "hide_main_3D_scene"          -- 当前需要隐藏3D主场景的主摄像机的view数量
local CKEY_SHOW_ENTER_3D_CAMERA = "show_enter_3d_camera"        -- 当前需要显示3D主场景的上阵摄像机的view数量
local CKEY_SHOW_POKEDEX_3D_CAMERA = "show_pokedex_3d_camera"    -- 当前需要显示3D主场景的图鉴摄像机的view数量
local CKEY_SHOW_LOADING = "show_loading"    -- 当前请求显示loading的数量
local CKEY_BLOCK_INPUT = "block_input"      -- 当前请求阻挡输入的数量
local CKEY_HIDE_FLAG = "hide_flag"      -- 当前请求阻挡输入的数量

function ViewManager:Init(sceneIndex, sceneName)
    ViewManager.instance = self

    self.sceneIndex = sceneIndex
    self.sceneName = sceneName
    self.root = GameUtil.CreatePrefab("Prefab/UI/Common/ViewBase/ViewManager")
    self.root.name = "ViewManager"

    self.bottomCanvas   = CommonUtil.GetGameObject(self.root, "BottomCanvas")   -- 底层Canvas，用于显示大厅基础UI
    self.canvas         = CommonUtil.GetGameObject(self.root, "Canvas")         -- 正常Canvas，用于显示一般UI
    self.guideCanvas    = CommonUtil.GetGameObject(self.root, "GuideCanvas")    -- 教学Canvas，用于显示教学
    self.topCanvas      = CommonUtil.GetGameObject(self.root, "TopCanvas")      -- 顶层Canvas，用于显示提示、加载UI
    
    self.bottomArea             = CommonUtil.GetGameObject(self.root, "BottomCanvas/SafeArea")  -- 底层Canvas，用于显示大厅基础UI
    self.area                   = CommonUtil.GetGameObject(self.root, "Canvas/SafeArea")        -- 正常Canvas，用于显示一般UI
    self.guideArea              = CommonUtil.GetGameObject(self.root, "GuideCanvas/SafeArea")   -- 顶层Canvas，用于显示教学
    self.topArea                = CommonUtil.GetGameObject(self.root, "TopCanvas/SafeArea")     -- 顶层Canvas，用于显示提示、加载UI
    self.topAreaBottomSafeArea  = CommonUtil.GetGameObject(self.root, "TopCanvas/BottomSafeArea")     -- 顶层Canvas，但是可以被屏蔽，用于显示组队图标

    self.background         = CommonUtil.GetGameObject(self.root, "BottomCanvas/Background")
    self.defaultBackground  = CommonUtil.GetGameObject(self.root, "BottomCanvas/DefaultBackground")
    self.inputMask          = CommonUtil.GetGameObject(self.root, "TopCanvas/InputMask")    -- 输入遮罩层，用于阻挡屏幕输入
    self.scrollHintLayout   = CommonUtil.GetTransform(self.root, "TopCanvas/SafeArea/ScrollHintLayout")    -- 滚动提示布局

    self.views = {}
    self.counter = Counter:Create()   -- UI模式计数器
    self.safeAreaSize = self.area.transform.sizeDelta
    self.safeAreaScale = self.area.transform.localScale

    -- 加载中UI
    self.loadingUI = GameUtil.CreatePrefab("Prefab/UI/Common/Loading/LoadingUI")
    self.loadingUI:SetActive(false)
    self:AddToTopCanvas(self.loadingUI)

    self.fps = GameUtil.CreatePrefab("Debug/FPS")
    CommonUtil.SetActive(self.fps, nil, GameUtil.IsDebugBuildOrEditor())
    self:AddToTopCanvas(self.fps, true)
end

function ViewManager:Destroy()
    ViewManager.instance = nil
    if self.root ~= nil then
        Destroy(self.root)
    end
    self.sceneIndex = nil
    self.sceneName = nil
    self.root = nil
    self.canvas = nil
    self.topCanvas = nil
    self.views = nil
    self.counter = nil
    self.inputMask = nil
    self.loadingUI = nil
end

function ViewManager:SetDefaultBackground(texture)
    CommonUtil.SetRawImage(self.defaultBackground, nil, texture)
    CommonUtil.SetActive(self.defaultBackground, nil, texture ~= nil)
end

function ViewManager:InsertView(view)
    -- index, sortingOrder
    local viewCount = table.getCount(self.views)
    local lastView = nil
    if viewCount == 0 then
        view._base.sortingOrder = 10
    else
        lastView = self.views[viewCount]
        view._base.sortingOrder = lastView._base.sortingOrder + 10
    end
    view._base.index = viewCount + 1
    view._base.root.name = "ViewLayer " .. view._base.index
    table.insert(self.views, view)
    
    -- SetParent, sortingOrder
    local innerCanvasObj = view._base.root
    self:AddToCanvas(innerCanvasObj)
    CommonUtil.StretchRectTransform(innerCanvasObj, nil)

    local innerCanvas = innerCanvasObj:GetComponent("Canvas")
    innerCanvas.sortingOrder = view._base.sortingOrder

    -- 如果当前是全屏界面，则会挡住后面界面，后面界面要递归设置其激活状态
    if view._config.isFullScreen then
        self:RecursiveSetInvisible(view)
    end 

    -- OnViewCover
    if lastView ~= nil then
        lastView.covered = true
        lastView:OnViewCover()
    end

    if self:IsMainScene() then
        -- 是否需要隐藏顶部栏
        --MainUI:ShowTopBar(view._config.showTopBar)

        -- 是否要显示主ui和3d场景
        if view._config.isFullScreen then
            self.counter:Add(CKEY_HIDE_CONTENT, 1)
            MainUI:ShowContentUI(self.counter:Get(CKEY_HIDE_CONTENT) == 0)
            
            self.counter:Add(CKEY_HIDE_MAIN_3D_CAMERA, 1)
            MainUI:Show3DScene(self.counter:Get(CKEY_HIDE_MAIN_3D_CAMERA) == 0, self.counter:Get(CKEY_SHOW_ENTER_3D_CAMERA) > 0, self.counter:Get(CKEY_SHOW_POKEDEX_3D_CAMERA) > 0)

            self.counter:Add(CKEY_MINIMIZE_TOP_BAR, 1)
            MainUI:MinimizeTopBar(self.counter:Get(CKEY_MINIMIZE_TOP_BAR) > 0)
        end
    end
end

-- 删除view，以及其之下的所有view
-- createViewAfter 关闭view后会马上再创建一个，这时不会调用上一层的OnTop
function ViewManager:DeleteView(view, createViewAfter)
    local viewCount = table.getCount(self.views)
    local index = view._base.index

    -- 从最后删除到自己
    -- 如果在OnDestroy里有删除上一层的代码，下面的priorView可能会是空
    local deleteViews = {}
    for i = viewCount, index, -1 do
        local removedView = table.remove(self.views, i)
        if removedView.covered then
            removedView:OnViewTop()
        end
        removedView:_DestroyView()
        table.insert(deleteViews, removedView)

        -- 是否要显示主ui和3d场景
        if self:IsMainScene() and removedView._config.isFullScreen then
            self.counter:Add(CKEY_HIDE_CONTENT, -1)
            self.counter:Add(CKEY_HIDE_MAIN_3D_CAMERA, -1)
            self.counter:Add(CKEY_MINIMIZE_TOP_BAR, -1)
        end
    end

    -- 如果当前是全屏界面，则后面界面会重新可见，后面界面要递归设置其激活状态
    if view._config.isFullScreen then
        self:RecursiveSetVisible(view)
    end 

    -- OnViewTop
    if index > 1 and not createViewAfter then
        local priorView = self.views[index - 1]
        if priorView ~= nil then
            priorView.covered = false
            priorView:OnViewTop()
        end
    end

    if self:IsMainScene() then
        -- 是否需要显示顶部栏
        if index > 1 then
            local priorView = self.views[index - 1]
            if priorView ~= nil then
--                if priorView._config.showTopBar then
--                    MainUI:ShowTopBar(not priorView._config.isFullScreen)
--                else
--                    MainUI:ShowTopBar(false)
--                end
                MainUI:ShowTopBar(priorView._config.showTopBar)
            end
        else
            MainUI:ShowTopBar(true)
        end

        -- 是否要显示主ui和3d场景
        if view._config.isFullScreen then
            MainUI:ShowContentUI(self.counter:Get(CKEY_HIDE_CONTENT) == 0)
            MainUI:Show3DScene(self.counter:Get(CKEY_HIDE_MAIN_3D_CAMERA) == 0, self.counter:Get(CKEY_SHOW_ENTER_3D_CAMERA) > 0, self.counter:Get(CKEY_SHOW_POKEDEX_3D_CAMERA) > 0)
            MainUI:MinimizeTopBar(self.counter:Get(CKEY_MINIMIZE_TOP_BAR) > 0)
        end

        -- 返回主界面
        if viewCount > 0 and table.getCount(self.views) == 0 and not createViewAfter then
            self:OnMainTop()
        end
    end

    -- 销毁后回调
    for i, view in ipairs(deleteViews) do
        view:OnAfterDestroy()
    end
end

-- 删除所有view，不需要设置可见性等回调，仅需保证每一个view的OnDestroy调用一次
-- createViewAfter 关闭后是否马上要打开新的view，如果是则不调用OnMainTop()，影响教学相关，默认false
function ViewManager:DeleteAllView(createViewAfter)
    local viewCount = table.getCount(self.views)
    local deleteViews = {}
    for i = viewCount, 1, -1 do
        local removedView = table.remove(self.views, i)
        removedView:_DestroyView()
        table.insert(deleteViews, removedView)
    end

    -- 重置显隐状态
    if self:IsMainScene() then
        -- 显示顶部栏
        MainUI:ShowTopBar(true)

        -- 是否要显示主ui
        self.counter:Clear(CKEY_HIDE_CONTENT)
        MainUI:ShowContentUI(true)

        -- 是否要显示3d场景
        self.counter:Clear(CKEY_HIDE_MAIN_3D_CAMERA)
        self.counter:Clear(CKEY_SHOW_ENTER_3D_CAMERA)
        self.counter:Clear(CKEY_SHOW_POKEDEX_3D_CAMERA)
        
        MainUI:Show3DScene(true, false, false)

        -- 是否要最小化顶部栏
        self.counter:Clear(CKEY_MINIMIZE_TOP_BAR)
        MainUI:MinimizeTopBar(false)

        if viewCount > 0 and not createViewAfter then
            self:OnMainTop()
        end
    end

    -- 销毁后回调
    for i, view in ipairs(deleteViews) do
        view:OnAfterDestroy()
    end
end

-- 打开view时，替换已存在的同名view
function ViewManager:ReplaceSameView(newView)
    if newView._config.name == "DefaultView" then
        return
    end
    for i, view in ipairs(self.views) do
        if newView._config.name == view._config.name then
            view:Destroy()
            break
        end
    end
end

function ViewManager:OnMainTop()
    MainUI:OnTop()
end

function ViewManager:IsMainScene()
    return self.sceneName == "Main"
end

-- 添加到根Canvas下
-- safeArea是否添加到safeArea下，默认true
function ViewManager:AddToCanvas(gameObject, safeArea)
    if safeArea ~= false then
        CommonUtil.SetParent(gameObject, self.area, false)
    else
        CommonUtil.SetParent(gameObject, self.canvas, false)
    end
end

-- 添加到顶层Canvas下
-- safeArea是否添加到safeArea下，默认true
function ViewManager:AddToTopCanvas(gameObject, safeArea)
    if safeArea ~= false then
        CommonUtil.SetParent(gameObject, self.topArea, false)
    else
        CommonUtil.SetParent(gameObject, self.topCanvas, false)
    end
end

-- 添加到顶层Canvas下
-- safeArea是否添加到safeArea下，默认true
function ViewManager:AddToTopCanvasBottomSafeArea(gameObject, safeArea)
    if safeArea ~= false then
        CommonUtil.SetParent(gameObject, self.topAreaBottomSafeArea, false)
    else
        CommonUtil.SetParent(gameObject, self.topCanvas, false)
    end
end


-- 添加到底层Canvas下
-- safeArea是否添加到safeArea下，默认true
function ViewManager:AddToBottomCanvas(gameObject, safeArea)
    if safeArea ~= false then
        CommonUtil.SetParent(gameObject, self.bottomArea, false)
    else
        CommonUtil.SetParent(gameObject, self.bottomCanvas, false)
    end
end

-- 添加到底层Canvas的Background下
function ViewManager:AddToBottomBackground(gameObject)
    CommonUtil.SetParent(gameObject, self.background, false)
end

-- 得到view的数量
function ViewManager:GetViewCount()
    if self.views ~= nil then
        return table.getCount(self.views)
    end
    return 0
end

-- 得到指定view
function ViewManager:GetView(index)
    if self.views ~= nil then
        return self.views[index]
    end
    return nil
end

-- 得到前一个view
function ViewManager:GetPriorView(view)
    local index = view._base.index - 1
    if index > 0 and self.views ~= nil then
        return self.views[index]
    end
    return nil
end

-- 得到顶层view
function ViewManager:GetTopView()
    local count = self:GetViewCount()
    if count > 0 and self.views ~= nil then
        return self.views[count]
    end
    return nil
end

-- 递归向上设置不可见性，直到遇到上一个全屏遮挡的界面
function ViewManager:RecursiveSetInvisible(view)
    local priorView = self:GetPriorView(view)
    if priorView ~= nil then
        -- 允许设置非激活，则进行设置
        if priorView._config.inactiveOnInvisible then
            -- 存储原始的激活属性
            if priorView._base.storedActived == nil then
                priorView._base.storedActived = priorView._base.isActived
            end
            if priorView._config.canDeactivate then
                priorView:_SetActive(false)
            end
        end

        -- 递归直到上一个全屏界面
        if not priorView._config.isFullScreen then
            self:RecursiveSetInvisible(priorView)
        end
    end
end

-- 递归向上恢复可见性，直到遇到上一个全屏遮挡的界面
function ViewManager:RecursiveSetVisible(view)
    local priorView = self:GetPriorView(view)
    if priorView ~= nil then
        -- 如果存储过激活属性，则需要恢复，并清空存储值
        if priorView._base.storedActived ~= nil then
            priorView:_SetActive(priorView._base.storedActived)
            priorView._base.storedActived = nil
        end

        -- 递归直到上一个全屏界面
        if not priorView._config.isFullScreen then
            self:RecursiveSetVisible(priorView)
        end
    end
end

-- 是否屏蔽输入
function ViewManager:BlockInput(isBlock)
    if isBlock then
        self.counter:Add(CKEY_BLOCK_INPUT, 1)
    else
        self.counter:Add(CKEY_BLOCK_INPUT, -1)
    end
    if self.counter:Get(CKEY_BLOCK_INPUT) < 0 then
        self.counter:Set(CKEY_BLOCK_INPUT, 0)
    end
    self.inputMask:SetActive(self.counter:Get(CKEY_BLOCK_INPUT) > 0)
--    if self:IsMainScene() and not BattleModel.duringBattle then
--        self:BlockSquadFlag(isBlock)
--    end
end

-- 是隐藏队伍悬浮窗
function ViewManager:BlockSquadFlag(isBlock)
    if isBlock then
        self.counter:Add(CKEY_HIDE_FLAG, 1)
    else
        self.counter:Add(CKEY_HIDE_FLAG, -1)
    end
    if self.counter:Get(CKEY_HIDE_FLAG) < 0 then
        self.counter:Set(CKEY_HIDE_FLAG, 0)
    end
    MainUI:ToggleCombatSquadFlag(self.counter:Get(CKEY_HIDE_FLAG) <= 0)
end

function ViewManager:IsInputBlocked()
    return self.counter:Get(CKEY_BLOCK_INPUT) > 0
end

-- 显示加载中
function ViewManager:ShowLoading(message)
    self:BlockInput(true)
    if self.counter:Add(CKEY_SHOW_LOADING, 1) == 1 then
        self.loadingUI:SetActive(true)
        CommonUtil.SetActive(self.loadingUI, "Content", false)
    end

    if message ~= nil then
        CommonUtil.SetText(self.loadingUI, "Content/TextMessage", message)
    else--if self.counter:Get(CKEY_SHOW_LOADING) > 1 then
        CommonUtil.SetText(self.loadingUI, "Content/TextMessage", "")
    end
    --print("Show: " .. self.counter:Get(CKEY_SHOW_LOADING))
end

-- 隐藏加载中
function ViewManager:HideLoading()
    self:BlockInput(false)

    if self.counter:Get(CKEY_SHOW_LOADING) < 0 then
        self.counter:Set(CKEY_SHOW_LOADING, 0)
    end
    if self.counter:Add(CKEY_SHOW_LOADING, -1) == 0 then
        self.loadingUI:SetActive(false)
    end
    --print("Hide: " .. self.counter:Get(CKEY_SHOW_LOADING))
end

-- 显隐3D主场景的上阵摄像机
function ViewManager:ShowMain3DEnterCamera(show)
    if not self:IsMainScene() then
        return
    end

    self.counter:Add(CKEY_SHOW_ENTER_3D_CAMERA, Choose(show, 1, -1))
    MainUI:Show3DScene(self.counter:Get(CKEY_HIDE_MAIN_3D_CAMERA) == 0, self.counter:Get(CKEY_SHOW_ENTER_3D_CAMERA) > 0, self.counter:Get(CKEY_SHOW_POKEDEX_3D_CAMERA) > 0)
end

-- 显隐3D主场景的图鉴摄像机
function ViewManager:ShowMain3DPokedexCamera(show)
    if not self:IsMainScene() then
        return
    end

    self.counter:Add(CKEY_SHOW_POKEDEX_3D_CAMERA, Choose(show, 1, -1))
    MainUI:Show3DScene(self.counter:Get(CKEY_HIDE_MAIN_3D_CAMERA) == 0, self.counter:Get(CKEY_SHOW_ENTER_3D_CAMERA) > 0, self.counter:Get(CKEY_SHOW_POKEDEX_3D_CAMERA) > 0)
end

-- 设置粒子的sortingOrder为当前最顶层的基础sortingOrder + 1
function ViewManager:SetParticleSortingOrder(parent, path)
    local view = self:GetTopView()
    if view ~= nil then
        view:SetParticleSortingOrder(parent, path)
    end
end

-- 通过名称找到view
function ViewManager:GetViewByName(name)
    for i, view in ipairs(self.views) do
        if view._config.name == name then
            return view
        end
    end
    return nil
end

-- 通过名称找到全部view
function ViewManager:GetViewsByName(name)
    local result = {}
    for i, view in ipairs(self.views) do
        if view._config.name == name then
            table.insert(result, view)
        end
    end
    return result
end

-- 通过名称找到全部view的数量
function ViewManager:GetViewsCountByName(name)
    return table.getCount(self:GetViewsByName(name))
end

-- 是否存在指定名称的view
function ViewManager:HasView(name)
    for i, view in ipairs(self.views) do
        if view._config.name == name then
            return true
        end
    end
    return false
end

-- 指定名称的view是否在顶层
function ViewManager:IsViewOnTop(name)
    local view = self:GetTopView()
    if view ~= nil then
        return view._config.name == name
    end
    return false
end

function ViewManager:ShowScrollHint(message)
    -- 生成最新的一条，放在预定位置下方，准备动画滑入
    local obj = GameUtil.CreatePrefabToParent("Prefab/UI/Common/Other/ScrollHintUI", self.scrollHintLayout, nil)
    CommonUtil.SetAnchoredPositionY(obj, nil, -80)
    CommonUtil.SetText(obj, "Text", message)
    GameObject.Destroy(obj, 1.5)

    -- 超过最大条目的直接销毁
    local max = 5
    CommonUtil.DestroyLimitChildren(self.scrollHintLayout, nil, max, true)

    -- 已存在的所有条目，一起滑动
    local count = self.scrollHintLayout.childCount
    for i = 1, count do
        local child = self.scrollHintLayout:GetChild(i - 1)
        local index = count - i
        CommonUtil.DOKill(child, nil)
        CommonUtil.DOAnchorPosY(child, nil, 80 * index, 0.25, nil)
    end
end


--endregion
