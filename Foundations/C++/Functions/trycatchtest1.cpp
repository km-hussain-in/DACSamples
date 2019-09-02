#include <iostream>
#include <string>

using namespace std;

struct BadName
{
};

int Lookup(string name) throw(string, BadName)
{
	string names[] = {"jack", "jill", "john", "jane"};

	if(name.size() < 4)
	{
		BadName bn;
		throw bn;
	}

	for(int i = 0; i < 4; ++i)
	{
		if(names[i] == name)
			return i;
	}

	throw name;
}

void Run(void) throw()
{
	int balances[] = {3000, 4000, 6000, 5000};

	string name;
	cout << "Name: ";
	cin >> name;

	try
	{
		int i = Lookup(name);
		cout << "Balance: " << balances[i] << endl;
	}
	catch(string n)
	{
		cout << "Cannot find " << n << endl;
	}
	catch(BadName)
	{
		cout << "Name too small" << endl;
	}
}

int main(void)
{
	cout << "Welcome to our bank" << endl;
	Run();
	cout << "Goodbye" << endl;
}


