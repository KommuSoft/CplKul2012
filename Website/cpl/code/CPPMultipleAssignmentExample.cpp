#include <iostream>

int main(){
	int a,b;
	a,b = 5,10; // a is undefined, b is 5
	std::cout << a << "\t" << b << std::endl;
	(a,b) = (5,10); //a is undefined, b is 10
	std::cout << a << "\t" << b << std::endl;
}
