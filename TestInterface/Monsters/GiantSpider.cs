using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Monsters
{
	public class GiantSpider : Monster
	{
		int _poison = 0;
		public GiantSpider()
		{
			Type = MonsterType.GiantSpider;

			Health = 35;
			Armour = 1;
			Attack = 2;
			Exp = 50;
			Name = "Гигантский паук";
			Discription = " Каждый укус гигантского паука накладывает отравления";
		}
		public override void MonsterSkill(Character Hero)
		{
			if (_poison == 0)
			{
				Console.WriteLine("Гигантский паук вас отравляет! Вот-вот яд начнет действовать");
			}
			else
			{
				Console.WriteLine("Яд усиливается!");
				Console.WriteLine("Яд наносит вам {0} урона", _poison);
				Hero.Health -= _poison;
			}

			_poison++;
			Console.WriteLine();
		}
	}
}
