using System;

namespace Finance
{
	[AttributeUsage(AttributeTargets.Class)]
	public class MaxDurationAttribute : Attribute
	{
		public int Limit { get; set; }

		public MaxDurationAttribute(int duration = 5) => Limit = duration;
	}


	[MaxDuration(12)]
	public class HomeLoan
	{
		public float UseInterestRate(int period) {
			return period < 10 ? 9.25f : 8.75f;
		}

		public float UseInterestRateForWomen(int period) {
			return UseInterestRate(period) - 0.25f;
		}
	}

	[MaxDuration]
	public class PersonalLoan
	{
		public float UseInterestRate(int period) {
			return 10 + 0.5f * (period / 3);
		}

		public float UseInterestRateForEmployees(int period) {
			return 0.75f * UseInterestRate(period);
		}
	}

	public class BusinessLoan
	{
		public float UseInterestRate(int period) {
			return 12.5f;
		}
	}


	[MaxDuration(Limit = 4)]
	public class CarLoan
	{
		public float UseInterestRate(int period) {
			return 10.75f + 0.25f * period; 
		}
	}

}



