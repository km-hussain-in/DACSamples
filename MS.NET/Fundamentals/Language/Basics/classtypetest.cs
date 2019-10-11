using System;

enum RoomType {Economy, Business, Executive, Deluxe}

//reference type
class HotelRoom
{
	public int Number;
	public RoomType Category;
	public bool Taken;
}

static class Program
{
	private static void Print(HotelRoom room)
	{
		string status = room.Taken ? "Occupied" : "Available";
		Console.WriteLine("Room {0} is of {1} class and is currently {2}", room.Number, room.Category, status);
	}

	private static void Checkin(HotelRoom room)
	{
		if(!room.Taken)
			room.Taken = true;
	}

	public static void Main()
	{
		HotelRoom myroom = new HotelRoom();
		myroom.Number = 503;
		myroom.Category = RoomType.Business;
		myroom.Taken = false;

		Print(myroom);
		Console.WriteLine("Checking into room {0}", myroom.Number);
		Checkin(myroom);
		Print(myroom);
	}
}
