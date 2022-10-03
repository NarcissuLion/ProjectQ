RapidJson = require('rapidjson')

require "Mapping"

require "Util.Counter"
require "Util.Utils"

require "Config.ConfigManager"

require "Hotfix.HotfixModel"

require "SDK.SDKModel"

require "View.Base.ViewBase"
require "View.Base.ViewManager"
require "View.Base.ViewUtils"

require "View.BattleUI"

local isPaused = false
local isEditor = false
local unloadSceneHandlers = {}

function Main()
    isEditor = Application.isEditor

end

function BindUnloadSceneHandler(key, handler)
    unloadSceneHandlers[key] = handler
end

-- ���������¼�
function OnSceneLoad(sceneIndex, sceneName)
    ViewManager:Init(sceneIndex, sceneName)
    ConfigManager:Init()

    BattleUI:Create()
    print("OnSceneLoad:" .. sceneName)
end

-- ���س�������������¼�
function OnSceneLoaded(sceneName)
    print("OnSceneLoaded:" .. sceneName)
end

-- ����ж���¼�
function OnSceneUnload(sceneIndex, sceneName)
    print("OnSceneUnload:" .. sceneName)
    for key, handler in pairs(unloadSceneHandlers) do
        TryCatch(handler)
    end
    unloadSceneHandlers = {}

    ViewManager:Destroy()
end

-- ������ؼ�
function OnClickEscape()
    if GuideManager:IsInputBlocked() or ViewManager:IsInputBlocked() then
        return
    end
    local topView = ViewManager:GetTopView()
    if topView ~= nil and topView:OnClickReturn() and topView._config.canClose then
        topView:Destroy()
    end
end

function OnClick(pos)
    --print(pos)
end

-- ������ͣ״̬�仯
function OnApplicationPause(pause)
    --printf("pause:{0}", pause)
    if pause then
        isPaused = true
    end
    return nil
end

-- ���򽹵�״̬�仯
function OnApplicationFocus(focus)
    --printf("focus:{0}", focus)
    if isEditor then
        OnFocus(focus)
        return nil
    end

    if not focus then
        OnFocus(false)
    elseif isPaused and focus then
        isPaused = false
        OnFocus(true)
    end
    return nil
end


function OnFocus(isFocus)
    DispatchOnFocus(isFocus)
end

-- �ַ��¼�����ͼ
function DispatchOnFocus(isFocus)
    local count = ViewManager:GetViewCount()
    if count > 0 then
        for i = count, 1, -1 do
            local view = ViewManager:GetView(i)
            if view ~= nil then
                if isFocus then
                    view:OnFocus()
                else
                    view:OnLoseFocus()
                end
            end
        end
    else
    end
end