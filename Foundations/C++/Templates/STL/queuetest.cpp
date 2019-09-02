#include "interval.h"
#include <iostream>
#include <queue>
#include <list>

using namespace std;

int main(void)
{
	//queue<Interval> store;
	queue<Interval, list<Interval> > store;
	store.push(Interval(4, 31));
	store.push(Interval(7, 42));
	store.push(Interval(5, 13));
	store.push(Interval(3, 24));
	store.push(Interval(6, 55));

	while(!store.empty())
	{
		cout << store.front() << endl;
		store.pop();
	}
}

