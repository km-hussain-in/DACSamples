#include <iostream>

using namespace std;

class Interval
{
public:

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

	void SetTime(int value)
	{
		seconds = value;
	}

	static int CountActiveObjects()
	{
		return count;
	}

	//destructor - called when object is deactivated (removed from the memory)
	//in case of a stack allocated object, it will be called as soon as 
	//the object identifier goes out of scope - stack semantics
	~Interval()
	{
		count--;
	}
private:
	int seconds;
	static int count; 
};

int Interval::count = 0; 

void Run(void)
{
	Interval john = 200;
	cout << "John's Interval = ";
	john.Print();
}

int main(void)
{
	Interval jack;	
	jack.SetTime(125); 
	cout << "Jack's Interval = ";
	jack.Print();

	Run();

	Interval jeff(70, 3);
	cout << "Jeff's Interval = ";
	jeff.Print();

	cout << "Number of active Intervals = "
		 << Interval::CountActiveObjects()
		 << endl;
}


