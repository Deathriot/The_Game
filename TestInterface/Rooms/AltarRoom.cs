using MyTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Witch_Tale.Monsters;

namespace The_Witch_Tale.Rooms
{
	partial class AltarsRoom : Room
	{
		bool _firstTimeVizited = true; // Первое посещение комнаты
		bool _firstTime1 = true; // Первая активация варианта 1
		bool _firstTime2 = true; // Первая Активация варианта 2
		bool _firstTime3 = true; // Первая активация варианта 3
		bool _firstTime4 = true; // Первая активация варианта 4
		bool _firstTime6 = true; // Первая активация варианта 6
		bool _altarIsCursed = false; // Проверка пройдена ли мини-игра, если нет, автоматический вход в мини-игру
		bool _altarWasCleared = false; //Проверка, был ли побежден мини-босс
		bool _firstTimeMagicWord = true; // Проверка на первое применение слова дай (после победы в мини игре)
		bool _altarIsTaken = false; // Проверка на то, был ли забран из комнаты алтарь (комната становится пустая, если вы его забрали)
		bool _firstTimeMagicWordAfterTaken = true; // Проверка первого использования волшебного слова после того, как алтарь ушел

		public static bool DeadByHim = false; // Смерть от мужика внутри алтаря
		public static bool DeadByHimFirstTime = true; // Самая первая смерть от мужика в алтаре

		public AltarsRoom() : base(RoomType.AltarsRoom, 4, 2, true, ' ')
		{

		}

		/// <summary>
		/// Так вас встречает комната если алтарь вы забрали с собой
		/// </summary>
		/// <param name="hero"></param>
		void AlterIntroduction(Character hero)
		{
			if (_firstTimeMagicWordAfterTaken)
			{
				Console.WriteLine("Плаксивого алтаря здесь больше нет, вы чувствуете лишь ее остатки магии");
			}
			else
			{
				Console.WriteLine("Здесь ничего нет. Ни магии, ни алтаря, ни чего то бы ни было еще");
			}
		}

