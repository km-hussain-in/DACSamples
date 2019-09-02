#include "interval.h"
#include <iostream>
#include <string>

using namespace std;

template<typename I, typename V>
class IndexedValue
{
public:
	void Bind(I idx, V val)
	{
		index = idx;
		value = val;
	}

	void Print() const
	{
		cout << index << " => " << value << endl;
	}
private:
	I index;
	V value;
};

template<>
class IndexedValue<string, bool> //full specialization of class template
{
public:
	void Bind(string idx, bool val)
	{
		index = idx;
		value = val;
	}

	void Print() const
	{
		cout << index << " => " << (value ? "true" : "false") << endl;
	}
private:
	string index;
	bool value;
};

int main(void)
{
	IndexedValue<string, double> a; //activating templated IndexedValue class for I=string, V=double
	a.Bind("Jack", 12.3);
	a.Print();

	IndexedValue<int, Interval> b;
	b.Bind(21, Interval(2, 30));
	b.Print();

	IndexedValue<string, bool> c; //activating from specialized IndexedValue class template
	c.Bind("Jill", false);
	c.Print();
}


