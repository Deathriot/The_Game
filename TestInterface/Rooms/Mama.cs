using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Witch_Tale.Rooms.HiddenRooms;

namespace The_Witch_Tale.Rooms
{
	public class Mama : Room
	{
		public Mama() : base(RoomType.Mama, 3, 1, false, ' ')
		{

		}

		bool _firstTimeVizited = true;	     // Первый визит комнаты
		bool _firstTimeMagicWord = true;	 // Первая активация слова дай

		public static bool FightDaddy = false;   // Проверка встретили ли вы папу-кирпича
		public override void Info(Character hero, RoomsManager rooms)
		{
			if (_firstTimeVizited)
			{
				Console.WriteLine("В комнате вы видите угрюмого вида кирпич с сиськами");
				Console.WriteLine("Что-то вам подсказывает, это мама кирпича что вы разбили");
				Console.WriteLine("Она смотрит на вас с ненавистью...");
			}
			else
			{
				Console.WriteLine("Кирпичиха все так же угрюмо на вас смотрит.");
			}
		}
		void ShowMenu(Character hero)
		{
			Console.WriteLine("1 - А ты вообще кто?");
			Console.WriteLine("2 - Ты что-нибудь знаешь об АнтиАмулете?");
			if (hero.QuestStatus(QuestName.WifeQuest))
			{
				Console.WriteLine("3 - Может, пойдешь со мной? Тебе явно не хватает партнера");
			}
			Console.WriteLine("0 - Выход");
			Console.WriteLine();
		}
		void Introduction(Character hero, RoomsManager rooms)
		{
			if (_firstTimeVizited)
			{
				Console.WriteLine("Отперев дверь ключем, вы видете крупный кирпич, с ненавистью смотрящий на вас сквозь слезы");
				Console.WriteLine("Не успев поздорваться, этот кирпич начал кричать:");
				Console.WriteLine("Изверг! Душегуб! Я знаю что ты сделал с моим сыном! Ах, мой сыночек.... ");
				Console.WriteLine("Я рожала сотню кирпичиков, но он был самым особенным - он согласился проглотить ключ, чтобы до нас никто не смог добраться, а ты...");
				Console.WriteLine("мама-кирпич опять залилась слезами, и, кажется, ей начали вторить стены и потолки своим детским плачем");
				Console.WriteLine();
				Console.WriteLine("Вдруг выражение лица сисечного кирпича резко изменилось");
				Console.ReadKey();
				Console.WriteLine("Хотя знаешь, ты молодец, что наконец освободил нас, вот, держи еще один ключ в комнату правее, там тебя ждет награда");
				rooms.FindRoom(RoomType.Daddy).Access = true;
				_firstTimeVizited = false;
			}
			else
			{
				if (!FightDaddy)
				{
					Console.WriteLine("Привет-Привет, ну как, забрал свою награду?");
				}
				else
				{
					Console.WriteLine("Ну что, провел тебе своей параллелипидной залупой по губам мой муженек? Еще хочешь?");
				}
			}
		}
		void FirstAction(Character hero)
		{
			Console.WriteLine("Кто я?! Мать того несчастного, что ты разломала на кусочки!");
			Console.WriteLine("Да как ты смеешь вообще говорить со мной?!");
			Console.WriteLine("А вообще - если хочешь ответов, пройди в комнату правее, там тебе ответят на все вопросы!");
		}
		void SecondAction(Character hero)
		{
			Console.WriteLine("Я не буду с тобой ничего обсуждать!");
			Console.WriteLine("Тем более такие вещи, которые твой скудный ум не сможет никогда познать.");
		}
		void ThirdAction(Character hero)
		{
			if (hero.QuestStatus(QuestName.WifeQuest))
			{
				Console.WriteLine("ЧТОО? Да как ты?! Я замужняя женщина! А ну прочь отсюда!");
				Console.WriteLine();
				Console.WriteLine("Мамаша с воплем амазонки выкидывает вас из комнаты");
				hero.QuestUpdate(QuestName.WifeQuest, WifeQuest.WrongWife);
			}
			else
			{
				Console.WriteLine("Ты че несешь?");
			}
		}
		void MagicWord(Character hero, RoomsManager rooms)
		{
			if (_firstTimeMagicWord)
			{
				Console.WriteLine("Что? Опять? Я думала оно ушло вместе с Зилгадиусом!");
				Console.WriteLine();
				Console.WriteLine("Вдруг мама-кирпич начала трястись, а комнату заполнил скрежет тысячи зубов");
				Console.WriteLine("Вдруг в вашей голове начали раздаваться сотни голосов, шепчащих в унисон...");
				Console.WriteLine();
				Console.WriteLine("Мы - живы. Нас - легион. Это место - это мы. Их четверо - но одна фальшивая");
				Console.WriteLine("Пройди сквозь фальшивую. Узнай секрет");
				_firstTimeMagicWord = false;
				rooms.AddRoom(new FakeWall());
			}
			else
			{
				Console.WriteLine("Ха, пытаешься еще раз? Я так и думала, что ты понятия не имеешь о силе, которой обладаешь");
				Console.WriteLine("Не знаю, что было в первый раз, но надеюсь мои малютки не сблотнули чего лишнего.");
			}
		}
		void DefaultAction(Character hero)
		{
			Console.WriteLine("Ты че несешь?");
		}
		public override void Do(Character hero, RoomsManager rooms)
		{
			Introduction(hero, rooms);
			while (true)
			{
				ShowMenu(hero);
				string answer = Console.ReadLine();
				Console.Clear();
				switch (answer)
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
							if (hero.QuestStatus(QuestName.WifeQuest))
							{
								return;
							}
							break;
						}
					case "дай":
						{
							MagicWord(hero, rooms);
							break;
						}
					case "0":
						{
							Console.WriteLine("Давай-давай, прочь с глаз наших!");
							return;
						}
					default:
						{
							DefaultAction(hero);
							break;
						}
				}
				Console.ReadKey();
				Console.Clear();
			}
		}
	}
}
