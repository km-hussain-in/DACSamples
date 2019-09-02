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

	Interval operator++() 
	{
		return Interval(++seconds);
	}

	Interval operator++(int)
	{
		return Interval(seconds++);
	}

	int operator[](int index) const
	{
		return index ? (seconds / 60) : (seconds % 60);
	}

	operator float() const
	{
		return seconds / 60.0;
	}

private:
	int seconds;
};


int main(void)
{
	Interval a(5, 44);
	a.Print();

	Interval b = ++a;
	a.Print();
	b.Print();

	Interval c = b++;
	b.Print();
	c.Print();

	cout << "Last interval = " << c[1] << "min" << c[0] << "sec" << endl;

	float d = c;
	cout << d << endl;
}


