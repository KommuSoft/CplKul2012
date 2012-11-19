Car = {}

--attribute
Car["speed"] = 0

--constructor
Car["new"] = function (self, o)
	o = o or {}
	setmetatable(o,self)
	self.__index = self
	return o
end

--other methods
Car["accelerate"] = function (self,speedIncrement)
	self["speed"] = self["speed"]+speedIncrement
end
