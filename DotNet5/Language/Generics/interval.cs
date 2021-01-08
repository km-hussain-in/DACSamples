partial class Interval : System.IComparable<Interval>
{
	public int Minutes { get; }
	public int Seconds { get; }

	public Interval(int min, int sec)
	{
		Minutes = min + sec / 60;
		Seconds = sec % 60;
	}

	public int GetTime() => 60 * Minutes + Seconds;

	public override string ToString() => $"{Minutes}:{Seconds:00}";
	
	public override int GetHashCode() => Minutes + Seconds;

	public override bool Equals(object other)
	{
		if(other is Interval that)
			return (this.Minutes == that.Minutes) && (this.Seconds == that.Seconds);
		return false;
	}

	public int CompareTo(Interval that)
	{
		return that.GetTime() - this.GetTime();
	}
}
