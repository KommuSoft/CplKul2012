#include <iostream>

struct Base{
	virtual void className(){
		std::cout << "Base" << std::endl;
	}
	virtual void foo(){
		std::cout << "foo" << std::endl;
	}
};

struct Derived : public Base {
	virtual void className(){
		std::cout << "Derived" << std::endl;
	}
};

int main() {
	Base b;
	b.className();
	b.foo();

	Derived d;
	d.className();
	d.foo();
}
