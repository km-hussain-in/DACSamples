#include <stdio.h>

struct Employee
{
	int id;
	short hours;
	float rate;
};

double EmployeeGetIncome(const struct Employee* emp)
{
	double income = emp->hours * emp->rate;
	short ot = emp->hours - 180;

	//emp->id = 0;

	return income + 50 * (ot > 0) * ot;
}



int main(void)
{
	struct Employee jack = {101, 186, 52};
	struct Employee jill = {102, 175, 240};

	double jacksIncome = EmployeeGetIncome(&jack);
	double jillsIncome = EmployeeGetIncome(&jill);
	
	printf("Income of employee with ID %d is %.2lf\n", jack.id, jacksIncome);
	printf("Income of employee with ID %d is %.2lf\n", jill.id, jillsIncome);
}


