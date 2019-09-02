#include "interval.h"
#include <iostream>
#include <string>

using namespace std;

template<typename V>
void PrintNamedValue(string name, V value)
{
	cout << name << " => " << value << endl;
}

template<>
void PrintNamedValue(string name, bool value) // explicit specialization of PrintNamedValue function template for V=bool
{
	cout << name << " => " << (value ? "true" : "false") << endl;
}

int main(void)
{
	PrintNamedValue("Jack", 43);
	PrintNamedValue("Jill", 23.4);
	PrintNamedValue("John", Interval(3, 45));
	PrintNamedValue("Jeff", true);
}

