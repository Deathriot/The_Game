using System;

namespace The_Witch_Tale
{
	public enum RoomType
	{
		Wall = 0,
		Begin = 1,
		JustRoom = 2,
		Mama = 3,
		Daddy = 4,
		Npc = 5,
		EnemyNpc = 6,
		HealRoom = 7,
		AltarsRoom = 8,
		Enemy1 = 9,
		RudeDoor = 10,
		Enemy2 = 11,
		Empty2 = 12,
		Phontain = 13,
		Enemy3 = 14,
		Boss = 15,
		Win = 16,
		SecretRoom = 17,
		FakeWall = 18,
		Teleport = 100,
		EmptyRoom = 1000
	}
	public enum HiddenRoomType
	{
		EmptyRoom1 = 1,
		EmptyRoom2 = 2,
		EmptyRoom3 = 3,
		EmptyRoom4 = 4,
		TreassureGuard = 5,
		Treassure = 6
	}
	public abstract class Room
	{
		public readonly RoomType RoomType;
		public readonly HiddenRoomType HiddenRoomType;
		public int X;
		public int Y;
		public readonly char Symb;
		public bool Access;

		public Room(RoomType roomType, int x, int y, bool access, char symb)
		{
			RoomType = roomType;
			X = x;
			Y = y;
			Symb = symb;
			Access = access;
		}
		public Room(HiddenRoomType hiddenRoomType, int x, int y, bool access, char symb)
		{
			HiddenRoomType = hiddenRoomType;
			X = x;
			Y = y;
			Symb = symb;
			Access = access;
		}

		public virtual void Do(Character Hero, RoomsManager rooms)
		{
			Console.WriteLine("Ничего не происходит...");
		}

		public abstract void Info(Character hero, RoomsManager rooms);
	}
}
