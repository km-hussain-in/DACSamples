#include "payroll2.h"
#include <iostream>
#include <typeinfo>

using namespace Payroll;
using namespace std;

double TotalSales(Employee* group[], int count)
{
	double total = 0;
	for(int i = 0; i < count; ++i)
	{
		SalesPerson* sp = dynamic_cast<SalesPerson*>(group[i]); //explicit downcasting
		if(sp)
			total += sp->GetSales();
	}
	return total;
}

int main(void)
{
	Employee* department[5];
	department[0] = new Employee(186, 52);
	department[1] = new Employee(175, 225);
	department[2] = new SalesPerson(190, 45, 60000); //implicit upcasting
	department[3] = new Employee(195, 65);
	department[4] = new SalesPerson(168, 56, 40000);

	cout << "Total Sales = "
		 << TotalSales(department, 5)
		 << endl;

	for(int i = 0; i < 5; ++i)
	{
		delete department[i];
	}

}



