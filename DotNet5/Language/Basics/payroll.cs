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

		public Employee() : this(0, 0) {}

		public int Hours
		{
			get
			{
				return hours;
			}

			set
			{
				hours = value;
			}
		}

		public float Rate
		{
			get => rate;
			set => rate = value;
		}	

		public int Id => id;

		//public double GetIncome()
		public virtual double GetIncome()
		{
			int ot = hours > 40 ? hours - 40 : 0;
			
			return rate * (hours + ot);
		}		

		public static int CountActive() => count;
	}

	public class SalesPerson : Employee
	{
		public double Sales { get; set; }

		public SalesPerson(int h, float r, double s) : base(h, r)
		{
			Sales = s;
		}

		//public new double GetIncome()
		public override double GetIncome()
		{
			double amount = base.GetIncome();
			
			if(Sales > 5000)
				amount += 0.05 * Sales;

			return amount;
		}
	}
}
