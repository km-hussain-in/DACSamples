#include <iostream>

using namespace std;

class Interval
{
public:
	//cannot be used as conversion constructor
	explicit Interval(int m=0, int s=0)
	{
		minutes = m + s / 60;
		seconds = s % 60;
		cout << "Interval activated" << endl;
	}

	int GetTime() const
	{
		return 60 * minutes + seconds;
	}

	void Print() const
	{
		if(seconds < 10)
			cout << minutes << ":0" << seconds << endl;
		else
			cout << minutes << ":" << seconds << endl;
	}

	void SetTime(int value)	
	{
		minutes = value / 60; 
		seconds = value % 60; 
	}

	~Interval()
	{
		cout << "Interval deactivated" << endl;
	}
private:
	int minutes;
	int seconds;
};

float Speed(float distance, const Interval& duration) 
{
	return 3.6 * distance / duration.GetTime();
}

int main(void)
{
	Interval* jack = new Interval; //dynamic activation using default constructor
	jack->SetTime(125);
	cout << "Jack's Interval = ";
	jack->Print();
	cout << "Jack's Speed = "
		 << Speed(500, *jack)
		 << endl;
	delete jack; //explicit deactivation of dynamically activated object

	Interval* john = new Interval(2, 80); //dynamic activation using parameterized constructor
	cout << "John's Interval = ";
	john->Print();
	cout << "John's Speed = "
		 << Speed(500, *john)
		 << endl;
	delete john;
}


