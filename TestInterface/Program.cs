using MyTools;
using System;
using System.Collections.Generic;
using System.Text;
using The_Witch_Tale.Monsters;
using The_Witch_Tale.Rooms;
using The_Witch_Tale.Rooms.HiddenRooms;
using The_Witch_Tale.Rooms.HiddenRooms.BehindFakeWallRooms;

namespace The_Witch_Tale
{
	static class Program
	{

		/// <summary>
		/// Проверка, умер ли персонаж, если да, то запускается наставническая беседа по этому поводу
		/// </summary>
		static void Ressurect(Character person, RoomsManager rooms)
		{
			if (RoomsManager.FightWasLost)
			{
				Console.Clear();

				if (RoomsManager.DeadFirstTime)
				{
					Console.WriteLine("Вы просыпаетесь, но не чувствуете, что выспались, а лишь ломоту во всем теле.");
					Console.WriteLine("Кажется, вы каким-то чудом попали в комнату к алтарю.");
					Console.WriteLine("Как только вы это осознаете, из алтаря начинает рваться словесный поток:");
					Console.WriteLine();
					Console.WriteLine("Эх-хэ-хэ! Да это же наша ведьмочка, как спалось?");
					Console.WriteLine("Я смотрю тебе неплохо там досталось! Ну ничего, здесь тебе будет сложно умереть, уж поверь, я пытался, их-хи-хи");
					Console.WriteLine("Я почувствовал, что моего любимого собеседника разорвали на части и не мог допустить, чтоб и ты канула в лето... как Зилгадиус!");
					Console.WriteLine("Я поймал твою душу и засунул в ближайший булыжник, кажется, у тебя достаточно было сил, чтобы превратить его в свое тело, неплохо!");
					Console.WriteLine("Не волнуйся, камней тут хоть отбавляй, помирай -  не хочу! хи-хи-хи!");
					RoomsManager.DeadFirstTime = false;
				}
				else
				{
					Console.WriteLine("Алтарь вновь вас встречает с каменной улыбкой (по крайней мере, вам точно кажется, что этот кринж-истукан вечно лыбится");
					Console.WriteLine("- С возвращением! Всегда рад тебя воскресить! хи-хи!");
				}

				Console.WriteLine();
				Console.WriteLine();

				if (Daddy.DeadByDaddy)
				{
					Daddy.DeadByDaddy = false;
					if (Daddy.DeadByDaddyFirstTime)
					{
						Console.WriteLine("У-ух! Представляю, как тебе досталось.");
						Console.WriteLine("Этот чертов кирпичный гигант извел всех в Люцифроновом убежище, пока его не заточил Зилгадиус");
						Console.WriteLine("Ах, не беспокойся, ты его не освободил, туда можно только войти и получить люлей, но не выйти.");
						Console.WriteLine("С юмором был мой создатель, хи-хи-хи!");
						Console.WriteLine("Я слышал, что его сила ему дана неспроста, интересно, что или кто способен наделить существо таким могуществом...");
						Console.WriteLine();
						person.AddQuest(new DaddyQuest());
						Daddy.DeadByDaddyFirstTime = false;
					}
					else
					{
						Console.WriteLine("Что? Опять? В первый раз не дошло что-ли? Эту глыбу благословил кто-то очень важный.");
						Console.WriteLine("Не важнее, конечно, моего создателя, но все же.");
						Console.WriteLine("Не унывай, ты еще найдешь способ с ним расправиться, ты у меня упорная, хи-хи");
					}
				}
				else if (AltarsRoom.DeadByHim)
				{
					AltarsRoom.DeadByHim = false;
					if (AltarsRoom.DeadByHimFirstTime)
					{
						Console.WriteLine();
						Console.WriteLine("Ого-го, да ты влипла в передрягу, а?");
						Console.WriteLine("Даа, Зилгадиус мне вроде говорил о чем-то таком, о порождении, которое потеряло свой человечий облик из-за");
						Console.WriteLine("Пренеприятнешего смешения рунной, оживляющей и консольной магий");
						Console.WriteLine("Его тебе не одолеть, пока в алтарях есть магия - она питает его страдающую душу");
						Console.WriteLine("Забавно, но то, что его питает, вызывает у него сильнейшую боль - так что он не сможет к тебе подойти.");
						Console.WriteLine("Eсли ты рядом с алтарем, используй это!");
						Write.DarkRed("Ну а еще, он уязвим к консольной магии! Зилгадиус это называл /пробел/!");
						Console.WriteLine("Не знаю что это, но у меня есть ощущение, что ты разберешься, как его применять");
						AltarsRoom.DeadByHimFirstTime = false;
					}
					else
					{
						Console.WriteLine("Слушай, опять, а? Ты разве забыл что я тебе сказал?");
						Write.DarkRed("Заклинание /пробела/! Оно тебе поможет!");
					}
				}
				else if (TreassureGuard.DeadByGuard)
				{
					TreassureGuard.DeadByGuard = false;

					if (TreassureGuard.DeadByGuardFirstTime)
					{
						TreassureGuard.DeadByGuardFirstTime = false;

						Console.WriteLine("Кто-кто тебя отдубасил?! Вот это да-а!");
						Console.WriteLine("Стражей тайн никто не видел вот уже сотню лет, я думал они все сгинули вместе с Люцифроном!");
						Console.WriteLine("Помню-помню, шастали тут и там эти угрюмые каменюги. Безобидные были, правда.");
						Console.WriteLine("Ну, если ты конечно не планировал заниматься здесь богохульством, хи-хи");
						Console.WriteLine();
						Console.WriteLine("Где ты его откопала? Если побьешь его - принесешь мне его кусочек? Ладно-ладно, шучу");
						Console.WriteLine("Ну а если серьезно, то тебе бы и правда стоило его уничтожить.");
						Console.WriteLine("Они вечно охраняют что-то очень интересное!");
					}
					else
					{
						Console.WriteLine("Опять? Ну, тут ничего удивительного, этих стражей, как никак, сам бог воял!");
						Console.WriteLine("Давай, а ну пошла опять в драку, я сгораю от любопытсва, что за стражем!");
					}
				}

				Console.WriteLine();
				Console.WriteLine();
				RoomsManager.FightWasLost = false;
				rooms.CurrentX = 1;
				rooms.CurrentY = 1;
				Console.WriteLine("Вы продолжаете свой путь...");
				Console.ReadKey();
				Console.Clear();
			}
		}

