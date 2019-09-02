#include "interval.h"
#include <iostream>
#include <vector>
#include <algorithm>
#include <functional>

using namespace std;

class IntervalComparison
{
public:
	bool operator()(const Interval& x, const Interval& y) const
	{
		return x.Seconds() <  y.Seconds();
	}
};

int main(void)
{
	vector<Interval> store;
	store.push_back(Interval(4, 31));
	store.push_back(Interval(7, 42));
	store.push_back(Interval(5, 13));
	store.push_back(Interval(3, 24));
	store.push_back(Interval(6, 55));

	//sort(store.begin(), store.end());
	//sort(store.begin(), store.end(), greater<Interval>());
	sort(store.begin(), store.end(), IntervalComparison());

	for(vector<Interval>::iterator i = store.begin(); i != store.end(); ++i)
		cout << *i << '\t' << i->GetTime() << endl;
	
}

