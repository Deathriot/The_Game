using MyTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Witch_Tale.Monsters;

namespace The_Witch_Tale.Rooms
{
	public class Daddy : Room
	{
		bool _firstTimeVizited = true; // Первое посещение комнаты

		public static bool DeadByDaddy = false; // Смерть от папы-кирпича
		public static bool DeadByDaddyFirstTime = true; // Самая первая смерть от папы-кирпича
		public Daddy() : base(RoomType.Daddy, 4, 1, false, ' ')
		{

		}
		void Introduction(Character hero)
		{
			if (_firstTimeVizited)
			{
				Console.WriteLine("Мрак окутывает вас. Вы ничего не можете увидеть.");
				Console.WriteLine("Слышен лишь тихий плеск капающей с потолка воды.");
				Console.WriteLine("Прошло несколько минут, и выши глаза почти привыкли к темноте, но до сих пор ничего не происходит...");
				Console.WriteLine("Как вдруг, вы слышит грохот. Грохот размеренно появлялся каждую секнду, заполняя на мнгновение собой всю комнату");
				Console.WriteLine("как вы и подумали - это были шаги. Шаги чего-то очень большого и тяжелого");
				Console.WriteLine("Вы увидели его глаза - да, и злого.");
				Console.WriteLine("Огромного размера кирпич приближается к вам...");
				Console.WriteLine("Кажется вам пиздец");
				Mama.FightDaddy = true;
				_firstTimeVizited = false;
			}
			else
			{
				Console.WriteLine("Вы видете огромного размера кирпич, рука которого сжимает еще один увесистый кирпич");
				Console.WriteLine("Очевидно, этот кирпич поменьше не его сын, а довольно опасное оружие");
				Console.WriteLine();
				Console.WriteLine("Вы не успели и пикнуть, как гигантский разъяренный кирпич, издав боевой клич, бежит на вас");
			}
			Console.ReadKey();
			PrintPicture.DaddyBrick();
		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			if (_firstTimeVizited)
			{
				Console.WriteLine("От этой комнаты вам почему-то не по душе.");
			}
			else
			{
				Console.WriteLine("Бежал бы ты отсюда");
				Console.WriteLine("По крайней мере, если ты не знаешь, как его одолеть.");
			}
			FakeAction(hero, rooms);
		}
		public override void Do(Character hero, RoomsManager rooms)
		{
			Introduction(hero);

			if (!hero.Fight(new DaddyStone()))
			{
				DeadByDaddy = true;
			}
			else
			{
				Console.WriteLine("Кирпич помер");
			}
		}

		/// <summary>
		/// Фальшивая реализация команд, не дает двигаться
		/// </summary>
		/// <param name="hero"></param>
		/// <param name="rooms"></param>
		void FakeAction(Character hero, RoomsManager rooms)
		{
			while (true)
			{
				Console.WriteLine();
				rooms.Map();

				ConsoleKey move = Console.ReadKey().Key;
				Console.Clear();
				switch (move)
				{
					case ConsoleKey.W:
					case ConsoleKey.UpArrow:
						{
							Write.Magenta("Какая-то /магия/ не дает вам выйти!");
							break;
						}
					case ConsoleKey.D:
					case ConsoleKey.RightArrow:
						{
							Write.Magenta("Какая-то /магия/ не дает вам выйти!");
							break;
						}
					case ConsoleKey.S:
					case ConsoleKey.DownArrow:
						{
							Write.Magenta("Какая-то /магия/ не дает вам выйти!");
							break;
						}
					case ConsoleKey.A:
					case ConsoleKey.LeftArrow:
						{
							Write.Magenta("Какая-то /магия/ не дает вам выйти!");
							break;
						}

					case ConsoleKey.E:
					case ConsoleKey.Enter:
						{
							Do(hero, rooms);
							return;
						}
					case ConsoleKey.I:
						{
							hero.PersonInfo();
							break;
						}
					case ConsoleKey.J:
						{
							hero.QuestInfo();
							break;
						}
					default:
						{
							Console.WriteLine("Такой команды нет!");
							Console.WriteLine();
							rooms.Map();
							break;
						}
				}
			}
		}
	}
}
