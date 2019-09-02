#include <iostream>

using namespace std;

void Swap(double& first, double& second)
{
	double third = first;
	first = second;
	second = third;
}

double Average(double first, double second, double& deviation)
{
	deviation = first > second ? (first - second) / 2 : (second - first) / 2;
	return (first + second) / 2;
}

int main(void)
{
	double x, y;

	cout << "Enter two real values: ";
	cin >> x >> y;

	Swap(x, y);
	cout << "Swapped values = " << x << ", " << y << endl;

	double d;
	double a = Average(x, y, d);
	cout << "Average is " << a << " with a deviation of " << d << endl;
}


