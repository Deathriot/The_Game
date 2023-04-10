using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class HealRoom : Room
	{
		bool _firstTimeVizited = true; // Первое посещение комнаты
		int _countOfSips = 2; // Количество глотков

		
		public HealRoom() : base(RoomType.HealRoom, 3, 2, true, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			if (_firstTimeVizited)
			{
				Console.WriteLine("Что за чудесный вид! Скорее туда!");
			}
			else
			{
				Console.WriteLine("Перед вами раскрывается чудная картина...");
			}
		}
		void Introduction()
		{
			if (_firstTimeVizited)
			{
				Console.WriteLine("Вы даже и представить себе не могли, что в этом тёмнои сыром подземелье можете встретить такую красоту");
				Console.WriteLine("Это настоящий оазис среди бушующей жаркой пустыни");
				Console.WriteLine("Посреди журчащих ручейков и лилий вы видете кубок, доверху наполненной притягательной сияющей водой");
				Console.WriteLine("В этой воде вы ясно чувствуете присутствие магии света");
				Console.WriteLine("Выпив из кубка, вы полностью восстановите здоровье, однако воды в нем хватит лишь на два раза.");
				_firstTimeVizited = false;
			}
			else
			{
				Console.WriteLine("Комната встречает вас запахом росы.");
				Console.WriteLine("Вам не хочется отсюда уходить...");
			}

		}
		void FirstAction(Character hero)
		{
			Console.WriteLine("Вы решаетесь подойти к кубку и сделать из него глоток...");
			Console.WriteLine();

			if (_countOfSips > 0)
			{
				if (hero.Health >= hero.MaxHealth)
				{
					Console.WriteLine("...А потом подумали - а зачем пить, если вы и так полностью здоровы?");
				}
				else
				{
					Console.WriteLine("Вы взяли в руки кубок и сделали самый большой глоток, который вы когда-либо делали.");
					Console.WriteLine("Вы чувствуете, как раны затягиваются, а на душе становится очень тепло и... мягко.");
					Console.WriteLine("Как жаль, что воды в нем так мало.");
					int difference = hero.MaxHealth - hero.Health;
					hero.HealthRegenerate(difference);
					_countOfSips--;
				}
			}
			else
			{
				Console.WriteLine("...К сожалению, воды в кубке больше осталось");
			}

		}
		void ShowMenu()
		{
			Console.WriteLine("1 - Выпить из кубка");
			Console.WriteLine("0 - Выход");
		}
		public override void Do(Character hero, RoomsManager rooms)
		{
			Introduction();
			ShowMenu();

			ConsoleKey answer = Console.ReadKey().Key;
			Console.Clear();

			switch (answer)
			{
				case ConsoleKey.D1:
					{
						FirstAction(hero);
						break;
					}
				case ConsoleKey.D0:
					{
						Console.WriteLine("вы нехотя покидаете комнату");
						Console.WriteLine();
						return;
					}
				default:
					{
						Console.WriteLine("Комната, конечно, замечательная, но вашего бреда не понимает");
						break;
					}
			}
		}
	}
}
