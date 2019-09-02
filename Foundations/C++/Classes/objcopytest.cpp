#include <iostream>

using namespace std;

class Interval
{
public:
	explicit Interval(int m=0, int s=0)
	{
		minutes = m + s / 60;
		seconds = s % 60;
		cout << "Interval activated" << endl;
	}

	//copy constructor
	Interval(const Interval& other)
	{
		minutes = other.minutes;
		seconds = other.seconds;
		cout << "Interval(copy) activated" << endl;
	}

	void operator=(const Interval& other)
	{
		minutes = other.minutes;
		seconds = other.seconds;
		cout << "Interval assigned" << endl;
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

class Journey
{
public:
	//Journey(float dis, const Interval& dur) : duration(dur)
	Journey(float dis, const Interval& dur) : duration(&dur)
	{
		distance = dis;
		cout << "Journey activated" << endl;
	}

	float Speed() const
	{	
		//return 3.6 * distance / duration.GetTime();
		return 3.6 * distance / duration->GetTime();
	}

	~Journey()
	{
		cout << "Journey deactivated" << endl;
	}
private:
	float distance;
	//Interval duration;
	const Interval* duration;
};

void Run(void)
{
	Interval i(3, 20);
	Journey j(500, i);
	cout << "Speed = " << j.Speed() << endl;
}

int main(void)
{
	cout << "Journey begins..." << endl;
	Run();
	cout << "Journey ends." << endl;
}


