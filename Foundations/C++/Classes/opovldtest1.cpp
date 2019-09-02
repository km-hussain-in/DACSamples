#include <iostream>

using namespace std;

class Interval
{
public:
	Interval(int m, int s)
	{
		seconds = 60 * m + s;
	}

	explicit Interval(int t)
	{
		seconds = t;
	}

	Interval()
	{	
		seconds = 0;
	}

	int GetTime() const 
	{
		return seconds; 
	}

	void Print() const
	{
		if((seconds % 60) < 10)
			cout << (seconds / 60) << ":0" << (seconds % 60) << endl;
		else
			cout << (seconds / 60) << ":" << (seconds % 60) << endl;
	}

	void SetTime(int value) 
	{
		seconds = value;
	}

	Interval operator+(const Interval& other) const
	{
		return Interval(seconds + other.seconds);
	}

	Interval operator*(int other) const
	{
		return Interval(seconds * other);
	}
private:
	int seconds;

	//non-member function which can access private members
	//of this class because it is defined by author of this class
	friend Interval operator*(int, const Interval&);
};

Interval operator*(int lhs, const Interval& rhs) 
{
	return Interval(lhs * rhs.seconds);
}

int main(void)
{
	Interval a(5, 20);
	a.Print();

	Interval b(3, 45);
	b.Print();

	Interval c = a + b; //a.operator+(b)
	c.Print();

	//Interval d = c * 3;
	Interval d = 3 * c; //opertor*(3, c)
	d.Print();

}


