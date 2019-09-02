#include "interval.h"
#include <iostream>
#include <string>

using namespace std;

template<typename I, typename V>
class IndexedValue // class template
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

template<typename V>
class IndexedValue<string, V> //partial specialization of class template
{
public:
	void Bind(string idx, V val)
	{
		index = idx;
		value = val;
	}

	void Print() const
	{
		cout << "'" << index << "' => " << value << endl;
	}
private:
	string index;
	V value;
};

int main(void)
{
	IndexedValue<string, double> a; //activating from specialized IndexedValue class
	a.Bind("Jack", 12.3);
	a.Print();

	IndexedValue<int, Interval> b;
	b.Bind(21, Interval(2, 30));
	b.Print();

	IndexedValue<string, int> c;
	c.Bind("Jill", 234);
	c.Print();
}


