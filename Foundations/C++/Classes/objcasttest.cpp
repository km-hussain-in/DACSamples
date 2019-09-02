#include <iostream>

using namespace std;

class Interval
{
public:
	explicit Interval(int m=0, int s=0)
	{
		minutes = m + s / 60;
		seconds = s % 60;
		id = 0;
	}

	int GetTime() const
	{
		return 60 * minutes + seconds;
	}

	int GetId() const
	{
		static int nid = 1;
		if(id == 0)
			id = ++nid;
		return id;
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
	
	static const Interval* Primary()
	{
		static Interval primary;
		primary.id = 1;
		return &primary;
	}
private:
	int minutes;
	int seconds;
	mutable int id; //can be assigned in const member function
};


void Show(const Interval& i)
{
	cout << "Interval with ID "
		 << i.GetId()
		 << " is ";
	i.Print();
}

int main(void)
{
	Interval jack(3, 20);
	Show(jack);

	Interval jill(2, 5);
	Show(jill);

	const Interval* john = Interval::Primary();
	Interval* j = const_cast<Interval*>(john);
	j->SetTime(60);
	struct _Interval
	{
		int minutes;
		int seconds;
		int id;
	};
	_Interval* jj = reinterpret_cast<_Interval*>(j);
	jj->id = 100;
	Show(*john);
}