		void Introduction(Character hero)
		{
			if (_firstTimeVizited)
			{
				_firstTimeVizited = false;
				Console.WriteLine("Недолго поколдовав над алтарем, вы легко смогли вернуть его к жизни, хоть и явно не надолго");
				Console.WriteLine("Удобно конечно, когда все это место, по сути, пропитано магией оживления");
				Console.WriteLine("Алтарь начинает пробуждаться...");
				Console.ReadKey();
				Console.Clear();
				Console.WriteLine("Ах, Ах, сколько же я спала? Где я? Кто ты?.. - на вас обрушивается уже знакомый словесный понос, хотя нельзя не отметить, что у этого алтаря голос куда приятнее, чем у одного вашего знакомого");
				Console.WriteLine();
				Console.WriteLine("Через некоторое время Алтар_ка успокаивается");
				Console.WriteLine("Ох, прошу прощения, просто я была в смятении...");
				Console.WriteLine("Спасибо, что вдохнули в меня жизнь, хоть я пока и не понимаю что мне с этой жизнью делать...");
				Console.WriteLine("Чем могу вам помочь? Если конечно, вы не ученица мерзопакосного Зилгадиуса, если это так, прошу вас немедленно уйти!");
			}
			else
			{
				Console.WriteLine("Вас вновь встречает плаксивая алтариха");
				Console.WriteLine("Ах, здравствуй, рада встречи с тобой!");
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Меню выбора если алтарь вы забрали с собой
		/// </summary>
		/// <param name="hero"></param>
		void AlterShowMenu(Character hero)
		{
			Console.WriteLine();
			Console.WriteLine("1 - Здесь кто-нибудь есть?");
			Console.WriteLine("e - Ну пока.. К кому я обращаюсь?");
			Console.WriteLine();
		}
		void ShowMenu(Character hero)
		{
			Console.WriteLine();
			Console.WriteLine("1 - Что ты знаешь об этом месте?");
			Console.WriteLine("2 - Что с тобой случилось?");
			Console.WriteLine("3 - Почему ты так ненавидишь Зилгадиуса?");
			Console.WriteLine("4 - Ты слышала что-нибудь об Антиамулете?");
			if (hero.QuestStatus(QuestName.WifeQuest))
			{
				Console.WriteLine("5 - Хочешь я тебя возьму с собой? Кое-кто будет рад тебе");
			}
			if (_altarWasCleared)
			{
				Console.WriteLine("6 - Кажется, я прогнала то, что в тебе сидело");
			}
			Console.WriteLine("0 - Прощай, алтарчик! Скоро загляну еще");
			Console.WriteLine();
		}
		void FirstAction(Character hero)
		{
			if (_firstTime1)
			{
				Console.WriteLine("О, я все о нем знаю - я тут родилась и счастливо жила до того как сюда явился этот напыщенный волшебник!");
				Console.WriteLine("Добро пожаловать в Люцифроново детище - подземелье, где жизнь и смерть отделяет лишь тонкая грань");
				Console.WriteLine("Это сказочное место, где духи древних предков с радостью поделятся с тобой своей мудростью, а вдовы и вдовцы никогда не будут одиноки");
				Console.WriteLine("Здесь ты волен творить что угодно! Создавать, воскрешать, эксперементировать - рай для любого Прародитиля и Некроманта!");
				Console.WriteLine("Однако... Это место теперь осквернено, опустошено! Я его совсем не узнаю, хоть и чувствую все еще эту бурю магии, пронизывающую каждую пылинку");
				Console.WriteLine("Боже, дорогой мой Люци, что стало с твоим творением!");
				_firstTime1 = false;
			}
			else
			{
				Console.WriteLine("Как я и говорила, это место пропитано магией оживления, это место - настоящее рукотворное чудо!");
				Console.WriteLine("Но посмотрите... Сейчас это лишь осколки от былого величия, ах-ах...");
			}
		}
		void SecondAction(Character hero)
		{
			if (_firstTime2)
			{
				Console.WriteLine("Кажется, я помню свою смерть! Проклятый Зилгад! Это все он!");
				Console.WriteLine("Он уничтожил меня, когда мой милый Люци пропал, пришел и уничтожил!");
				Console.WriteLine("Перед смертью я собрала всю свою ненависть, все свои страдания от обмана и предательства и прокляла его!");
				Console.WriteLine("Я покрыла себя рунами, которые вопили о вечных муках и смерти для него!");
				Console.WriteLine("Но он смог как-то отразить мой гнев... И мои чары попали в кого-то другого...");
				Console.WriteLine("Кажется, он до сих пор внутри меня, мне так жаль, он там так страдает! Но я ничего не могу с этим сделать");
				_firstTime2 = false;
			}
			else
			{
				Console.WriteLine("Эх, как я тебе и сказала, ох-ох...");
				Console.WriteLine("Зилгадёныш убил меня, а я обрушила свою месть не на того");
			}
		}
		void ThirdAction(Character hero)
		{
			if (_firstTime3)
			{
				Console.WriteLine("Это давний конфликт моего господина и этого недомага");
				Console.WriteLine("Зилгадиус пришел сюда, как в свои хоромы и начал творить что ему вздумается!");
				Console.WriteLine("Сотворил подобный мне Алтарь Мудрости и наделил его безумием! Это святотатство!");
				Console.WriteLine("Сотворил и запер могущественное существо из кирпича, Запечатав лишь выход!");
				Console.WriteLine("Мой Люци еще много-много гадостей про него говорил, он не может врать!");
				Console.WriteLine("Ну а самое гадкое и омерзительное, это какая-то новая магия, созданная Зилгадом");
				Write.DarkCyan("Люци называл ее /консольной/, не знаю, что это значит");
				Console.WriteLine("Люци говорил что она противоречит всем законам этого места, извращает саму суть жизни");
				_firstTime3 = false;
			}
			else
			{
				Console.WriteLine("Он плохой и много чего о себе возомнил!");
				Console.WriteLine("А еще эта дурацкая консольная магия!");
			}
		}
		void FourthAction(Character hero)
		{
			if (_firstTime4)
			{
				Console.WriteLine("Прости, ничего о таком не слышала, но я вижу, что твой путь очень важен для всего этого места!");
				Console.WriteLine("Я сожалею, я не знаю, что ты ищешь. Однако помогу тебе чем смогу");
				Console.WriteLine("Я поделюсь с тобой всеми полезными знаниями, что я накопила за время общения с великим Люцифроном");
				hero.Levelup(25);
				_firstTime4 = false;
			}
			else
			{
				Console.WriteLine("Прости, ты же знаешь, я долго была... в небытии");
				Console.WriteLine("Я тебе помогла всем, чем смогла");
			}
		}
		void ThifthAction(Character hero)
		{
			if (hero.QuestStatus(QuestName.WifeQuest))
			{
				if (!_altarWasCleared)
				{
					Console.WriteLine("Что? А ну руки прочь! Кто будет рад? Тот извращенец-клоун из камня?");
				}
				else
				{
					Console.WriteLine("Ох... после того, как ты очистила меня, мне стало так хорошо на душе, смотри, я даже начала восстанавливаться!");
					Console.WriteLine("Мои гранитные бока округлились, а ляписы сверкают как в день создания!");
					Console.WriteLine("Да, я пойду с тобой, моя спасительница!");
					_altarIsTaken = true;
					WifeQuest.WifeIsReady = true;
					hero.QuestUpdate(QuestName.WifeQuest, WifeQuest.AddWifeIsReady);
					return;
				}
				return;
			}

			Console.WriteLine("Что? Простите, не могу вас понять");
		}
		void SixthAction(Character hero)
		{
			if (!_altarWasCleared)
			{
				Console.WriteLine("Что? Простите, не могу вас понять");
			}
			else
			{
				if (_firstTime6)
				{
					Console.WriteLine("Ах! Кажется, вы исправили мою ошибку, которая терзала меня даже в небытие...");
					Console.WriteLine("Не знаю, как вас отблагодарить! Я ваша должница!");
					Console.WriteLine("Мне нечего вам дать, но я - алтарь мудрости, и я знаю много секретов.");
					Console.WriteLine("В этом месте есть дверь, совсем без манер и стыда!");
					Console.WriteLine("Она здесь одна из самых первым оживленных и сторожит нечто жуткое и опасное");
					Console.WriteLine("Я не знаю, как ее открыть, она сильно ругается, если попросить ее это сделать!");
					Console.WriteLine("Хотя Люци говорил, что заклинание Зилгадиуса развяжет язык даже такой грубой каменюге");
					Console.WriteLine("Так вот! Люци сказал, что есть заклинание, которое может открыть одну из тайных комнат этого места");
					Console.WriteLine("Произнеси его перед дверью, и она повинуется, хоть и не откроется сама");
					Console.WriteLine("Я не знаю заклинания, но Люци говорил, что заклинание состоит из двух частей, написанных на стенах");
					Console.WriteLine("Одна из частей написана на стене в этой комнате, вторая - не знаю где");
					Console.WriteLine("(Алтариха что-то прошептала)");
					Console.WriteLine("Вот! Теперь ты можешь видеть эти надписи.");
					_firstTime6 = false;
					hero.TrueSight = true;
				}
				else
				{
					Console.WriteLine("Да, и еще раз спасибо за это!");
					Console.WriteLine("Помни про заклинание, ищи его части на стенах!");
					Console.WriteLine("Ну и, возможно, ты увидишь что-нибудь еще сокрытое в этом злополучном месте...");
				}
			}
		}
		void MagicWord(Character hero)
		{
			if (!_altarWasCleared)
			{
				Console.WriteLine("Как только вы произнесли заветное слово, вся комната начала вибрировать, а алтарь засветился");
				Console.WriteLine();
				Console.WriteLine("Чт... Что ты наделала?! Что происходит?!");
				Console.WriteLine("Так ты все-таки его ученица? Или тот омерзительный алтарь тебя научил?!");
				Console.WriteLine("Что со мной происходит? Я распадаюсь! О боже! Он внутри меня! тот несчастный почувствовал, что его освобождают!");
				Console.WriteLine("О боже! Кем он стал?! Это омерзительно! ЭТО НЕ ДОЛЖНО СУЩЕСТВОВАТЬ");
				Console.WriteLine("НЕНАВИСТЬ. ОБМАН. СТРАДАНИЯ. СТРАХ. ТЫ ПОПЛАТИШЬСЯ ЗА ВСЕ, ЗИЛГАДИУС");
				Console.WriteLine();
				Console.ReadKey();
				Console.WriteLine("Комнату окутывает яркий свет, он становится все мощнее, на него уже невозможно смотреть");
				Console.WriteLine("Вас засасывает внутрь алтаря");
				Console.WriteLine("ОН ИДЕТ ЗА ТОБОЙ");
				Console.ReadKey();
				Console.Clear();

				if (MiniGameAltarsRoom(hero))
				{
					Console.WriteLine("Уничтожив его, вы возвращатесь в комнату");
					Console.WriteLine("Алтарь стоит на своем месте, он все так же покрыт рунами, но теперь вы не чувствуете в них никакой магии");
					Console.WriteLine("Надо дать ей немного времени перевести дух...");
					hero.QuestUpdate(QuestName.WifeQuest, WifeQuest.AddAfterClear);
					_altarWasCleared = true;
					_altarIsCursed = false;
				}
				else
				{
					_altarIsCursed = true;
					return;
				}
			}
			else
			{
				if (_firstTimeMagicWord)
				{
					Console.WriteLine("Что это? Я чувствую непонятную мне силу! ");
					Console.WriteLine("Это сила Зилгадиуса? Странно, но я больше не испытываю отвращение к этому чародею");
					Console.WriteLine("А еще у меня появилось непреодолимое желание обучить тебя магическим искусствам");
					Console.WriteLine();
					hero.PowerUp(1);
					_firstTimeMagicWord = false;
				}
				else
				{
					Console.WriteLine("Снова это незнакомое мне колдоство?");
					Console.WriteLine("Как бы то ни было, оно, кажется, здесь потеряло силу...");
					Console.WriteLine("Ах, не знаю, деточка моя, во что ты вляпалась, но поаккуратнее с этой магией! Она выше нашего понимания!");
				}
			}
		}

		/// <summary>
		/// Слово дай если алтарь вы забрали с собой
		/// </summary>
		/// <param name="hero"></param>
		void AlterMagicWord(Character hero)
		{
			if (_firstTimeMagicWordAfterTaken)
			{
				Console.WriteLine("Сила заклинания позволила вам впитать остатки энергии, выброшенной алтарем");
				hero.HealthUp(1);
				_firstTimeMagicWordAfterTaken = false;
			}
			else
			{
				Console.WriteLine("Вы впитали все, что здесь было, ничего больше нет...");
			}
		}

		/// <summary>
		/// Действие комнаты, если вы НЕ прошли мини-игру
		/// </summary>
		/// <param name="hero"></param>
		void AlterAction(Character hero)
		{
			if (MiniGameAltarsRoom(hero))
			{
				Console.WriteLine("Уничтожив Его, вы возвращатесь в комнату");
				Console.WriteLine("Алтарь стоит на своем месте, он все так же покрыт рукнами, но теперь вы не чувствуете в них никакой магии");
				Console.WriteLine("Надо дать ей немного времени перевести дух...");
				hero.QuestUpdate(QuestName.WifeQuest, WifeQuest.AddAfterClear);
				_altarIsCursed = false;
				_altarWasCleared = true;
			}
		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			if (_altarIsTaken)
			{
				Console.WriteLine("В комнате необыкновенно пусто, алтарик вы забрали с собой, но остатки света все же здесь иногда проблескивают.");
			}
			else
			{
				if (_firstTimeVizited)
				{
					Console.WriteLine("Заглядывая в эту ничем не отличающуюся от остальных комнату, вы вдруг замечаете полуразвалившийся алтарь памяти с потертыми надписями на нем");
					Console.WriteLine("Прочитать их почти невозможно, однако там определенно точно говориться о Зилгадиусе и что о нем и его заклинаниях думал обитатель этого места");
					Console.WriteLine("Странно, но вы понимаете, что это не пустые оскарбления, а вполне себе серьезные проклятия, таящие в себе неведомую вам силу");
					Console.WriteLine("Нужно разобраться в этом, возможно, алтарь еще можно оживить и попытаться выведать у него хоть что-нибудь.");
				}
				else if (_altarIsCursed)
				{
					Console.WriteLine("Из этой комнаты бьет очень яркий свет, похоже, пока вы не обуздаете алтарь, его так и будет колбасить.");
				}
				else
				{
					Console.WriteLine("Здесь все так же стоит покрытый мхом алтарь исписанный ругательствами...");
				}
			}
		}
		public override void Do(Character hero, RoomsManager rooms)
		{
			if (_altarIsTaken)
			{
				AlterIntroduction(hero);

				while (true)
				{
					AlterShowMenu(hero);
					string answer = Console.ReadLine();
					switch (answer)
					{
						case "1":
							{
								Console.WriteLine("В ответ ничего. Вы ожидали чего-то другого?");
								break;
							}
						case "дай":
							{
								AlterMagicWord(hero);
								break;
							}
						case "e":
							{
								Console.WriteLine("Здесь слишком скучно. Вы решили уйти");
								return;
							}
					}
				}
			}

			if (_altarIsCursed)
			{
				AlterAction(hero);
				return;
			}

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
							ThifthAction(hero);
							break;
						}
					case "6":
						{
							SixthAction(hero);
							break;
						}
					case "дай":
						{
							MagicWord(hero);
							if (_altarIsCursed)
							{
								return;
							}
							break;
						}
					case "0":
						{
							Console.WriteLine("Пока-пока!");
							return;
						}
					default:
						{
							Console.WriteLine("Что? Простите, не могу вас понять");
							break;
						}
				}
			}

		}
	}




	// Эта часть класса хранит в себе все необходимое для мини-игры

	public abstract class Altar
	{


		public int X;
		public int Y;
		public int Number;
		public string Name;
		public char Symb = '!';
		public bool Vizited;

		public Altar(int x, int y, int number, string name, bool vizited)
		{
			X = x;
			Y = y;
			Number = number;
			Name = name;
			Vizited = vizited;
		}

		public virtual void Do(Character hero)
		{

		}
	}
	class Altar1 : Altar
	{
		public Altar1() : base(2, 2, 1, "Алтарь Ненависти", false)
		{

		}
		public override void Do(Character hero)
		{
			if (!Vizited)
			{
				Console.WriteLine("Возложив руки на Алтарь Ненависти, вы чувствуете, как ярость начинает просачиваться сквозь стены склепа.");
				Console.WriteLine("Однако, эта ненависть предназначена не для вас...");
				Console.WriteLine("Вы слышите, как это омерзительное нечто, преследующее вас, начинает свирепо рычать");
				Console.WriteLine("Вместе с тем вы чувствуете как вскипает и ваша кровь, вы ни за что не умрете от рук этого чудовища!");
				Console.WriteLine();
				hero.HealthUp(1);
				Console.WriteLine();
				Vizited = true;
				Symb = 'o';
			}
			else
			{
				Console.WriteLine("Этот Алтарь уже отдал всю свою ненависть, теперь это лишь груда камней");
				Console.WriteLine();
			}
		}
	}
	class Altar2 : Altar
	{
		public Altar2() : base(5, 5, 2, "Алтарь Страха", false)
		{

		}
		public override void Do(Character hero)
		{
			if (!Vizited)
			{
				Console.WriteLine("Подойдя к алтарю, неконтролируемый страх начинает сковывать ваш разум");
				Console.WriteLine("Ваши ноги анемели, а глаза накрылись пеленой отчаяния");
				Console.WriteLine("Вы сильны духом, но даже вы не сможете так быстро отойти от чар алтаря");
				Console.WriteLine();
				Vizited = true;
				Symb = 'o';
			}
			else
			{
				Console.WriteLine("Алтарь страха уже потерял все свои силы, однако у вас до сих мурашки по коже от одного его вида");
				Console.WriteLine("Но вы научились преодолевать свой страх, вы - броня, вы - крепость, вас больше не сломить!");
				Console.WriteLine();
				hero.ArmourUp(1);
				Console.WriteLine();
			}
		}
	}
	class Altar3 : Altar
	{
		public Altar3() : base(2, 5, 3, "Алтарь Страданий", false)
		{

		}
		public override void Do(Character hero)
		{
			if (!Vizited)
			{
				Console.WriteLine("Этот Алтарь выглядит самым невзрачным из всех.");
				Console.WriteLine("На нем практически нет рун, вы не чувствуете в нем какой-либо сильной ауры");
				Console.WriteLine("Он хочет лишь одного, вашей крови - и он ее получит");
				Console.WriteLine();
				Console.WriteLine("Здоровье уменьшено на 1!");
				hero.Health--;
				Vizited = true;
				Symb = 'o';
			}
			else
			{
				Console.WriteLine("Алтарь Страданий и до того не был высоким произведением магических искусств");
				Console.WriteLine("Но теперь в нем вообще не осталось никакой магии");
				Console.WriteLine();
			}
		}
	}
	class Altar4 : Altar
	{
		public Altar4() : base(5, 2, 4, "Алтарь Предательства", false)
		{

		}
		public override void Do(Character hero)
		{
			if (!Vizited)
			{
				Console.WriteLine("Прикоснвушись к Алтарю, вы ничего не чувствуете");
				Console.WriteLine("Однако вам показалось, что что-то внутри вас прошептало");
				Console.WriteLine("Не верь... Злазам своим...Закрой их... для Него они не важны...");
				Console.WriteLine();
				Vizited = true;
				Symb = 'o';
			}
			else
			{
				Console.WriteLine("Кажется вы поняли, что сотворил с вами алтарь...");
				Console.WriteLine("Это не обычное ослепление, кажется, будто само подземелье укрыло Его своей непроницаемой вуалью");
			}
		}
	}
	partial class AltarsRoom
	{
		List<Altar> altars = new List<Altar>();
		Altar FindRoom(int x, int y)
		{
			foreach (Altar room in altars)
			{
				if (room.X == x && room.Y == y)
				{
					return room;
				}
			}

			return null;
		}
		void Refresh()
		{
			altars[0].Vizited = false;
			altars[1].Vizited = false;
			altars[2].Vizited = false;
			altars[3].Vizited = false;
			altars[0].Symb = '!';
			altars[1].Symb = '!';
			altars[2].Symb = '!';
			altars[3].Symb = '!';
		}
		void SelfInsert()
		{
			altars.Add(new Altar1());
			altars.Add(new Altar2());
			altars.Add(new Altar3());
			altars.Add(new Altar4());
		}
		void Map(int x, int y, int monsterX, int monsterY, List<Altar> altars)
		{
			for (int i = 1; i <= 6; i++)
			{
				for (int j = 1; j <= 6; j++)
				{


					if (monsterX == j && monsterY == i)
					{
						if (altars[3].Vizited)
						{
							Console.Write("[ ]");
						}
						else
						{
							Console.Write("[@]");
						}
					}

					else if (x == j && y == i)
					{
						Console.Write("[¤]");
					}
					else
					{
						Altar temp = FindRoom(j, i);
						if (temp != null)
						{
							Console.Write($"[{temp.Symb}]");
						}
						else
						{
							Console.Write("[ ]");
						}
					}
				}
				Console.WriteLine();
			}
		}
		bool MiniGameAltarsRoom(Character hero)
		{
			Console.WriteLine("используй консольную магию, чтобы оглушить ЕГО!");
			Console.WriteLine();
			bool altarsAreDone = false;
			bool selfStanDone = true;
			bool needShowMap = false;

			SelfInsert();
			int monsterX = 6;
			int monsterY = 6;

			int x = 1;
			int y = 1;

			bool stan = false;
			int stanCooldown = 0;

			while (true)
			{
				if (altars[0].Vizited && altars[1].Vizited && altars[2].Vizited && altars[3].Vizited)
				{
					altarsAreDone = true;
					Console.WriteLine("Вся сила алтарей поглощена!");
					Console.WriteLine("Он теперь беспомощен! Встретьте его лицом к лицу!");
					Console.WriteLine();
				}
				int bufferX = x;
				int bufferY = y;

				bool repeat = true;
				stanCooldown--;
				Altar tempRoom = FindRoom(x, y);

				if (monsterX == x && monsterY == y)
				{
					break;
				}
				needShowMap = true;

				if (altars[1].Vizited && selfStanDone)
				{
					Map(x, y, monsterX, monsterY, altars);
					Console.ReadKey();
					Console.Clear();
					selfStanDone = false;
					needShowMap = false;
					Console.WriteLine("Вы оторопели от ужаса и не можете пошевелиться!");
					Console.WriteLine();
				}
				else
				{
					while (repeat)
					{
						if (needShowMap)
						{
							Map(x, y, monsterX, monsterY, altars);
							needShowMap = false;
						}

						ConsoleKey move = Console.ReadKey().Key;
						Console.Clear();

						switch (move)
						{
							case ConsoleKey.W:
							case ConsoleKey.UpArrow:
								{
									y--;
									repeat = false;
									break;
								}
							case ConsoleKey.D:
							case ConsoleKey.RightArrow:
								{
									x++;
									repeat = false;
									break;
								}
							case ConsoleKey.S:
							case ConsoleKey.DownArrow:
								{
									y++;
									repeat = false;
									break;
								}
							case ConsoleKey.A:
							case ConsoleKey.LeftArrow:
								{
									x--;
									repeat = false;
									break;
								}
							case ConsoleKey.E:
								{
									if (tempRoom != null)
									{
										if (!tempRoom.Vizited)
										{
											repeat = false;
										}
										else
										{
											needShowMap = true;
										}
										tempRoom.Do(hero);
									}
									else
									{
										Console.WriteLine("Здесь нечего активировать!");
										Console.WriteLine();
										needShowMap = true;
									}
									break;
								}
							case ConsoleKey.Spacebar:
								{
									if (altars[0].Vizited == false)
									{
										if (stanCooldown <= 0)
										{
											stan = true;
											stanCooldown = 3;
											Console.WriteLine("ОНО оглушено!");
											Console.WriteLine("У тебя есть время сбежать!!!");
										}
										else
										{
											Console.WriteLine($"Способность на перезарядке! ({stanCooldown})");
										}
										Console.WriteLine();
									}
									else
									{
										Console.WriteLine("Животная ненависть не позволяет ему замереть!");
										Console.WriteLine();
									}
									needShowMap = true;
									break;
								}
							default:
								{
									Console.WriteLine("Такой команды нет!");
									Console.WriteLine();
									needShowMap = true;
									break;
								}

						}
					}
				}
				if (needShowMap)
				{
					Map(x, y, monsterX, monsterY, altars);
					needShowMap = false;
				}

				tempRoom = FindRoom(x, y);
				if (x < 1 || x > 6 || y < 1 || y > 6)
				{
					Console.WriteLine("Вы уперлись в стену!");
					Console.WriteLine();
					x = bufferX;
					y = bufferY;
				}

				if (tempRoom != null)
				{
					if (tempRoom.Vizited == false)
					{
						Console.WriteLine((tempRoom.Name));
						Console.WriteLine();
					}
				}

				if (monsterX == x && monsterY == y)
				{
					break;
				}

				if (!stan)
				{
					int distanceX = monsterX - x;
					int distanceY = monsterY - y;
					int bufX = monsterX;
					int bufY = monsterY;


					if (Math.Abs(distanceY) > Math.Abs(distanceX))
					{
						if (distanceY < 0)
						{
							monsterY++;
						}
						else
						{
							monsterY--;
						}
					}
					else if (Math.Abs(distanceY) < Math.Abs(distanceX))
					{
						if (distanceX < 0)
						{
							monsterX++;
						}
						else
						{
							monsterX--;
						}
					}
					else
					{
						if (distanceX < 0)
						{
							monsterX++;
						}
						else
						{
							monsterX--;
						}
					}
					if (FindRoom(monsterX, monsterY) != null)
					{
						if (FindRoom(monsterX, monsterY).Vizited == false)
						{
							monsterX = bufX;
							monsterY = bufY;

							if (distanceX < 0)
							{
								monsterX++;
							}
							else
							{
								monsterX--;
							}

							if (FindRoom(monsterX, monsterY) != null)
							{
								monsterX = bufX;
								monsterY = bufY;

								if (distanceY < 0)
								{
									monsterY++;
								}
								else
								{
									monsterY--;
								}
							}
						}
					}
				}
				else
				{
					stan = false;
				}
			}

			if (altarsAreDone)
			{
				Console.WriteLine("Ослабленный - он лишь жалкий старик, просидевший в заключении целый век");
				Console.ReadKey();
				hero.Fight(new Him());
				return true;
			}
			else
			{
				Console.WriteLine("ОН ВАС ДОГНАЛ. ОН ВАС ПОЖИРАЕТ");
				Console.ReadKey();
				Refresh();
				hero.ExpReduce(1);
				DeadByHim = true;
				RoomsManager.FightWasLost = true;
				return false;
			}
		}
	}
}
