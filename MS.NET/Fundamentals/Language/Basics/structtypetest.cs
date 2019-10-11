using System;

enum RoomType {Economy, Business, Executive, Deluxe}

//value type
struct HotelRoom
{
	public int Number;
	public RoomType Category;
	public bool Taken;
}

static class Program
{
	private static void Print(in HotelRoom room)
	{
		string status = room.Taken ? "Occupied" : "Available";
		Console.WriteLine("Room {0} is of {1} class and is currently {2}", room.Number, room.Category, status);
		//room.Number += 1;
	}

	private static void Checkin(ref HotelRoom room)
	{
		if(!room.Taken)
			room.Taken = true;
	}

	public static void Main()
	{
		HotelRoom myroom;
		myroom.Number = 503;
		myroom.Category = RoomType.Business;
		myroom.Taken = false;

		Print(myroom);
		Console.WriteLine("Checking into room {0}", myroom.Number);
		Checkin(ref myroom);
		Print(myroom);
	}
}
