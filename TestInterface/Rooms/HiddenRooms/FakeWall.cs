using System;
using The_Witch_Tale.Rooms.HiddenRooms.BehindFakeWallRooms;

namespace The_Witch_Tale.Rooms.HiddenRooms
{
	public class FakeWall : Room
	{
		public static bool GuardDefeated = false; // Проверка, был ли повержен страж

		int _currentY = 0;
		Room[] AdditionalRooms;


		public FakeWall() : base(RoomType.FakeWall, 3, 0, true, '?')
		{
			AdditionalRooms = new Room[6];
			AdditionalRooms[0] = new EmptyRoom1();
			AdditionalRooms[1] = new EmptyRoom2();
			AdditionalRooms[2] = new EmptyRoom3();
			AdditionalRooms[3] = new EmptyRoom4();
			AdditionalRooms[4] = new TreassureGuard();
			AdditionalRooms[5] = new Treassure();
		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("Перед вами стена. Правда какая-то подозрительная");
		}
		public override void Do(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("Стена и правда оказалась фальшивой - голоса кирпичных детей не врали.");
			Console.WriteLine("Единственное, что было за муляжом - рычаг. Вы без раздумий потянули за него.");
			Console.WriteLine("Что-то погремело, поскрипело и перед стена перед вами начала уходить вниз.");
			Console.WriteLine("Перед вами открылся длинный коридор...");
			Console.ReadKey();
			Console.WriteLine();

			rooms.CurrentX = 10; //Костыль чтобы карта не показывала больше игрока

			while (true)
			{
				AdditionalMap(hero, rooms);
				Movement(hero, rooms);

				if (_currentY == -1)
				{
					rooms.CurrentX = 3;
					_currentY = 0;
					return;
				}

				if (_currentY == 6)
				{
					Console.WriteLine("перед вами стена!");
					_currentY = 5;
					continue;
				}

				if (_currentY == 5 && !GuardDefeated)
				{
					Console.WriteLine("Вы не моежет попасть сюда, пока не одолеете стража!");
					_currentY = 4;
				}

				Console.WriteLine();
				AdditionalRooms[_currentY].Info(hero, rooms);
				Console.WriteLine();
			}
		}

		private void AdditionalMap(Character hero, RoomsManager rooms)
		{
			rooms.Map();

			for (int i = 0; i <= 5; i++)
			{
				Room room = AdditionalRooms[i];

				if (_currentY == i)
				{
					Console.WriteLine("         [¤]");
					continue;
				}

				Console.WriteLine($"         [{room.Symb}]");
			}
		}
		private void Movement(Character person, RoomsManager rooms)
		{
			while (true)
			{
				ConsoleKey move = Console.ReadKey().Key;
				Console.Clear();

				switch (move)
				{
					case ConsoleKey.W:
					case ConsoleKey.UpArrow:
						{
							_currentY--;
							return;
						}
					case ConsoleKey.D:
					case ConsoleKey.RightArrow:
						{
							Console.WriteLine("Перед вами стена!");
							return;
						}
					case ConsoleKey.S:
					case ConsoleKey.DownArrow:
						{
							_currentY++;
							return;
						}
					case ConsoleKey.A:
					case ConsoleKey.LeftArrow:
						{
							Console.WriteLine("Перед вами стена!");
							return;
						}
					case ConsoleKey.E:
					case ConsoleKey.Enter:
						{
							AdditionalRooms[_currentY].Do(person, rooms);
							return;
						}
					case ConsoleKey.I:
						{
							person.PersonInfo();
							return;
						}
					case ConsoleKey.J:
						{
							person.QuestInfo();
							return;
						}
					default:
						{
							Console.WriteLine("Такой команды нет!");
							Console.WriteLine();
							break;
						}
				}
			}
		}
	}
}
