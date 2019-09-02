#include <iostream>
#include <string>

using namespace std;

template<typename V, unsigned int M=64>
class FiniteStack
{
public:
	FiniteStack() : count(0){}

	bool Push(const V& value)
	{
		if(count < M)
		{
			items[count++] = value;
			return true;
		}

		return false;
	}

	bool Pop(V& value)
	{
		if(count > 0)
		{
			value = items[--count];
			return true;
		}

		return false;
	}

	typedef V* Iterator;

	Iterator Begin()
	{
		return &items[0];
	}

	Iterator End()
	{
		return &items[count];
	}

private:
	V items[M];
	int count;
};

template<typename I, typename P>
int PrintIf(I begin, I end, P check)
{
	int n = 0;

	for(I i = begin; i != end; ++i)
	{
		if(check(*i))
		{
			if(n++) cout << ", ";
			cout << *i;
		}

	}
	cout << endl;

	return n;

}

bool IsBig(string s)
{
	return s.size() > 6;
}

//functor - its object supports function-call operator
class IsBiggerThan
{
public:
	IsBiggerThan(int min) : limit(min){}

	bool operator()(int value) const
	{
		return value > limit;
	}
private:
	int limit;
};

int main(void)
{
	FiniteStack<string, 8> a;
	a.Push("Monday");
	a.Push("Tuesday");
	a.Push("Wednesday");
	a.Push("Thursday");
	a.Push("Friday");
	cout << "All strings in first stack" << endl;
	for(string e; a.Pop(e);)
		cout << e << endl;
	a.Push("Monday");
	a.Push("Tuesday");
	a.Push("Wednesday");
	a.Push("Thursday");
	a.Push("Friday");
	cout << "Big strings: ";
	PrintIf(a.Begin(), a.End(), IsBig);

	FiniteStack<int> b;
	b.Push(31);
	b.Push(52);
	b.Push(23);
	b.Push(74);
	b.Push(65);
	b.Push(46);
	cout << "All integers in second stack" << endl;
	for(FiniteStack<int>::Iterator i = b.Begin(); i != b.End(); ++i)
		cout << *i << endl;
	cout << "Big integers: ";
	PrintIf(b.Begin(), b.End(), IsBiggerThan(50));		

}

