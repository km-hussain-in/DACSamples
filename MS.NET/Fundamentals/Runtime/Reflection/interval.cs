partial class Interval
{
	private int min, sec;

	private static int count;

	public int Id {get;}

	public Interval(int m, int s)
	{
		min = m + s / 60;
		sec = s % 60;
		Id = ++count;
		OnCreate();
	}

	public int GetTime() => 60 * min + sec;

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

}


