#include <iostream>

using namespace std;

class Interval
{
public:

	//parameterized constructor which can be used as default constructor
	//and conversion constructor
	Interval(int s=0, int m=0)
	{
		seconds = 60 * m + s;
		++count;
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

	//must be called on an object (using . operator)
	//it receives 'this' argument in its first (hidden) parameter 
	void SetTime(int value)
	{
		seconds = value;
	}

	//can be called on the class (using :: operator)
	//does not receive 'this' argument and as such
	//it cannot refer to any non-static member of the class
	static int CountActiveObjects()
	{
		return count;
	}
private:
	int seconds; //value will be separately stored in each object
	static int count; //a single value will be shared by all objects
};

int Interval::count = 0; //assign memory for static count of Interval class

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

	cout << "Number of active Intervals = "
		 << Interval::CountActiveObjects()
		 << endl;
}


