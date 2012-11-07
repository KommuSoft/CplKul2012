function noblegasses ()
	coroutine.yield("He")
	coroutine.yield("Ne")
	coroutine.yield("Ar")
	coroutine.yield("Kr")
	coroutine.yield("Xe")
	coroutine.yield("Rn")
	return "Uuo"
end

co = coroutine.create(noblegasses)

while coroutine.status(co) ~= 'dead' do
	_,value = coroutine.resume(co)
	print(value)
end
