#include "interval.h"
#include <iostream>
#include <vector>

using namespace std;

int main(void)
{
	vector<Interval> store;
	store.push_back(Interval(4, 31));
	store.push_back(Interval(7, 42));
	store.push_back(Interval(5, 13));
	store.push_back(Interval(3, 24));
	store.push_back(Interval(6, 55));
	//store.push_front(Interval(1, 20));

	for(vector<Interval>::iterator i = store.begin(); i != store.end(); ++i)
		cout << *i << '\t' << i->GetTime() << endl;
	
	vector<Interval>::iterator j = store.begin();
	cout << "Third Interval = " << j[2] << endl;
}

