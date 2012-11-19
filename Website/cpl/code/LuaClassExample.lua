--attribute
Car = {speed = 0}

--constructor
function Car.new(self,o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o
end

--other methods
function Car.accelerate(self,speedIncrement)
	self.speed = self.speed+speedIncrement
end
