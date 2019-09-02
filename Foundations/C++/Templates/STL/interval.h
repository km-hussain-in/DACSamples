#ifndef INTERVAL_H
#define INTERVAL_H

#include <iostream>

class Interval
{
public:
	explicit Interval(int m=0, int s=0)
	{
		minutes = m + s / 60;
		seconds = s % 60;
	}

	int GetTime() const
	{
		return 60 * minutes + seconds;
	}

	void SetTime(int value)	
	{
		minutes = value / 60; 
		seconds = value % 60; 
	}

	int Minutes() const
	{
		return minutes;
	}

	int Seconds() const
	{
		return seconds;
	}

	bool operator==(const Interval& other)
	{
		return (minutes == other.minutes) && (seconds == other.seconds);
	}
	
	bool operator<(const Interval& other) const
	{
		int t1 = 60 * minutes + seconds;
		int t2 = 60 * other.minutes + other.seconds;

		return t1 < t2;
	}
	
	bool operator>(const Interval& other) const
	{
		int t1 = 60 * minutes + seconds;
		int t2 = 60 * other.minutes + other.seconds;

		return t1 > t2;
	}

	int minutes;
	int seconds;
	friend std::ostream& operator<<(std::ostream& out, const Interval& value);
};

std::ostream& operator<<(std::ostream& out, const Interval& value)
{
	if(value.seconds < 10)
		out << value.minutes << ":0" << value.seconds;
	else
		out << value.minutes << ":" << value.seconds;
	return out;
}

#endif

