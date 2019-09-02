#define _TESTING
#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double AverageIncome(Employee* group[], int count)
{
	double total = 0;
	for(int i = 0; i < count; ++i)
	{
		total += group[i]->GetIncome();
	}
	return total / count;
}

int main(void)
{
	Employee* department[5];
	department[0] = new Employee(186, 52);
	cout << "-----------------" << endl;
	department[1] = new Employee(175, 225);
	cout << "-----------------" << endl;
	department[2] = new SalesPerson(190, 45, 60000); //implicit upcasting
	cout << "-----------------" << endl;
	department[3] = new Employee(195, 65);
	cout << "-----------------" << endl;
	department[4] = new SalesPerson(168, 56, 40000);
	cout << "-----------------" << endl;

	cout << "Average Income = "
		 << AverageIncome(department, 5)
		 << endl;

	for(int i = 0; i < 5; ++i)
	{
		delete department[i];
		cout << "-----------------" << endl;
	}

}



