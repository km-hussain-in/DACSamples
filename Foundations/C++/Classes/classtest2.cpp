#include <iostream>

using namespace std;

class Interval
{
public:
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

float Speed(float distance, Interval duration)
{
	return 3.6 * distance / duration.GetTime();
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

	Interval john;
	john.SetTime(200);
	cout << "John's Interval = ";
	john.Print();
	cout << "John's Speed = "
		 << Speed(500, john)
		 << endl;
}


