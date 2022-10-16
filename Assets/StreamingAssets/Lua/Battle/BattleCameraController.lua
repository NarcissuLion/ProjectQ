local BattleCameraController = {}
BattleCameraController.__index = BattleCameraController

local Notifier = require "Framework.Notifier"

function BattleCameraController.Create(camera)
    local copy = {}
    setmetatable(copy, BattleCameraController)
    copy:Init(camera)
    return copy
end

function BattleCameraController:Init(camera)
    self.camera = camera
    self.origPos = camera.position
    Notifier.AddListener("CameraFocusLeft", self.FocusLeft, self)
    Notifier.AddListener("CameraFocusRight", self.FocusRight, self)
    Notifier.AddListener("CameraFocusAction", self.FocusAction, self)
end

function BattleCameraController:FocusLeft()
    if self.tween ~= nil then CS.DG.Tweening.DOTween.Kill(self.tween) end
    self.tween = self.camera:DOLocalMoveX(-0.5, 0.5)
end

function BattleCameraController:FocusRight()
    if self.tween ~= nil then CS.DG.Tweening.DOTween.Kill(self.tween) end
    self.tween = self.camera:DOLocalMoveX(0.5, 0.5)
end

function BattleCameraController:FocusAction()
    if self.tween ~= nil then CS.DG.Tweening.DOTween.Kill(self.tween) end
    self.camera.position = self.origPos + CS.UnityEngine.Vector3(0, 0, 1)
    self.tween = self.camera:DOMove(self.origPos, 0.5):SetDelay(1)
end

return BattleCameraController