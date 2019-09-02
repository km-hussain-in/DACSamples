#include <iostream>

using namespace std;

extern double Power(double, short);

int main(void)
{
	double b;
	short i;

	cout << "Enter base and index: ";
	cin >> b >> i;
	cout << "Power = "
		 << Power(b, i)
		 << endl;
}

