--attribute
Car = {speed = 50}

--constructor
function Car:new(o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o
end

--other methods
function Car:accelerate(speedIncrease)
	self.speed = self.speed+speedIncrease
end

--Creation of a new car
nCar = Car:new()
nCar:accelerate(70)
print(nCar.speed) --The output is 120, so a takes the speed of Car at the time of creation

--Adding inheritance
FastCar = Car:new();

function FastCar:accelerate(speedIncrease)
	self.speed = self.speed+2*speedIncrease
end

fCar = FastCar:new() --When new executes here, its self parameter will refer to FastCar. This implies that the metatable of fCar will be FastCar.
print(fCar.speed) --The output is 50, so the value of Car is used.

fCar:accelerate(70)
print(fCar.speed) --The output is 190, because the implementation of the method of FastCar is used.
