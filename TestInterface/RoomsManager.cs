using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Witch_Tale.Rooms;
using The_Witch_Tale.Rooms.HiddenRooms;

namespace The_Witch_Tale
{
	public sealed class RoomsManager
	{
		public int MaxX = 5;
		public int MaxY = 5;
		public int CurrentX = 1;
		public int CurrentY = 1;

		public static bool FightWasLost = false; // Проверка, был ли проигран только что бой
		public static bool DeadFirstTime = true; // Маркер того, что смерть первая 

		Room[,] MapArray;
		public RoomsManager()
		{
			MapArray = new Room[MaxY + 1, MaxX + 1];

			AddRoom(new Begin());
			AddRoom(new JustRoom());
			AddRoom(new Mama());
			AddRoom(new Daddy());
			AddRoom(new Npc());
			AddRoom(new EnemyNpc());
			AddRoom(new HealRoom());
			AddRoom(new AltarsRoom());
			AddRoom(new Enemy1());
			AddRoom(new RudeDoor());
			AddRoom(new Enemy2());
			AddRoom(new Empty2());
			AddRoom(new Phontain());
			AddRoom(new Enemy3());
			AddRoom(new Boss());
			AddRoom(new Win());
		}

		public void Map()
		{
			for (int y = MaxY; y >= 0; y--)
			{
				for (int x = 0; x <= MaxX; x++)
				{
					Room room = MapArray[x, y];

					if (room.X == CurrentX && room.Y == CurrentY)
					{
						Console.Write("[¤]");
						continue;
					}

					if (!room.Access && room.RoomType != RoomType.Wall)
					{
						Console.Write("   ");
					}
					else
					{
						Console.Write($"[{room.Symb}]");
					}
				}
				Console.WriteLine();
			}
		}


		/// <summary>
		/// Создает новую комнату в в список _rooms, если комната уже существует на этих координатах, ПЕРЕЗАПИСЫВАЕТ ее
		/// </summary>
		/// <param name="room"></param>
		public void AddRoom(Room room)
		{
			try
			{
				MapArray[room.X, room.Y] = room;
			}
			catch
			{
				Console.WriteLine("ОШИБКА! Обратитесь к разработчику!!!");
			}
		}

		public Room FindRoom()
		{
			try
			{
				return MapArray[CurrentX, CurrentY];
			}
			catch
			{
				return new Wall();
			}
		}

		public Room FindRoom(RoomType room)
		{
			foreach (Room rooms in MapArray)
			{
				if (rooms.RoomType == room)
				{
					return rooms;
				}
			}
			return null;
		}

		/// <summary>
		/// Заполняет все пустые элементы списка _rooms стенами
		/// </summary>
		public void SelfCheck()
		{
			for (int t = 0; t <= MaxY; t++)
			{
				for (int j = 0; j <= MaxX; j++)
				{
					Room find = null;
					find = MapArray[t, j];
					
					if (find == null)
					{
						find = new Wall();
						find.X = t;
						find.Y = j;

						MapArray[t, j] = find;
					}
				}
			}
		}

		/// <summary>
		/// Для разраба: разблокирует все комнаты
		/// </summary>
		public void Cheat()
		{
			foreach (Room room in MapArray)
			{
				room.Access = true;
			}
		}
	}
}
