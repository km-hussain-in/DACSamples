namespace Payroll
{
	public class Employee
	{
		private int id;
		internal int hours;
		protected float rate;
		static int count;

		public Employee(int h, float r)
		{
			id = 101 + count++;	
			hours = h;
			rate = r;
		}

		public Employee() : this(0, 40) {}

		public int Id => id;

		public int Hours
		{
			get => hours;
			set => hours = value;
		}

		public float Rate
		{
			get => rate;
			set => rate = value;
		}

		public double GetIncome()
		{
			double income = hours * rate;
			int ot = hours - 180;
		
			if(ot > 0)
				income += 50 * ot;

			return income;
		}

		public static int CountInstances()
		{
			return count;
		}
	}

	public class SalesPerson : Employee
	{
		public double Sales {get;}

		public SalesPerson(int h, float r, double s) : base(h, r)
		{
			Sales = s;
		}

		//hiding (by signature) method of base class
		public new double GetIncome()
		{
			double income = base.GetIncome();

			if(Sales >= 20000)
				income += 0.05 * Sales;

			return income;
		}
	}
		
}

