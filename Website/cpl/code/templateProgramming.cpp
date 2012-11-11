#include <iostream>

template <int N> struct Factorial
{
    enum { val = Factorial<N-1>::val * N };
};

template<>
struct Factorial<0>
{
    enum { val = 1 };
};

int main() {
    std::cout << Factorial<4>::val << std::endl;
}
