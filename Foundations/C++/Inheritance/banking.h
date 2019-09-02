#ifndef BANKING_H
#define BANKING_H

namespace Banking
{
	class InsufficientFunds {};

	class Account
	{
	public:
		double Balance() const;
		virtual void Deposit(double) = 0;
		virtual void Withdraw(double) throw(InsufficientFunds) = 0;
		void Transfer(double, Account*) throw(InsufficientFunds);
		virtual ~Account(){}
	protected:
		double balance; //also visible in derived classes
	};

	class Profitable
	{
	public:
		virtual double Interest(short) const = 0;
		virtual ~Profitable(){}
	};

	//Factory functions
	Account* OpenCurrentAccount();

	Account* OpenSavingsAccount();

	void CloseAccount(Account*);
}

#endif

