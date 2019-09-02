#include "interval.h"
#include <iostream>
#include <vector>
#include <list>
#include <algorithm>

using namespace std;

int main(void)
{
	list<Interval> store;
	store.push_back(Interval(4, 31));
	store.push_back(Interval(7, 42));
	store.push_back(Interval(5, 13));
	store.push_back(Interval(3, 24));
	store.push_back(Interval(6, 55));

	vector<Interval> temp(store.size());
	copy(store.begin(), store.end(), temp.begin());
	sort(temp.begin(), temp.end());
	copy(temp.begin(), temp.end(), store.begin());

	for(list<Interval>::iterator i = store.begin(); i != store.end(); ++i)
		cout << *i << '\t' << i->GetTime() << endl;
	
}

