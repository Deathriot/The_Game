using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Witch_Tale.Monsters;

namespace The_Witch_Tale.Rooms.HiddenRooms.BehindFakeWallRooms
{
	public class TreassureGuard : Room
	{
		private bool _firstTimeVizited = true; // Первое посещение комнаты
		private bool _defeated = false; // Повержен ли страж
		private bool _firstTimeMagicWord = true; // Первое использование слова дай
		private bool _activated = false; // Проснулся ли страж, если да, при вхождении в команту сразу начинается бой

		public static bool DeadByGuard = false;
		public static bool DeadByGuardFirstTime = true;
		public TreassureGuard() : base(HiddenRoomType.TreassureGuard, 1, 5, true, 'x')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			if (_defeated)
			{
				Console.WriteLine("Место битвы уже остыло, здесь ничего нет, кроме груды камней, которая некогда была");
				Console.WriteLine("одним из божественных творений каменного бога.");
				return;
			}

			if(_activated && !_defeated)
			{
				Console.WriteLine("Пробужденный страж терпеливо ждет, пока вы еще раз попытаетесь пройти через него.");
				return;
			}

			if (_firstTimeVizited)
			{
				Console.WriteLine("Посреди комнаты стоит каменный истукан.");
				Console.WriteLine("Он спит вот уже сотню лет, однако лишь одолев его, вы сможете пройти в следующую комнату");
			}
			else
			{
				Console.WriteLine("Голем все так же спит, ожидая, пока у вас хватит смелости сразиться с ним...");
			}
			Console.WriteLine();
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			if (_activated)
			{
				Console.WriteLine("Страж незамедлительно прыгает на вас...");
				Console.ReadKey();
				if(Hero.Fight(new Guard()))
				{
					Console.WriteLine("Вы одолели стража. Пора узнать, что же он такое охранял.");
					_defeated= true;
				}
				else
				{
					DeadByGuard = true;
				}
				return;
			}

			Introduction();

			while (true)
			{
				ShowMenu();
				string answer = Console.ReadLine();
				Console.Clear();

				switch (answer)
				{
					case "1":
						{
							FirstAction(Hero);
							return;
						}
					case "2":
						{
							Console.WriteLine("Вполне здравая мысль...");
							return;
						}
					case "дай":
						{
							MagicWord();
							break;
						}
					default:
						{
							Console.WriteLine("Такой команды нет!");
							break;
						}
				}
			}
			
		}
		private void ShowMenu()
		{
			Console.WriteLine();
			Console.WriteLine("1 - Пробудить стража");
			Console.WriteLine("2 - Уйти, подобру-поздорову...");
		}
		private void Introduction()
		{
			if (_firstTimeVizited)
			{
				_firstTimeVizited = false;
				Console.WriteLine("Делать нечего - вам уж очень интересно, что там дальше");
				Console.WriteLine("Вы подходите к каменному гиганту...");
			}
			else
			{
				Console.WriteLine("Вы решили снова посетить каменного стража.");
				Console.WriteLine("Страж все так же неподвижно стоит, ожидая, пока вы не начнете наглеть...");
			}
			
		}
		private void FirstAction(Character hero)
		{
			Console.WriteLine("Как только вы дотронулись до хранителя тайн, комната начала вибрировать...");
			Console.WriteLine("Страж медленно выпрямился, его глаза вспыхнули синим огнем.");
			Console.WriteLine("Неумолимой поступью он движется к вам.");
			_activated = true;
			Console.ReadKey();
			if (hero.Fight(new Guard()))
			{
				FakeWall.GuardDefeated = true;
				Console.Clear();
				Console.WriteLine("У стража не было и шанса... Мало кто смог бы уничтожить порождение СтоунБрика с первой попытки.");
				Console.WriteLine("Вы упиваетесь победой - никто не сможет встать у вас на пути перед вашей миссией");
				hero.Levelup(50);
				Console.WriteLine("как бы то ни было, проход свободен.");
			}
			else
			{
				DeadByGuard = true;
			}
		}
		private void MagicWord()
		{
			if (_firstTimeMagicWord)
			{
				Console.WriteLine("Вы не знали, чего ожидать, но определенно что-то начало происходить.");
				Console.WriteLine("Страж покрылся синими рунами и затрясся");
				Console.WriteLine("Очевидно, божественная магия способна сопротивляться заклинанию Зилгадиуса... Однако...");
				Console.WriteLine("Несмотря на защитные руны, страж начал осыпаться, его железная броня начала крошиться и разваливаться");
				Console.WriteLine("Через несколько мнгновений все закончилось. Магия СтоунБрика, бережно хранящая сон стража, справилась с заклятием.");
				Console.WriteLine("Но броню истукану точно никто не вернет!");
				_firstTimeMagicWord = false;
				Guard.Weaked = true;
			}
			else
			{
				Console.WriteLine("Сколько бы вы более не повторяли волшебное слово, ничего не происходит.");
				Console.WriteLine("Видимо защита стража адаптировалась даже к такому заклинанию. Но что еще стоило ожидать от Богов?");
				Console.WriteLine("К вашему счастью, куски камня и разных сплавов все так же валяются вокруг стража и не собираются снова становится броней.");
			}
			Console.ReadKey();
		}

	}
}
