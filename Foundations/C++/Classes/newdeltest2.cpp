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

int main(void)
{
	int n;
	cout << "Number of Intervals: ";
	cin >> n;

	Interval* list = new Interval[n]; //dynamically activating array of n Intervals using default constructor
	for(int i = 0; i < n; ++i)
	{
		list[i].SetTime(100 + 35 * i);
		list[i].Print();
	}
	delete[] list;

}


