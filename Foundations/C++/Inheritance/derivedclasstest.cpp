#include "payroll1.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double IncomeTax(const Employee& m)
{
	double i = m.GetIncome(); //Employee::GetIncome(&m)
	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

double IncomeTax(const SalesPerson& m)
{
	double i = m.GetIncome(); //SalesPerson::GetIncome(&m)
	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

int main(void)
{
	Employee jack;
	jack.SetHours(186);
	jack.SetRate(52);
	cout << "Jack's income is "
		 << jack.GetIncome()
		 << " and tax is "
		 << IncomeTax(jack)
		 << endl;

	SalesPerson jill(186, 52, 74000);
	cout << "Jill's income is "
		 << jill.GetIncome()
		 << " and tax is "
		 << IncomeTax(jill)
		 << endl;
}

