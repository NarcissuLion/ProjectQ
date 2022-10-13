HRoundEndState = {}
HRoundEndState.__index = HRoundEndState
setmetatable(HRoundEndState, FSMState)

function HRoundEndState:Create(hero)
    local copy = FSMState:Create()
    setmetatable(copy, self)
    copy.hero = hero
    copy.id = HeroState.HRoundEndState

    return copy
end

function HRoundEndState:OnEnter()
    for index, value in ipairs(self.hero.skillCD) do
        if value ~= 0 then
            print(self.hero.skillCD[index])
            printJson(self.hero.skillCD[index])
            self.hero.skillCD[index] = self.hero.skillCD[index] - 1 
        end        
    end
end

function HRoundEndState:CopyState()

end

function HRoundEndState:Update()

end

function HRoundEndState:OnLeave()

end