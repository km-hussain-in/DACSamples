#include <iostream>

using namespace std;

extern "C" int CountPrimes(int, int);

int main(void)
{
	int l, u;

	cout << "Enter lower and upper bounds: ";
	cin >> l >> u;

	cout << "Number of primes = "
		 << CountPrimes(l, u)
		 << endl;
}

