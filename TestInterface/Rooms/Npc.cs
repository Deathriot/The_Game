using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class Npc : Room
	{
		bool _firstTimeVizited = true; // Первое посещение комнаты
		bool _firstTime1 = true; // Первая активация варианта 1
		bool _firstTime2 = true; // Первая активация варианта 2
		public Npc() : base(RoomType.Npc, 1, 2, true, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			if (_firstTimeVizited)
			{
				Console.WriteLine("Вы встретили растроенного эльфа, в глазах которого, однако, читается ярость.");
				Console.WriteLine("Ему явно нужна чья-нибудь помощь.");
			}
			else
			{
				Console.WriteLine("Эльф смотрит на вас с обворожительной улыбкой.");
			}
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			if (_firstTimeVizited)
			{
				Console.WriteLine("Вы подходите к угрюмому эльфу, он вас не замечает, его полностью поглотило занятие пяляния в одну точку с серьезным лицом");
				Console.WriteLine("Вы ничего не нраходите лучше, чем начать диалог словами:");
				Console.WriteLine("Привет, что-то случилось?");
				Console.WriteLine();
				Console.WriteLine("Эльф дергается, мнгновенно достает из рукава кинжал и приставляет вам к горлу, однако тут же приходит в себя, трясет головой и убирает его");
				Console.WriteLine("- Прошу прощения, я на секунду подумал, что вы тот бесчестный гоблин");
				Console.WriteLine("Не то что бы вы были хоть каплю похожи на гоблина, нет - нет, я имею ввиду что меня обокрали и я сейчас на взводе, нет-нет, не то что бы");
				Console.WriteLine("вы были похожи на воровку, просто я...");
				Console.WriteLine("...");
				Console.WriteLine("(Интересно, тут у всех какие-то проблемы с общением?)");
				Console.WriteLine();
				Console.WriteLine("После жалких попыток оправдаться, эльф понял, что лучше просто начать молчать, эх, вот бы эту мудрость осознал алтарик Памяти!");
				_firstTimeVizited = false;
			}
			while (true)
			{
				Console.WriteLine("1 - Что у тебя случилось?");
				Console.WriteLine("2 - Что ты здесь делаешь? Я думала здесь никто уже не был сотню лет.");
				Console.WriteLine("0 - Вынуждена откланиться, достопочтенный эльф");

				string answer = Console.ReadLine();
				switch (answer)
				{
					case "1":
						{
							if (_firstTime1)
							{
								Console.WriteLine("Мелитель мне судья, я не хотел ни кого обременять своим присутствием, однако мне очень нужна помощь...");
								Console.WriteLine("Меня обокрали! Украли очень для меня важную вещь, вещь, из-за которой я здесь и оказался");
								Console.WriteLine("Прошу тебя верни ее! Вор не должен был убежать далеко, он наверняка где-то рядом");
								_firstTime1 = false;
							}
							else
							{
								Console.WriteLine("Как я и говорил, достопочтенная, меня обокрали, и я вынужден умолять вас о помощи");
							}
							break;
						}
					case "2":
						{
							if (_firstTime2)
							{
								Console.WriteLine("Как и я думал, однако, все здесь кишит жизнью!");
								Console.WriteLine("Я знаю, вы сочтёте меня сумасшедшим, но я уверен, что всё подземелье живое! Будь проклят Люцифрон!");
								Console.WriteLine("Когда я ложусь спать, я слышу голоса, их сотни, тысячи! Я не могу понять, что они говорят, но они явно угрожают, пугают меня!");
								Console.WriteLine("Это место не для благородного искателя сокровищ, а для некромантов с черными душами и непристойными помыслами");
								Console.WriteLine("Что же касатся моего прибытия сюда, прошу меня простить, но я не могу ответить на этот вопрос - я дал слово Его Высочеству!");
								Console.WriteLine("Когда я вернусь из миссии, я сообщу обо всем Королю, что здесь творится, это место осквернено и нуждается в немедленном очищении");
								_firstTime2 = false;
							}
							else
							{
								Console.WriteLine("Я вам уже дал ответ на этот вопрос - я здесь по важному делу");
								Console.WriteLine("Большего я не имею права вам сказать");
							}
							break;
						}
					case "дай":
						{
							Console.WriteLine("Дать? Что дать? Пожалуйста поконкретней, возможно я смогу вам помочь");
							Console.WriteLine("(Определенно заклинание на него не работает, очевидно, он точно не родом из этих мест)");
							break;
						}
					case "0":
						{
							Console.WriteLine("До свидания, миледи");
							return;
						}
				}
			}

		}
	}
}
