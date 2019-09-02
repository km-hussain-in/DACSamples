#include "banking.h"
#include <iostream>

using namespace Banking;
using namespace std;

int main(void)
{
	Account* jack = OpenCurrentAccount();
	jack->Deposit(10000);

	Account* jill = OpenSavingsAccount();
	jill->Deposit(5000);

	double payment;
	cout << "Amount to transfer: ";
	cin >> payment;

	try
	{
		jill->Transfer(payment, jack);
		cout << "Transfer succeeded." << endl;
	}
	catch(InsufficientFunds)
	{
		cout << "Transfer failed due to lack of funds!" << endl;
	}

	cout << "Jack's Balance is " << jack->Balance() << endl;
	cout << "Jill's Balance is " << jill->Balance() << endl;

	CloseAccount(jill);
	CloseAccount(jack);
}

