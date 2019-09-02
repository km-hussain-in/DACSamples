#include "interval.h"
#include <iostream>
#include <queue>
#include <vector>
#include <functional>

using namespace std;

int main(void)
{
	//priority_queue<Interval> store;
	priority_queue<Interval, vector<Interval>, greater<Interval> > store;
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

