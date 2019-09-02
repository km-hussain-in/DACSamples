#include <iostream>
#include <string>

using namespace std;

class TaxPayer
{
public:
	virtual double AnnualIncome() const = 0;

	double IncomeTax() const
	{
		double free = 120000 + 30000 * (age >= 60);
		double extra = AnnualIncome() - free;

		return extra > 0 ? 0.15 * extra : 0;
	}

	virtual ~TaxPayer(){}

protected:
	TaxPayer(int a)
	{
		age = a;
	}

private:
	short age;
};

void Print(const string& name, const TaxPayer& person)
{
	cout << "Income Tax of "
		 << name
		 << " is "
		 << person.IncomeTax()
		 << endl;
}

class Employee : public TaxPayer
{
public:
	Employee(short ag, double sy) : TaxPayer(ag)
	{
		salary = sy;
	}

	double AnnualIncome() const
	{
		return 12 * salary + 25000;
	}
private:
	double salary;
};

class Dealer : public TaxPayer
{
public:
	Dealer(short ag, double ss) : TaxPayer(ag)
	{
		sales = ss;
	}

	double AnnualIncome() const
	{	
		return 0.15 * sales;
	}
private:
	double sales;
};

class SalesPerson : public Employee, public Dealer
{
public:
	SalesPerson(short ag, double sy, double ss) : Employee(ag, sy), Dealer(ag, ss)
	{
	}

	double AnnualIncome() const
	{
		return Employee::AnnualIncome() - 25000 + Dealer::AnnualIncome() / 3;
	}
};

int main(void)
{
	Employee jill(35, 23000);
	Dealer jack(65, 4000000);
	SalesPerson john(45, 18000, 2500000);

	Print("Jill the Employee", jill);
	Print("Jack the Dealer", jack);
	Print("John the SalesPerson", static_cast<Employee&>(john));

}


