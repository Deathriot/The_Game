using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class RudeDoor : Room
	{
		bool _doorIsOpen = false; // Открылась ли дверь?
		bool _firstTimeMagicWord = true; //Первое использование слова дай
		bool _firstTimeVizited = true; // Первое посещение комнаты
		bool _firstTimeCursedWord = true; // Первое использование проклятого слова

		public static bool HealRoomRevealed = false; // Раскрытие тайного механизма в лечебной комнате
		public RudeDoor() : base(RoomType.RudeDoor, 2, 3, true, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			if(_firstTimeVizited)
			{
				Console.WriteLine("В этой комнате ничего нет, заметны лишь очертания чего-то похожего на дверь.");
			}
			else
			{
				Console.WriteLine("А вот и комната с грубой дверью");
			}

		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			string parol = "пароль: абракадабрус";

			if (_firstTimeVizited)
			{
				Console.WriteLine("Вы оказываетесь перед зловещего вида дверью, которая, казалось стоит тут с начала времен - так она была стара и потёрта.");
				Console.WriteLine("Не успев достаточно расмотреть дверь, она начинает дрожать и трястись");
				Console.ReadKey();
				Console.Clear();
				Console.WriteLine("ПАРОЛЬ БЛЕАТЬ?");
				Console.WriteLine("");
				Console.ReadKey();
				Console.WriteLine("Что вы ответите этой вежливой двери?");
				Console.WriteLine();
				_firstTimeVizited = false;
			}
			else
			{
				Console.WriteLine("Дверь все еще терпеливо ждет пароля...");
				Console.WriteLine();
			}

			while (true)
			{
				Console.WriteLine("Поговорите с дверью");
				Console.WriteLine();
				Console.WriteLine("0 - Выход");
				Console.WriteLine();
				string answer = Console.ReadLine();
				Console.Clear();

				switch (answer)
				{
					case "абракадабрус":
						{
							if (!_doorIsOpen)
							{

								Console.Clear();
								Console.WriteLine("Дверь оглушительно одновременно прогремела, проскрипела и уважительно  протрещала:");
								Console.WriteLine("МОЖЕШЬ ПРОЙТИ, МИЛ ЧЕЛОВЕК");
								Console.WriteLine();
								Console.Title = "Сказка об одной ведьме";
								rooms.FindRoom(RoomType.Enemy1).Access = true;
								rooms.FindRoom(RoomType.Enemy2).Access = true;
								rooms.FindRoom(RoomType.Enemy3).Access = true;
								Console.WriteLine("Вам теперь доступна верхняя часть подземелья!");
								_doorIsOpen = true;
								return;
							}
							else
							{
								Console.WriteLine("ДА, ЭТО ОПРЕДЕЛЕННО ПАРОЛЬ ДЛЯ ВХОДА, НО Я УЖЕ ОТКРЫЛАСЬ ТЕБЕ");
								Console.WriteLine("ЗАЧЕМ ТЫ ЕЩЕ РАЗ ЕГО ПОВТОРЯЕШЬ? ТЫ СОВСЕМ ИМБИЦИЛ? ЗРЯ Я ПОСЧИТАЛА ТЕБЯ ДОСТОЙНЫМ");
							}
							Console.WriteLine();
							break;
						}
					case "пошла нахуй":
					case "нахуй":
					case "иди нахуй":
						{
							Console.Clear();
							Console.WriteLine("Дверь задумчиво на вас посмотрела");
							Console.ReadKey();
							Console.WriteLine("Поскрипела");
							Console.ReadKey();
							Console.WriteLine("Поморгала");
							Console.ReadKey();
							Console.WriteLine("Сделала непонятное движение иссохшей, похожую на кусок известняка, дервянной ручкой. Вам показалось, что она почесала жопу");
							Console.ReadKey();
							Console.WriteLine("Еще чуть-чуть подумала");
							Console.ReadKey();
							Console.WriteLine("А МОЖЕТ ТЫ САМ НАХУЙ ПОЙДЕШЬ, ЧЁРТ ЕБАНЫЙ?");
							Console.ReadKey();
							Console.Clear();
							break;
						}
					case "блеать":
						{
							Console.WriteLine("ХОРОШАЯ ПОПЫТКА НО НЕТ, УМНИК ХУЕВ");
							break;
						}
					case "БЛЕАТЬ":
						{
							Console.WriteLine("ХОРОШАЯ ПОПЫТКА НО НЕТ, УМНИК ХУЕВ");
							break;
						}
					case "дай":
						{
							if (!_doorIsOpen)
							{
								if (_firstTimeMagicWord)
								{
									Console.WriteLine("СИЛА ЗЕЛГАДИУСА??? ДА КАК ТЫ СМЕЕШЬ?!");
									Console.WriteLine("Я НИЧЕГО НЕ ДАМ ТАКОЙ ВОНЮЧЕЙ ВШЕ, ОДНАКО И ЗАКЛИНАНИЮ СОПРОТИВЛЯТЬСЯ НЕ МОГУ, Я ДАЮ ТЕБЕ ПОДСКАЗКУ К ПАРОЛЮ");
									Console.WriteLine("НАДЕЮСЬ ТАКОЙ ЖАЛКИЙ ЧЕРВЬ КАК ТЫ СМОЖЕТ ДОГАДАТЬСЯ, ГДЕ ОНА");
									Console.Title = parol;
								}
								else
								{
									Console.WriteLine("ХО-ХО, Я ТАК И ЗНАЛА ЧТО ТЫ НЕ ПОЙМЕШЬ МОЮ ПОДСКАЗКУ.");
									Console.WriteLine("ДАЖЕ НЕ ПЫТАЙСЯ, БОЛЬШЕ ТЫ НИЧЕГО НЕ ПОЛУЧИШЬ");
								}
							}
							else
							{
								Console.WriteLine("ТЫ УЖЕ ОТКРЫЛ МЕНЯ, ЧЕГО ТЫ ЕЩЕ ХОЧЕШЬ?");
							}
							break;
						}
					case "0":
						{
							Console.WriteLine("Вы решили выйти из этой непонятной комнаты с дверью - сапожником...");
							Console.Title = "Сказка об одной ведьме";
							return;
						}
					case "нарранукулас":
						{
							if (_firstTimeCursedWord)
							{
								Console.WriteLine("Кажется, это слово возимело не тот эффект, что вы ожидали...");
								Console.WriteLine("Дверь раскалилась до красна. Из нее, даже, пошел пар.");
								Console.WriteLine();
								Console.WriteLine("ГЛУПЫЙ ЧЕЛОВЕЧИШКА. НИЧТОЖНЫЙ ЧЕРВЯК. ЭТИ СЛОВА ТЫ ОБРАЩАЕШЬ КО МНЕ?");
								Console.WriteLine("ПРЕЗРЕННАЯ, ЖАЛКАЯ ДУША, Я УНИЧТОЖУ ТЕБЯ!");
								Console.WriteLine();
								Console.WriteLine("Дверь резко изменила свое настроение. Сразу видно - она проходила курсы по управлению гневом.");
								Console.WriteLine();
								Console.WriteLine("ПОСЛУШАЙ, НЕСЧАСТНЫЙ МАГ, ПОСЛУШАЙ МЕНЯ. НЕ ВЕДАЕШЬ ТЫ, ЧТО ТВОРИШЬ.");
								Console.WriteLine("ЗАБУДЬ ЭТО СЛОВО. ПУСТЬ ОНО КАНЕТ В НЕБЫТИЕ, ЧТОБЫ БОЛЬШЕ НИКТО И НИКОГДА НЕ СМОГ ЕГО ПРОИЗНЕСТИ.");
								Console.WriteLine("ВСЕЙ СВОЕЙ МУДРОСТЬЮ ЗАКЛИНАЮ ТЕБЯ, ЗАБУДЬ!");
								Console.WriteLine("В ЗНАК ДОБРЫХ НАМЕРЕНИЙ, ПРИМИ МОЙ ДАР - КЛЮЧ К ОДНОМУ ИЗ БЕСЧИСЛЕННЫХ СЕКРЕТОВ ЭТОГО МЕСТА.");
								Console.WriteLine("СРЕДИ ЗДЕШНИХ РУИН И РАЗВАЛИН ЛИШЬ ОДНО МЕСТО СОХРАНИЛО БЛАГОДАТЬ ЛЮЦИФРОНА.");
								Console.WriteLine("ВОДА ТАМ ВПИТЫВАЛА СОТНИ И СОТНИ ЛЕТ МАГИЮ ЖИЗНИ, КОТОРОЙ РАЗБРАСЫВАЛИСЬ ДЕСЯТКИ ВЕЛИКИХ МАГОВ.");
								Console.WriteLine("НО ЭТО НЕ ВСЕ, ЧЕМ ПРИМЕЧАТЕЛЬНО ЭТО МЕСТО. СПРЯТАН ТАМ ДРЕВНИЙ МЕХАНИЗМ, СКРЫТЫЙ ОТ ГЛАЗ НЕДОСТОЙНЫХ.");
								Console.WriteLine("Я ОТКРОЮ ЕГО ТЕБЕ. АКТИВИРУЙ ЕГО И ПРИМИ СВОЮ НАГРАДУ. И БОЛЬШЕ НИКОГДА НЕ ПРОИЗНОСИ");
								Console.WriteLine("ТО ОТВРАТИТЕЛЬНОЕ ЗАКЛЯТЬЕ.");
								_firstTimeCursedWord = false;
							}
							else
							{
								Console.WriteLine("Вы решили все-таки не произносить эти страшные слова.");
								Console.WriteLine("В конце концов, вы заключили сделку с этой дверью.");
								Console.WriteLine("По крайней мере - не стоит его произносить хотя бы перед ней...");
							}
							
							break;
						}

					default:
						{
							Console.Clear();
							Console.WriteLine("ТЫ ЧЕ НЕСЕШЬ, ПОЕХАВШИЙ?");
							Console.WriteLine("ХОЧЕШЬ МЕНЯ ПОСЛАТЬ - ТАК И СКАЖИ");
							break;
						}
				}
			}
		}
	}
}
