#include <iostream>

using namespace std;

class Interval
{
public:
	//default constructor - it can be called without passing any argument
	Interval()
	{
		seconds = 0;
	}

	//conversion constructor - it can be called by passing exactly one argument
	Interval(int t)
	{
		seconds = t;
	}

	//parametrized constructor
	Interval(int s, int m)
	{
		seconds = 60 * m + s;
	}

	int GetTime()
	{
		return seconds;
	}

	void Print()
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
private:
	int seconds;
};

int main(void)
{
	Interval jack;	//activation using default constructor
	jack.SetTime(125); 
	cout << "Jack's Interval = ";
	jack.Print();

	Interval john = 200; //activating using conversion constructor
	cout << "John's Interval = ";
	john.Print();

	Interval jeff(70, 3); //activating using parameterized constructor
	cout << "Jeff's Interval = ";
	jeff.Print();
}


