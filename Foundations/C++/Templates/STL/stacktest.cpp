#include "interval.h"
#include <iostream>
#include <stack>
#include <list>

using namespace std;

int main(void)
{
	//stack<Interval> store;
	stack<Interval, list<Interval> > store;
	store.push(Interval(4, 31));
	store.push(Interval(7, 42));
	store.push(Interval(5, 13));
	store.push(Interval(3, 24));
	store.push(Interval(6, 55));

	while(!store.empty())
	{
		cout << store.top() << endl;
		store.pop();
	}
}

