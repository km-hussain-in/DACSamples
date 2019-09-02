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

	int GetTime() const //int _ZKN8Interval7GetTimeEv(const Interval* this)
	{
		return seconds; //this->seconds;
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

	static int CountActiveObjects() 
	{
		return count;
	}

	~Interval()
	{
		count--;
	}
private:
	int seconds;
	static int count; 
};

int Interval::count = 0; 

float Speed(float distance, const Interval& duration) 
{
	return 3.6 * distance / duration.GetTime(); //_ZKN8Interval7GetTimeEv(&duration)
}

int main(void)
{
	Interval jack;	
	jack.SetTime(125); 
	cout << "Jack's Interval = ";
	jack.Print();
	cout << "Jack's Speed = "
		 << Speed(500, jack)
		 << endl;

	Interval john = 200;
	cout << "John's Interval = ";
	john.Print();
	cout << "John's Speed = "
		 << Speed(500, john)
		 << endl;

	cout << "Number of active Intervals = "
		 << Interval::CountActiveObjects()
		 << endl;
}


