--attributes
Car = {speed = 0}

--constructor
function Car:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o
end

--other methods
function Car:accelerate(speedIncrease)
	self.speed = self.speed+speedIncrement
end