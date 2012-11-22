--Creation of a new Car
nCar = Car:new()
nCar:accelerate(70)
print(nCar.speed) --The output is 120

--creation of a new FastCar
fCar = FastCar:new() --When new executes here, its self parameter will refer to FastCar. This implies that the metatable of fCar will be FastCar.
print(fCar.speed) --The output is 50, so the value of Car is used.

fCar:accelerate(70)
print(fCar.speed) --The output is 190, because the implementation of the method of FastCar is used.
