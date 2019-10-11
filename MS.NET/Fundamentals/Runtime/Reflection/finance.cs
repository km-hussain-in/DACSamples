namespace Finance
{
	using System;

	public interface ILoanPolicy
	{
		float GetInterestRate(double amount, int period);
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class MaxDurationAttribute : Attribute
	{
		public int Limit {get; set;}

		public MaxDurationAttribute(int value = 5)
		{
			Limit = value;
		}
	}

	[MaxDuration]
	public class EducationLoan : ILoanPolicy
	{
		public float GetInterestRate(double p, int n)
		{
			return 6;
		}
	}

	public class HomeLoan : ILoanPolicy
	{
		public float GetInterestRate(double p, int n)
		{
			return n < 10 ? 8 : 9;
		}
	}

	[MaxDuration(4)] //[MaxDuration(Limit=4)]
	public class PersonalLoan : ILoanPolicy
	{
		public float GetInterestRate(double p, int n)
		{
			return p < 100000 ? 9 : 10;
		}

		public float GetInterestRateForEmployees(double p, int n)
		{
			return p < 500000 ? 6.5f : 7.5f;
		}

	}
	
	[Serializable]
	public class BusinessLoan
	{
		public float RateOfInterest(double p, int n)
		{
			float r = p < 1000000 ? 10.5f : 11.5f;
			
			return r + 0.5f * (n / 3);
		}

	}
	
}
