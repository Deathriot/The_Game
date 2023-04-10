using MyTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale
{
	public enum HeroType
	{
		Healer = 0,
		Necromant = 1,
		Apothecary = 2
	}
	public abstract class Character
	{
		protected readonly List<Quest> Quests = new List<Quest>(); // Список квестов
		protected StringBuilder Sb = new StringBuilder();
		public static Character SetClass()
		{
			Character person = null;
			while (person == null)
			{
				Console.WriteLine("Выберите класс:");
				Console.WriteLine();
				Write.Red("1 - /Жрец/");
				Write.DarkCyan("2 - /Некромант/");
				Write.Yellow("3 - /Алхимик/");

				ConsoleKey answer = Console.ReadKey().Key;
				Console.Clear();

				switch (answer)
				{
					case ConsoleKey.D1:
						{
							person = new Healer();
							break;
						}
					case ConsoleKey.D2:
						{
							person = new Necromant();
							break;
						}
					case ConsoleKey.D3:
						{
							person = new Apothecary();
							break;
						}

					default:
						{
							Console.WriteLine("Такой команды нет!");
							Console.WriteLine();
							break;
						}
				}
			}
			return person;
		}

		public int Lvl = 1;
		protected int Exp = 0;
		protected int MaxExp = 20;
		public int AmuletShard = 0;

		public HeroType HeroType;
		public string Name;

		public int Health;
		public int MaxHealth;
		public int Armour;
		protected int MaxArmour;
		protected int Power;
		protected int MaxPower;

		protected string MagicStrikeName = "Магический удар";
		protected string FirstSpellDiscribe;
		protected string FirstSpellName;
		protected int CoolDownFirstSpell = 3;
		protected bool FirstSpellReady = true;
		protected bool Unable2ndSpell = false;

		public bool TrueSight = false; //Ясновиденье персонажа, может видеть дополнительные всякие штуки

		public void ExpReduce(int value)
		{
			Console.WriteLine($"Опыт понижен на {value}!");
			Exp -= value;
		}
		public void PowerUp(int value)
		{
			Console.WriteLine($"Сила магии увеличина на {value}!");
			Power += value;
			MaxPower += value;
		}
		public void ArmourUp(int value)
		{
			Console.WriteLine($"Броня повышена на {value}!");
			Armour+= value;
			MaxArmour += value;
		}
		public void AmuletShardFound()
		{
			AmuletShard++;
			Console.WriteLine();
			Write.Cyan("Найден /осколок амулета/!");
			Console.WriteLine($"Осколков собрано: {AmuletShard}");
			Console.WriteLine();
        }
		public void HealthRegenerate(int value)
		{
			Write.Red("/Здоровье/ восстановлено на *!", value);
			Health += value;

			if (Health > MaxHealth)
			{
				Health = MaxHealth;
			}
		}
		public void HealthUp(int value)
		{
			Console.WriteLine();
			Write.Red("/Здоровье/ повышено на *!",value);
			Console.WriteLine();
			Health += value;
			MaxHealth += value;
		}
		protected int DamageResult(int damage, int armour)
		{
			int result = damage - armour;

			if (result < 0)
			{
				result = 0;
			}
			return result;
		}
		protected void FightAction(Monster monster)
		{
			while (true)
			{
				Console.WriteLine("Используйте способность!");
				Console.WriteLine($"1 - {MagicStrikeName}");
				Console.Write($"2 - {FirstSpellName}");

				if (!FirstSpellReady)
				{
					Console.WriteLine($" - на перезарядке ({CoolDownFirstSpell + 1}) ");
				}
				else
				{
					Console.WriteLine();
				}

				ConsoleKey answer = Console.ReadKey().Key;
				Console.Clear();

				switch (answer)
				{
					case ConsoleKey.D1:
						{
							MagicStrike(monster);
							return;
						}
					case ConsoleKey.D2:
						{
							if (FirstSpellReady)
							{
								FirstSpellReady = false;
								FirstSpell(monster);
								return;
							}
							else
							{
								Console.WriteLine("Способность на перезарядке!");
							}
							break;
						}
					default:
						{
							Console.WriteLine("ТАКОЙ КОМАНДЫ НЕТ!");
							Console.WriteLine();
							break;
						}
				}
			}
		}
		protected void MagicStrike(Monster monster)
		{
			int damage = DamageResult(Power * 2 + 1, monster.Armour);
			monster.Health -= damage;
			Console.WriteLine("Магический удар нанес монстру {0} урона", damage);
			Console.WriteLine();
		}
		public void PersonInfo()
		{
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(Name);
			Console.WriteLine("");
			Write.DarkBlue("* /Уровень/", Lvl);
			Write.Yellow("* /Опыта/", Exp);
			Console.WriteLine("Опыта до следующего уровня: {0}", MaxExp - Exp);
			Console.WriteLine("");
			Write.Red("/Здоровье/ = *", Health);
			Write.Blue("/Cила магии/ = *", Power);
			Write.Magenta("/Броня/ = *", Armour);
			Write.Cyan("Собрано /осколков АнтиАмулета/: *", AmuletShard);

			Console.WriteLine();
			Console.WriteLine("Способности:");
			Console.WriteLine();
			Console.WriteLine($"{MagicStrikeName} - наносит {Power * 2 + 1} урона");
			Console.WriteLine($"Первая способность - {FirstSpellDiscribe}");
			Console.WriteLine();
			Console.Write(new string('=', 129));
			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("Что делают клавиши:");
			Console.WriteLine();
			Console.WriteLine("w - Вверх");
			Console.WriteLine("d - Направо");
			Console.WriteLine("s - Вниз");
			Console.WriteLine("a - Налево");
			Console.WriteLine("enter - Взаимодействовать с комнатой");
			Console.WriteLine("i - Информация о персонаже");
			Console.WriteLine("j - Журнал заданий");
			Console.ReadKey();
			Console.Clear();
		}
		public void QuestDone(QuestName questName)
		{
            foreach (Quest quest in Quests)
            {
                if (quest.QuestName == questName)
                {
                    Write.Yellow("задание * выполнено!", quest.Title);
                    Console.WriteLine();
                    quest.Reward(this);
					Quests.Remove(quest);
                }
            }
        }
		public void AddQuest(Quest quest)
		{
			Console.WriteLine();
			Write.Yellow("Добавлено новое /задание/!");
			Quests.Add(quest);
        }
		public void QuestUpdate(QuestName quest, string addDiscribtion)
		{
			foreach (Quest _quest in Quests)
			{
				if(_quest.QuestName == quest)
				{
					Console.WriteLine();
					Console.WriteLine($"Задание {_quest.Title} обновлено!");
					Console.WriteLine();
					Sb.AppendLine(_quest.Description);
					Sb.AppendLine();
					Sb.Append(addDiscribtion);
					_quest.Description= Sb.ToString();
                }
			}
		}
		public void QuestInfo()
		{
			if(Quests.Count > 0)
			{
				for (int i = 0; i < Quests.Count; i++)
				{
					Console.Write($"{(i + 1)}.");
					Write.Yellow(Quests[i].Title);
					Console.WriteLine(Quests[i].Description);
					Console.WriteLine();
				}
			}
			else
			{
				Console.WriteLine("У вас пока нет заданий!");
			}

			Console.ReadKey();
			Console.Clear();
		}
		public bool QuestStatus(QuestName quest)
		{
            foreach (Quest _quest in Quests)
            {
                if (_quest.QuestName == quest)
                {
					return true;
                }
            }
			return false;
        }
		protected void Refresh()
		{
			if(Health > MaxHealth)
			{
				Health = MaxHealth;
			}
			Armour = MaxArmour;
			Power = MaxPower;
			FirstSpellReady = true;
			CoolDownFirstSpell = 3;
		}
		public bool Fight(Monster monster)
		{
			int turn = 1;
			bool win;

			Console.Clear();
			Console.WriteLine("Начинается бой!");
			Console.WriteLine("Ваш враг: {0}!", monster.Name);
			Console.WriteLine("Параметры врага:");
			Console.WriteLine();
			Write.DarkRed("/Здоровье/  = *", monster.Health);
			Write.Blue("/Броня/ = * ", monster.Armour);
			Write.DarkMagenta("/Атака/ = *", monster.Attack);
			Console.WriteLine(monster.Discription);
			Console.WriteLine();
			Console.WriteLine("Для продолжения нажмите любую клавишу");
			Console.ReadKey();
			Console.Clear();
			Console.WriteLine("Начинается бой!");
			Console.WriteLine();

			while (monster.Health > 0 && Health > 0)
			{
				if (CoolDownFirstSpell == 0)
				{
					FirstSpellReady = true;
					CoolDownFirstSpell = 3;
				}

				if (!FirstSpellReady)
				{
					CoolDownFirstSpell--;
				}

				Console.WriteLine($"ход {turn}");
				Console.WriteLine();

				FightAction(monster);

				if (monster.Health > 0)
				{
					monster.MonsterAttack(this);
					monster.MonsterSkill(this);
				}

				Write.Red("У вас осталось * /здоровья/", Health);
				Write.DarkRed("У монстра осталось * /здоровья/", monster.Health);
				turn++;
				Console.ReadKey();
				Console.Clear();
			}

			if (Health > 0)
			{
				win = true;
				Console.WriteLine("Вы победили!");
				Console.WriteLine();
				Levelup(monster.Exp);
			}
			else
			{
				win = false;
				Console.WriteLine("Вы проиграли!");
				Console.WriteLine("Учится на ошибках - это хорошо, однако Консольный Бог решил обратное");
				Console.WriteLine("Не бойтесь, Алтарь вас воскресит...");
				ExpReduce(5);
				RoomsManager.FightWasLost = true;
			}
			Refresh();
			return win;
		}
		public void Levelup(int exp)
		{
			Console.WriteLine();
			Write.Yellow("Опыт Повышен на *!",exp);
			Exp += exp;
			Console.WriteLine();

			while (Exp >= MaxExp)
			{
				Lvl++;
				Health = MaxHealth;
				Exp -= MaxExp;
				MaxExp += 20;
				Console.ReadKey();
				Write.DarkBlue("/Уровень/ повышен!");
				Write.DarkBlue("Вы достигли * /уровня/", Lvl);
				Console.WriteLine("Вы полностью исцелены!");
				Console.WriteLine();

				if (Lvl == 2)
				{
					HealthUp(2);
				}
				if (Lvl == 3)
				{
					HealthUp(3);
				}
				if (Lvl == 4)
				{
					PowerUp(1);
				}
				if (Lvl == 5)
				{
					Write.Magenta("Вы открыли новую способность: /*/ !", FirstSpellName);
					Unable2ndSpell = true;
				}
				if (Lvl == 6)
				{
					ArmourUp(1);
				}
				if (Lvl == 7)
				{
					HealthUp(1);
					PowerUp(1);
				}
				Console.WriteLine();
				Console.WriteLine();
			}
		}
		protected abstract void FirstSpell(Monster monster);
		//public abstract void SecondSpell();
	}
	public class Healer : Character
	{
		public Healer()
		{
			HeroType = HeroType.Healer;
			Health = 15;
			MaxHealth = 15;
			Armour = 1;
			MaxArmour = 1;
			Power = 2;
			MaxPower = 2;

			Name = "Целитель";
			FirstSpellDiscribe = $"'Взывание к богам' -  наносит {Power} чистого урона, востанавливает {2*Power + 1} здоровья, повышает броню на {Power}";
			FirstSpellName = "Взывание к богам";
		}
		protected override void FirstSpell(Monster monster)
		{
			Armour += Power;
			monster.Health -= Power+1;
			Console.WriteLine("Вы взываете к силе света!");
			Console.WriteLine();
			HealthRegenerate(2 * Power + 1);
			Console.WriteLine($"Броня на время боя увеличена на {Power}!");
			Console.WriteLine($"{monster.Name} получает {Power+1} чистого урона!");
			Console.WriteLine();
		}
	}
	public class Necromant : Character
	{
		public Necromant()
		{
			HeroType = HeroType.Necromant;
			Health = 10;
			MaxHealth = 10;
			Armour = 0;
			MaxArmour = 0;
			Power = 4;
			MaxPower = 4;

			Name = "Некромант";
			FirstSpellName = "Вытягивание души";
			FirstSpellDiscribe = $"Вытягивание души - наносит {3*Power} урона, востанавливает столько же здоровья";
		}
		protected override void FirstSpell(Monster monster)
		{
			int damage = DamageResult(3*Power, monster.Armour);
			HealthRegenerate(damage);
			monster.Health -= damage;
			Console.WriteLine("Вы поглощаете часть души монстра!");
			Console.WriteLine($"Вы вытянули из монстра {damage} здоровья");
			Console.WriteLine();
		}
	}
	public class Apothecary : Character
	{
		public Apothecary()
		{
			HeroType = HeroType.Apothecary;
			Health = 17;
			MaxHealth = 17;
			Armour = 0;
			MaxArmour = 0;
			Power = 1;
			MaxPower = 1;

			Name = "Алхимик";
			FirstSpellName = "Жонглирование зельями";
			FirstSpellDiscribe = $"Алхимик разбрасывает все зелья из сумки, уменьшая броню монстра на {Power * 2}, увеличивая свою броню на {Power} и усиливая свою силу магии на 1";

		}
		protected override void FirstSpell(Monster monster)
		{
			monster.Armour -= Power * 2;
			Armour += Power * 2;
			Power++;
			Console.WriteLine("Вы разбиваете все зелья что были под рукой!");
			Console.WriteLine($"Броня монстра уменьшена на {Power * 2}");
			Console.WriteLine($"Ваша броня увеличина на {Power * 2}");
			Console.WriteLine("Ваша сила магии увелчиина на 1!");
			Console.WriteLine();
		}
	}
}
