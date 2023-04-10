using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class JustRoom : Room
	{
		bool _firstTimeVizited = true; // Первое посещение комнаты
		bool _chestFound = false;           // Проверка найден ли сундук
		bool _firstTime1 = true;       // Первая активация варианта 1
		bool _firstTime2 = true;       // Первая активация варианта 2
		bool _firstTime3 = true;       // Первая активация варианта 3
		bool _firstTime4 = true;       // Первая активация варианта 4
		bool _firstTimeMagicWord = true;    // Первая активация слова дай
		bool _keyFound = false;        // Найден ли ключ от сундука
		bool _doorKeyFound = false;    // Найден ли ключ от двери
		bool _doorIsopen = false;      // Открыта ли дверь в следующую комнату

		public JustRoom() : base(RoomType.JustRoom, 2, 1, true, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			if (_firstTimeVizited)
			{
				Console.WriteLine("Вы видите в облезлую комнату");
				Console.WriteLine("Такое ощущение, что в нее не заходи несколько веков - повсюду паутина, пыль и пахнет смесью сырости, плесени и ржавчины");
				Console.WriteLine("Однако никакой опасности вы в ней не чуяте.");
			}
			else
			{
				Console.WriteLine("Вас встречает уже вам знакомая комната со шкафом и пауками.");
			}
		}
		void Introduction()
		{
			if (!_doorIsopen)
			{
				if (_firstTimeVizited)
				{
					Console.WriteLine("Заходя в странного вида комнату, вы видете грязь, пыль и несколько предметов, более достойные для рассмотрения");
					Console.WriteLine("Не очень понятно, откуда все это в таком-то месте, кажется, здесь кто-то жил.");
					Console.WriteLine("Кто-то очень бедный и очень давно");
					Console.WriteLine("Вы видете перед собой 5 предметов:");
					_firstTimeVizited = false;
				}
				else
				{
					Console.WriteLine("Уже вам знакомая разваливающаяся комната встречает вас своей вонью пыли и ржавчины");
				}
			}
			else
			{
				Console.WriteLine("Наверное в этой комнате больше делать нечего - ключ уже найден");
				Console.WriteLine("Или же нет?");
			}
			Console.WriteLine();
		}
		void ShowMenu()
		{
			Console.WriteLine();
			Console.WriteLine("1 - Шкаф");
			Console.WriteLine("2 - Кирпич");
			Console.WriteLine("3 - Окно с безвкусной занавеской");
			Console.WriteLine("4 - Ржавый сундук");
			Console.WriteLine("5 - Dверь");
			Console.WriteLine("0 - Уйти отсюда");
			Console.WriteLine();
			Console.WriteLine("Что вы хотите осмотреть?");

		}
		void FirstAction(Character hero)
		{
			if (_firstTime1)
			{
				Console.WriteLine("Вы открываете шкаф и видите там три романа Дарьи Донцовой");
				Console.WriteLine("Потратив несколько часов своей жизни за чтением, вы узнаете много нового");
				Console.WriteLine("Однако читать без фейспалмов 'это' сложно, у вас теперь болит голова");
				Console.WriteLine("Вы отбили себе лоб рукой и потеряли 1 здоровье!");
				hero.Levelup(15);
				hero.Health--;
				_firstTime1 = false;
			}
			else
			{
				Console.WriteLine("В шкафу все те же книги, читать их еще раз у вас нет желания");
			}
			if (_chestFound && !_keyFound)
			{
				Console.WriteLine();
				Console.WriteLine("Ключа тут нигде не видно");
			}
		}
		void SecondAction(Character hero)
		{
			if (!_chestFound)
			{
				Console.WriteLine("Это обычный кирпич, круто, правда?");
			}
			else
			{
				if (_firstTime2)
				{
					Console.WriteLine("может в этом кирпиче каким-то образом спрятан ключ?");
					Console.WriteLine();
					Console.WriteLine("нажмите любую клавишу чтобы бросить кирпич об стену");
					Console.ReadKey();
					Console.WriteLine("Вы со всей дури бросаете кирпич и попадаете в окно, порвав 'занавеску', кирпич раскололся пополам");
					Console.WriteLine("Из кирпича выпал ключ!");
					Console.WriteLine("Вы подбираете ключ");
					_keyFound = true;
					_firstTime2 = false;
				}
				else
				{
					Console.WriteLine("Вместо кирпича осталась лишь парочка его кусков и много новой пыли, только красной");
				}
			}
		}
		void ThirdAction(Character hero)
		{
			if (_firstTime2)
			{
				if (_firstTime3)
				{
					Console.WriteLine("На окне сплетена изысканная паутина, на секунду вы ее перепутали с занавеской");
					Console.WriteLine("Вы видете как семья пушистых пауков принимает утренний завтрак");
					Console.WriteLine("Это так мило, что на душе становится тепло");
					hero.HealthRegenerate(3);
					_firstTime3 = false;
				}
				else
				{
					Console.WriteLine("Пауки все так же пируют, но это уже не вызывает такого же умиления, как в первый раз");
				}
				if (_chestFound)
				{
					Console.WriteLine();
					Console.WriteLine("Тут ключа нет, вот бы вы могли спросить у пауков..");
				}
			}
			else
			{
				Console.WriteLine("Кажется на окне больше никто не живет..");
				Console.WriteLine("Вините в этом только себя");
			}
		}
		void FourthAction(Character hero)
		{
			if (!_doorKeyFound)
			{
				if (!_keyFound)
				{
					if (_firstTime4)
					{
						Console.WriteLine("Вы видете старый пыльный сундук с проржавевшим замком, он довольно тяжелый");
						Console.WriteLine("Можент там есть что-то интересное? Надо попробовать найти ключ");
						_chestFound = true;
						_firstTime4 = false;
					}

					else
					{
						Console.WriteLine("Старый сундук стоит на своем месте, он все так же не открыт..");
					}
				}
				else
				{
					Console.WriteLine("воспользовавшись ключем, вы открыли сундук!");
					Console.WriteLine("Удивительно, но в сундуке лежит еще один ключ... может он от двери?");
					_doorKeyFound = true;
				}
			}
			else
			{
				Console.WriteLine("Сундук все такой же стремный, ржавый и потёртый. Только теперь еще и открытый");
			}
		}
		void FivthAction(Character hero, RoomsManager rooms)
		{
			if (!_doorKeyFound)
			{
				Console.WriteLine("Перед вами дверь, в таком же состоянии что и все в этой комнате, на нее больно смотреть");
				Console.WriteLine("Вы педергали что-то напоминающее ручку - дверь явно заперта");
			}
			else
			{
				Console.WriteLine("Вы открыли дверь и можете пройти в комнату правее!");
				_doorIsopen = true;
				rooms.FindRoom(RoomType.Mama).Access = true;
			}
		}
		void MagicWord(Character hero)
		{
			if (_firstTimeMagicWord)
			{
				Console.WriteLine("Комната начинает вибрировать, такое ощущение, что каждый кирпичик в этой комнате, включая тот, что валяется в углу, начинает петь каждый на свой лад");
				Console.WriteLine("Судя по тонам вибраций, комната умоляет вас свалить куда подальше, с особым рвением это делает тот валяющийся кирпич");
				Console.WriteLine("После нескольких минут такого концерта, комната умолкает, и в ней становится еще тише, чем было до этого");
				Console.WriteLine("Под конец, раздается писк:");
				Console.WriteLine("Разрушив статую СтоунБрика, ты получишь больше, чем потеряешь!");
				Console.WriteLine();
				Console.WriteLine("Вы чувствуете, что это непонятное сообщение было буквально выпытано из комнаты, она безуспешно пыталась бороться с консольным заклятием");
				Console.WriteLine("Однако что оно значит?");
				_firstTimeMagicWord = false;
			}
			else
			{
				Console.WriteLine("Вы чувствуете, что волшебное слово опять приносит боль комнате, однако ничего более она не желает вам говорить...");
			}
		}
		void DefaultAction(Character hero)
		{
			Console.WriteLine("не очень понятно, что вы хотите сделать");
		}
		public override void Do(Character hero, RoomsManager rooms)
		{
			Introduction();
			while (true)
			{
				ShowMenu();
				string choice = Console.ReadLine();
				Console.Clear();

				switch (choice)
				{
					case "1":
						{
							FirstAction(hero);
							break;
						}
					case "2":
						{
							SecondAction(hero);
							break;
						}
					case "3":
						{
							ThirdAction(hero);
							break;
						}
					case "4":
						{
							FourthAction(hero);
							break;
						}
					case "5":
						{
							FivthAction(hero, rooms);
							break;
						}
					case "дай":
						{
							MagicWord(hero);
							break;
						}
					case "0":
						{
							Console.WriteLine("Вы решили выйти из этой шизо - комнаты с набором случайных предметов...");
							return;
						}
					default:
						{
							DefaultAction(hero);
							break;
						}
				}
				Console.ReadKey();
			}

		}
	}
}
