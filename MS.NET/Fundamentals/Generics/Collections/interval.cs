partial class Interval : System.IComparable<Interval>
{
	private int min, sec;

	public Interval(int m, int s)
	{
		min = m + s / 60;
		sec = s % 60;
		OnCreate();
	}

	public int Time => 60 * min + sec;

	public int Minutes => min;

	public int Seconds => sec;

	partial void OnCreate();

	public override string ToString()
	{
		return $"{min}:{sec:00}";
	}

	public override int GetHashCode() => min + sec;

	public override bool Equals(object other)
	{
		if(other is Interval that)
		{
			return (this.min == that.min) && (this.sec == that.sec);
		}
	
		return false;
	}

	public int CompareTo(Interval that)
	{
		return this.Time - that.Time;
	}
}


