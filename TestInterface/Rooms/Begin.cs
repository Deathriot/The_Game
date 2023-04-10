using MyTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class Begin : Room
	{
		bool _firstTimeVizited = true; // Первое посещение начальной комнаты
		bool _firstTime1 = true; // Первая активация варианта 1
		bool _secondTime1 = true; // Вторая активация варианта 1
		bool _firstTime3 = true; // Первая активация варинта 3
		bool _firstTime4 = true; // Первая активация вариант 4
		bool _firstTime4AfterWife = true; // Первая активация варианта 4 после того как вы принесли жену
		bool _firstTime5 = true;  // Первая активация варианта 5
		bool _firstTime7 = true; // Первая активация варианта 7
		bool _firstTimeMagicWord = true; // Первая активация слова дай
		bool _secondTimeMagicWord = false; // Вторая активация слова дай
		bool _thirdTimeMagicWord = false; // Третья активация слова дай
		bool _firstTimeCursedWord = true; //Первая активация проклятого слова
		bool _firstTimeDefault = true; // Первая активация непредусмотренного ответа
		bool _secondTimeDefault = false; //Вторя активация непредусмотренного ответа

		public Begin() : base(RoomType.Begin, 1, 1, true, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			if (hero.TrueSight)
			{
				Console.WriteLine("Алтарь как-то изменился. Что-то явно не так.");
				Console.WriteLine("И в этом, видимо, замешано заклинание той алтарихи.");
				return;
			}

			if (_firstTimeVizited)
			{
				Console.WriteLine("Вы обнаруживаете себя в затхлом помещении с двумя дырками - сложно это назвать дверьми или проходами");
				Console.WriteLine("Запах сырости бьет вам в ноздри и нос отказывается к этому запаху привыкать");
				Console.WriteLine("Однако вы чувсвтвуете, что с ним вам придется провести еще долгое время");
				Console.WriteLine("Страдают также и ваши глаза - вид у этого помещения больше похож на трижды разбомленные катакомбы, нежели на то самое");
				Console.WriteLine("легендарное подземелье, в которое так умоляли вас переместиться ректора Школы Магии");
				Console.WriteLine("И неужели правда в этой дыре, в легендарном подземелье Люцифрона, находится тот самый АнтиАмулет?");
				Console.WriteLine("Что ж, придется во всем самому разобраться, а поможет вам, кажется, вон тот алтарик памяти, какие есть во всех классах в школе");
				Console.WriteLine("Правда не такие жалкие и разваливающиеся...");
			}
			else
			{
				Console.WriteLine("Вы видите уже вам знакомый шизо-алтарь");
				Console.WriteLine("Если честно, вас не особо тянет общаться с ним...");
			}
			Console.WriteLine();

		}
		void Introduction(Character hero)
		{
			Console.WriteLine();

			if(hero.TrueSight)
			{
				Console.WriteLine("Вас вновь встречает поехавший алтарь:");
				Console.WriteLine("Охо-хо, привет-привет! А что это ты так странно на меня смотришь?");
				Console.WriteLine("Только не говори, что и тебя сразила моя неотразимая красота!");
				Console.WriteLine("Я хочу конструктивный диалог, а не очередные любовные страсти!");
				return;
			}

			if (_firstTimeVizited)
			{
				Console.WriteLine("Вы подходите к обвешатлому алтарику памяти, который тут же активируется, и начинает неистово болтать, чувствуя ваше приближение");
				Console.WriteLine("-О боги, наконец-то хоть одна здравомыслящая, живая, яркая, настоящая, существующая, разумная, говорящая душа в этой зловонной, противной...");
				Console.WriteLine();
				Console.WriteLine("Вы подождали минут 5, давая алтарику выговориться");
				Console.WriteLine();
				Console.WriteLine("... богомерзкой клоаке!");
				Console.WriteLine();
				Console.WriteLine("-Пожалуйста, чувствуй себя как дома, ха-ха, спрашивай все что тебя интересует!");
				_firstTimeVizited = false;
			}
			else
			{
				Console.WriteLine("Вас вновь встречает поехавший алтарь:");
				Console.WriteLine("-Заходи, заходи, всегда рад посмотреть на что-то, кроме вечной перепалки двух стен, хи-хи");
			}
			Console.WriteLine();
		}
		void ShowMenu(Character hero)
		{
			Console.WriteLine("1 - Что это за место?");
			Console.WriteLine("2 - Ты всегда такой поехавший?");
			Console.WriteLine("3 - Что мне вообще тут делать?");
			if (!WifeQuest.WifeIsReady)
			{
				Console.WriteLine("4 - Тебе что-нибудь нужно? Ну, кроме таблеток от словарного поноса");
			}
			else
			{
				if (hero.QuestStatus(QuestName.WifeQuest))
				{
					Console.WriteLine("4 - Эй! Мистер каменная эрекция, принимай подарок");
				}
				else
				{
					Console.WriteLine("4 - Как поживаешь со своей женушкой?");
				}
			}
			Console.WriteLine("5 - Меня послали найти АнтиАмулет, ты знаешь что-то о нем?");
			Console.WriteLine("6 - Расскажи правила");
			Console.WriteLine("7 - Ты... С тобой что-то не так...");
			Console.WriteLine("0 - Пока, поехавший");
		}
		void FirstAction(Character hero)
		{
			if (_firstTime1)
			{
				Console.WriteLine("Это - одна из комнат подземелья Люцифрона, наверняка ты о нем наслышана");
				Console.WriteLine("Конечно сейчас оно переживает не лучшие дни, но как же прекрасно оно было лет сто назад!");
				Console.WriteLine("Некроманты и Прародители всех мастей и со всех уголков Элении собирались здесь, чтобы творить чудеса!");
				Console.WriteLine("Как тебе известно, из-за слабого барьера с миром духов, в этом месте практически любой предмет так и наровит подцепить душу или разум");
				Console.WriteLine("Считай, тут царила и до сих пор царит эпидемия духовного СПИДа, хи-хи.");
				Console.WriteLine();
				Console.WriteLine("Так, о чем я, а да");
				Console.WriteLine("Некроманты могли воскресить любой скелет, даже вернув ему память о его жизни");
				Console.WriteLine("А прародитиели упивались тем, что вся их походная сумка теперь была набита говорящими ручками, тетрадями и ну.. и так далее");
				Console.WriteLine("Удивительно, но алтарик смог покраснеть");
				Console.WriteLine("Более того, ты же в курсе, что я один из первых камней Мудрости? Именно здесь знаменитый Зилгадис сотворил меня, наделив мудростью тысячи имбецилов и шутов");
				Console.WriteLine("Правда Камень Мудрости звучал слишком пафосно, и все начали нас называть просто алтарями памяти, по мне так - это расизм! Хе-хе");
				Console.WriteLine();
				Console.WriteLine("Вы слушаете еще целый час про каждый предмет или труп, который тут был воскрешен или наделен душой");
				Thread.Sleep(2000);
				Console.WriteLine();
				Console.WriteLine("... И тогда, благороднейшая Мария смогла не только удовлетворить свою похоть, но и нашла себе интересного собеседника, хе-хе");
				Console.WriteLine();
				Console.WriteLine("Ты такой приятный собеседник! Вот бы превратилась ты в камень и осталась навеки со мной!");
				Console.WriteLine("Впрочем, что еще тебя интересует?");
				_firstTime1 = false;
			}
			else
			{
				Console.WriteLine("Я тебе же все вроде рассказал, но я с удовольствием повторю свой увлекательный рассказ!");

				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine("...");
					Thread.Sleep(1000);
				}
				if (_secondTime1)
				{
					Console.WriteLine("Да, зря вы спросили еще раз... ваша голова уже расскалывается, однако вы усвоили один урок - ");
					Console.WriteLine("есть вопросы, ответы на которые ты не хочешь знать... во второй раз");
					hero.Levelup(30);
					_secondTime1 = false;
				}
				else
				{
					Console.WriteLine("У вас болит голова...");
				}
			}
		}
		void SecondAction(Character hero)
		{
			Console.WriteLine("Ха-ха-ха, хи-хи-хи!");
		}
		void ThirdAction(Character hero)
		{
			if (_firstTime3)
			{
				Console.WriteLine("Что, наш горе - программист не написал даже обучение? Опять мне все делать...");
				Console.WriteLine("Нажав i ты сможешь увидеть все что тебе нужно, и не спрашивай, что это значит, но мне кажется, что тобой управляет кто-то извне на некой");
				Console.WriteLine("магической машине называющайся ЭВМ");
				Console.WriteLine();
				Console.WriteLine("Ну а так здесь все поделено на комнаты, в комнаты ты можешь входить, а можешь и продвигаться дальше, если конечно тебе не преградит путь какой-нибудь зверь или запертая дверь");
				Console.WriteLine("И еще - мой тебе подарок, который тебе точно пригодится: заклинание 'дай' - великая консольная магия!");
				Console.WriteLine("Здесь почти все уязвимы к этому заклинанию, применяй на чем угодно, ведь тут почти все живое!");
				Console.WriteLine("Без него вряд ли ты сможешь далеко зайти...");
			}
			else
			{
				Console.WriteLine("Волшебное слово дай - это все, что тебе нужно");
				Console.WriteLine("С помощью него и своей смекалки найди все осколки амулета и сделай то, что тебе нужно сделать");
			}
		}
		void FourthAction(Character hero)
		{
			if (!WifeQuest.WifeIsReady)
			{
				if (_firstTime4)
				{
					Console.WriteLine("Хочу жениться! Притащи мне жену, а я наделю тебе знаниями тысячи шизофреников!");
					hero.AddQuest(new WifeQuest());
				}
				else
				{
					Console.WriteLine("Ты оглохла? Хочу Камень с дыркой! Желательно чтоб говорить еще могла. Но не много. Меньше меня! Хотя нет!");
					Console.WriteLine("Чтоб сначала я говорил, а потом она, а потом я опять, а она слушает! хи-хи!");
					Console.WriteLine("Да, надо чтоб говорить умела, но меньше чем я, но больше, чем нужно!");
				}
			}
			else
			{
				if (hero.QuestStatus(QuestName.WifeQuest))
				{
					Console.Clear();
					Console.WriteLine("Вы уверены, что хотите отдать ему жену?");
					Console.WriteLine("1 - да");
					ConsoleKey answer = Console.ReadKey().Key;
					switch (answer)
					{
						case ConsoleKey.D1:
							{
								Console.WriteLine("охохо - Вот это да! Настоящая жена! Из неплоти и без крови!");
								Console.WriteLine("Спасибо тебе! Спасибо спасибо спасибо спасибо!");
								Console.WriteLine("Наконец-то мне будет с кем поболтать. А еще я слышал что она ненавидит моего создателя! Это же шикарно!");
								Console.WriteLine("Это же бесконечный потенциал для полемики! Сколько интересных споров у нас будет! Ну, очевидно конечно, что я прав, но все же!");
								Console.WriteLine("Как я и обещал, я открою тебе мудрость тысячи шизофреников!");
								Console.WriteLine("Советую после этого часик побиться головой об стену, так знания лучше усвоятся.");
								hero.QuestDone(QuestName.WifeQuest);
								break;
							}
						default:
							{
								if (WifeQuest.FirstTimeReject)
								{
									Console.WriteLine("Так у тебя нет жены? А что ж тогда обнадежила? Никакого уважения!");
									Console.WriteLine("А ну прочь, женщина, я в печали!");
									hero.QuestUpdate(QuestName.WifeQuest, WifeQuest.WifeRejected);
									WifeQuest.FirstTimeReject = false;
								}
								else
								{
									Console.WriteLine("Опят издеваешься? А я думал это у меня стыда нет!");
								}
								return;
							}
					}
				}
				else
				{
					if (_firstTime4AfterWife)
					{
						Console.WriteLine("Прекрасно! Просто прекрасно!");
						Write.Green("Она постоянно ноет и боится сказать... Как она там говорила? Точно! /Грязные словечки/!");
						Console.WriteLine("Это пенис какашки жопа ах-ха-ха, аж самому смешно уже! Ой смотри-смотри! Она опять покраснела! Ой умора!");
						Console.WriteLine("Еще раз спасибо тебе! Мне никогда не было так весело!");
						_firstTime4AfterWife = false;
					}
					else
					{
						Console.WriteLine("Замечательно! Я очень доволен! хи-хи!");
					}
				}
			}
		}
		void FivthAction(Character hero)
		{
			if (_firstTime5)
			{
				Console.WriteLine("Знаю ли я?! Да он мой отец и мать! Могущественный артифакт, который, если ты не в курсе, и пробил брешь с миром духов!");
				Console.WriteLine("Однако, как только почил всеми любимый и многоуважаемый Зелгадиус (Кажется, из импровизированных глаз камня начали катиться камушки, напоминающие слезы)...");
				Console.WriteLine("Это место теперь в упадке! а все из-за того, что Тролль Громп-Шлёмп, чтоб ему пусто было, каким-то образом сожрал амулет и высрал его на 7 частей!");
				Console.WriteLine("Он ходил и гадил во всех комнатах, чтоб части амулета точно не смог никто найти и собрать воедино!");
				Console.WriteLine("Представляешь, он даже спутал меня с туалетом! А мои визги ему ничего не говорили - у нас тут все туалеты жалобно орут!");
				Console.WriteLine("Зато.. у меня есть теперь один из осколков АнтиАмулета, пожалуй, он твой, считай, на 1/7 твое задание уже выполнено!");
				hero.AmuletShardFound();
				_firstTime5 = false;
			}
			else
			{
				Console.WriteLine("Мне больно еще раз рассказывать тебе он нем... О, мой Зелгадиус!..");
			}
		}
		void SixthAction(Character hero)
		{
			Console.WriteLine("хо-хо, ну, первое правила - это не искать эксплоиты в этом кастыльном гавнокоде, хе-хе");
			Console.WriteLine();
			Console.WriteLine("Ну а так слушай внимательно. (Алтарик прокшлялся)");
			Console.WriteLine("Если в соседней комнате есть враг, ты не сможешь попасть в эту комнату, пока его не победишь");
			Console.WriteLine("Без специального заклинания Зелгадиуса ты не сможешь пройти дло конца и собрать все осколки");
			Console.WriteLine("Если тебя отмудохает монстр, моя магия вернет тебя сюда, однако для заклинания требуются твоя ментальная энергия. ");
			Console.WriteLine("Tак что ты немного отупеешь, хи - хи");
		}
		void SeventhAction(Character hero)
		{
			if (!hero.TrueSight)
			{
				Console.WriteLine("А? Ниче не понял!");
				return;
			}

			if (_firstTime7)
			{
				Console.WriteLine("Хо-хо, да ты что, я все тот же очаровашка-плейбой коим был и всегда!");
				Console.WriteLine("А вот ты явно изменилась. Хммм...");
				Console.WriteLine();
				Console.WriteLine("(Вы пристально наблюдали за алтарем, и заметили, что на мнгновение на его каменном лице)");
				Write.Red("(Проскачила гримаса /ужаса/. Лишь на мнгновение. Алтарь опять расплылся в дебильной улыбке.)");
				Console.WriteLine();
				Console.WriteLine("Ммм.. Нет, нет. Ты тоже все та же ведьмочка, чей пол могу видеть только я, хе-хе.");
				Console.WriteLine("Однако если ты вдруг что-то узнала, что-то непонятное, но наверняка опасное, ты же не будешь это применять на мне, да?");
				Console.WriteLine("Ну это я так, к слову... В общем забудь!");
				_firstTime7 = false;
			}
			else
			{
				Console.WriteLine("Ну что ты! Опять непонятные обвинения! Будь попроще!");
			}
			Console.WriteLine();
			
		}
		void MagicWord(Character hero)
		{
			if (_firstTimeMagicWord)
			{
				Console.WriteLine("Иш какой умный! Сразу на мне решил его использовать, а нет, Зелгадиус меня и только меня огородил от этого заклятья! соси! хи-хи!");
				_firstTimeMagicWord = false;
				_secondTimeMagicWord = true;
			}
			else if (_secondTimeMagicWord)
			{
				Console.WriteLine("Почему ты считаешь, что во второй раз это сработает? Да ты безумнее меня! Хи-хи!");
				_secondTimeMagicWord = false;
				_thirdTimeMagicWord = true;
			}
			else if (_thirdTimeMagicWord)
			{
				Console.WriteLine("О, твое упорство и тупость меня просто будоражат!");
				Console.WriteLine($"Открой свой разум, {hero.Name}, я подарю тебе частичку силы могучей дурки!");
				hero.PowerUp(1);
				_thirdTimeMagicWord = false;
			}
			else
			{
				Console.WriteLine("А теперь это уже действует на нервы, больше никаких плюшек ты не получишь, не старайся");
			}
		}
		void CursedWord(Character hero)
		{
			if (!hero.TrueSight)
			{
				Console.WriteLine("Как только вы произнесли заклинания, все подземелье начало трястись и выть от боли.");
				Console.WriteLine("Пол под вами начал обваливаться ,обнажая бесконечную бездну. А из глубин этой бездны начало подниматься... нечто...");
				Console.WriteLine("Нечто имело 6 рук и бесчетное количество глаз и ртов.");
				Console.WriteLine("Вы не успели ничего сделать, как оно взяло вас взяло всеми своими руками и поднесло к одному из глаз, самому большому.");
				Console.ReadKey();
				Console.WriteLine();
				Console.WriteLine("ТЫ ИГРАЛА С СИЛАМИ, ПЕРЕД КОТОРЫМИ ДАЖЕ БОГИ ТРЯСЛИСЬ ОТ УЖАСА И БЕССИЛИЯ. МЫ НЕ МЕШАЛИ.");
				Console.WriteLine("НО ЭТО МЫ НЕ ПРОСТИМ ТЕБЕ. ОТКУДА ТЫ УЗНАЛА ЗАКЛИНАНИЕ? ОНО ТЕБЕ НЕ МОЖЕТ БЫТЬ ПОКА ДОСТУПНО.");
				Console.WriteLine("Я НЕ В СИЛАХ ТЕБЯ УНИЧТОЖИТЬ. НО ЛИШИТЬ СИЛ И ОСТАВИТЬ ГНИТЬ В ЭТОМ АДУ Я СПОСОБЕН.");
				Console.WriteLine("НАСЛАЖДАЙСЯ ВЕЧНЫМИ МУКАМИ, ПРИЧИНОЙ КОТОРЫХ ЯВЛЯЕШЬСЯ ЛИШЬ ТЫ САМА, ВЕДЬМА");
				Console.WriteLine();
				Console.WriteLine("Вы лишились всех жизненных сил...");
				hero.MaxHealth = -100;
				hero.Health = -100;
				return;
			}
			if (_firstTimeCursedWord)
			{
				Console.WriteLine("Алтарь замер и затих, как только вы произнесли проклятье.");
				Console.WriteLine("Вы остановили время? Заставили все живое здесь вновь обратиться в небытие?");
				Console.WriteLine("Нет, кажется все гораздо хуже - алтарь не застыл...");
				Console.ReadKey();
				Console.WriteLine();
				Console.WriteLine("Агония, в которой сейчас находился алтарь была столь невыносимой, что он не мог произнести и звука.");
				Console.WriteLine("Наконец, вы смогли раслышать еле слышный стон - 'х-х-ххватит! Прек.. ра..' алтарь вновь перестал подавать признаки жизни.");
				Console.WriteLine("В панике, вы пытались прекратить действие заклинания. Наконец вам это удалось - нужно было повторить эти страшные слова еще раз.");
				Console.ReadKey();
				Console.WriteLine();
				Console.WriteLine("Прошло несколько минут. Вы смотрели друг на друга, не решаясь первым начать диалог.");
				Console.WriteLine();
				Console.WriteLine("Наконец, алтарь прошептал - пожалуйста, не делай больше этого...");
				Console.WriteLine("Эти слова я слышал раньше лишь один раз. Последствия того раза ты можешь наблюдать до тех пор.");
				Console.WriteLine("Не становись как он. Пожалуйста.");
				Console.WriteLine("Из алтаря вышел шар света. Он прошел сквозь вас, обволакивая странной теплотой.");
				Console.WriteLine("Вот, возьми это в знак моих добрых намерений... И давай забудем об этом?");
				hero.HealthUp(5);
				Console.WriteLine();
				Console.ReadKey();
				Console.WriteLine("Вдруг алтарь встрепенулся, и задумчивое уныние, так не свойственное этому существу, как рукой сняло.");
				Console.WriteLine("Он вновь расплылся в своей манерной улыбке.");
				Console.WriteLine("А я уже все и правда забыл, их-хи-хи!");
				Console.WriteLine("нет. Правда, что произошло? Я пропустил что-то веселое? Эх, опять все самое интересное идет мимо меня!");
				_firstTimeCursedWord = false;
			}
			else
			{
				Console.WriteLine("Вспоминая, как корчился этот несчастный алтарь, у вас не хватило духу вновь произнести эти слова...");
			}
		}
		void DefaultAction(Character hero)
		{
			if (_firstTimeDefault)
			{
				Console.WriteLine("Что? Не очень понял тебя, но мне нравится твой настрой нести бред! Держи хэпэшечку!");
				hero.HealthUp(1);
				_firstTimeDefault = false;
				_secondTimeDefault = true;
			}
			else if (_secondTimeDefault)
			{
				Console.WriteLine("Хмм... продолжай в том же духе! Мне нравится! Держи еще сердечко!");
				hero.HealthUp(1);
				_secondTimeDefault = false;
			}
			else
			{
				Console.WriteLine("Ладно - ладно, я тебя понял, ты не настоящий шизофреник!");
				Console.WriteLine("Ты несешь бред лишь ради бафов! Никакого уважения к шутам!");
			}
		}
		public override void Do(Character hero, RoomsManager rooms)
		{
			Introduction(hero);
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
							break;
						}
					case "4":
						{
							FourthAction(hero);
							break;
						}
					case "5":
						{
							FivthAction(hero);
							break;
						}
					case "6":
						{
							SixthAction(hero);
							break;
						}
					case "7":
						{
							SeventhAction(hero);
							break;
						}

					case "дай":
						{
							MagicWord(hero);
							break;
						}
					case "нарранукулас":
						{
							CursedWord(hero);
							break;
						}
					case "0":
						{
							Console.WriteLine("Ах, уже уходишь? Ну до встречи! хи-хи!");
							Console.WriteLine();
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