		/// <summary>
		/// Реализует выполнения команд
		/// </summary>
		/// <param name="Персонаж"></param>
		/// <param name="rooms"></param>
		static void Action(Character person, RoomsManager rooms)
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
							rooms.CurrentY++;
							return;
						}
					case ConsoleKey.D:
					case ConsoleKey.RightArrow:
						{
							rooms.CurrentX++;
							return;
						}
					case ConsoleKey.S:
					case ConsoleKey.DownArrow:
						{
							rooms.CurrentY--;
							return;
						}
					case ConsoleKey.A:
					case ConsoleKey.LeftArrow:
						{
							rooms.CurrentX--;
							return;
						}
					case ConsoleKey.E:
					case ConsoleKey.Enter:
						{
							rooms.FindRoom().Do(person, rooms);
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
							rooms.Map();
							break;
						}
				}
			}
		}

		static void Main()
		{
			Console.Title = "Сказка об одной ведьме";
			Console.ForegroundColor = ConsoleColor.White;

			Room tempRoom;
			Character person = Character.SetClass();
			RoomsManager rooms = new RoomsManager();
			rooms.SelfCheck();
			rooms.Map();
			//rooms.Cheat();

			while (true)
			{
				int bufferX = rooms.CurrentX;
				int bufferY = rooms.CurrentY;

				Ressurect(person, rooms);

				Action(person, rooms);

				tempRoom = rooms.FindRoom();

				if (tempRoom.Access)
				{
					rooms.Map();
					Console.WriteLine();
					tempRoom.Info(person, rooms);
				}
				else
				{
					rooms.CurrentX = bufferX;
					rooms.CurrentY = bufferY;
					rooms.Map();
					Console.WriteLine(); 
					if (tempRoom.RoomType == RoomType.Wall)
					{
						tempRoom.Info(person, rooms);
					}
					else
					{
						Console.WriteLine("Пока что вы не можете пройти в эту комнату, что-то мешает.");
					}
				}
			}
		}
	}
}

