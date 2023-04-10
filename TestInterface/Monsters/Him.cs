using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_Witch_Tale.Monsters
{
	public class Him : Monster
	{
		public Him()
		{
			Type = MonsterType.Him;

			Health = 1000;
			Armour = 1000;
			Attack = 0;
			Exp = 50;
			Name = "Неизвестный";
			Discription = "Нелепая судьба обрекла его на долгие муки. Вы покончите с его страданиями";
		}
		public override void MonsterSkill(Character Hero)
		{
			Console.WriteLine("Не успели вы произнести заклинание, как Он подходит к вам вплотную. Все заклинания против него бесполезны, они отскакивают от Него");
			Console.WriteLine("Он останавливается прямо перед твоим носом и сверлит тебя взглядом.");
			Console.WriteLine("Его глазницы пусты, губы иссохшие и тонкие, от Него веет могильным холодом и незнакомой для вас магией");
			Console.WriteLine("Вдруг, он протягивает к вам руку...");
			Console.ReadKey();
			Console.WriteLine("ТЫ ПОНЯТИЯ НЕ ИМЕЕШЬ, ВО ЧТО ТЫ ВВЯЗЫВАЕШЬСЯ. ПРОКЛЯТИЕ ЭТОГО МЕСТО ПОГЛОТИТ ТЕБЯ, КАК И ВСЕХ НАС");
			Console.WriteLine("ЭТА МАГИЯ ВЫШЕ ТВОЕГО ПОНИМАНИЯ. НЕ СМЕЙ ЕЕ ИСПОЛЬЗОВАТЬ. НЕ СМЕЙ ЕЕ ИСПОЛЬЗОВАТЬ. ОНО ПОГЛОТИТ ТЕБЯ");
			Console.ReadKey();
			for (int i = 0; i < 300; i++)
			{
				Console.WriteLine("             ТЕБЯ ОНО ПОГЛОТИТ             ТЕБЯ ОНО ПОГЛОТИТ             ТЕБЯ ОНО ПОГЛОТИТ             ТЕБЯ ОНО ПОГЛОТИТ             ТЕБЯ ОНО ПОГЛОТИТ");
				Console.WriteLine("ОНО ПОГЛОТИТ ТЕБЯ             ОНО ПОГЛОТИТ ТЕБЯ             ОНО ПОГЛОТИТ ТЕБЯ             ОНО ПОГЛОТИТ ТЕБЯ             ОНО ПОГЛОТИТ ТЕБЯ             ");
				Console.WriteLine();
				Thread.Sleep(1);
			}
			Console.Clear();
			Console.ReadKey();
			Console.WriteLine("Отойдя от шока, вы обнаружили, что Eго больше нет. А в руках у вас вдруг появился осколов амулета.");
			Console.WriteLine("Что здесь вообще творится?");
			Hero.AmuletShardFound();
			Health = 0;
		}
	}
}
