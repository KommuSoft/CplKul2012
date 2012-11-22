--The base class (it's exactly the same as in the previous example)
Car = {speed = 50}

function Car:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o
end

function Car:accelerate(speedIncrease)
	self.speed = self.speed+speedIncrease
end

--The subclass
FastCar = Car:new(); --the metatable of FastCar is now Car

function FastCar:accelerate(speedIncrease) --override the method accelerate
	self.speed = self.speed+2*speedIncrease
end
