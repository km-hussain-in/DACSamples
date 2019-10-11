using FinanceLib;
using System;
using System.Runtime.InteropServices;

[ComImport]
[Guid("1A87402F-A9F3-449F-ACB3-714A9275BEE0")]
class LegacyLoan {}

class CarLoanScheme : ILoanScheme
{
	public float GetInterestRate(short period)
	{
		return 9 + 0.5f * (period / 3);
	}
}

static class Program
{
	[STAThread]
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		short n = short.Parse(args[1]);

		var loan = (ILoan) new LegacyLoan();

		try
		{
			loan.Acquire(p, n);
			Console.WriteLine("Installment for Home Loan: {0:0.00}", loan.GetInstallmentUsingRate(8.5f));		
			Console.WriteLine("Installment for Car Loan : {0:0.00}", loan.GetInstallmentForScheme(new CarLoanScheme())); //CCW of CarLoanScheme will be passed to COM method		
		}
		catch(COMException ex)
		{
			Console.WriteLine("Loan rejected: {0}", (LoanError)ex.HResult);
		}
	}
}