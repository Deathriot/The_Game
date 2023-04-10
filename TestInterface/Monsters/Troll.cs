using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Monsters
{
	public class Troll : Monster
	{
		public Troll()
		{
			Type = MonsterType.Troll;

			Health = 40;
			Armour = 0;
			Attack = 4;
			Exp = 50;
			Name = "Тролль";
			Discription = "Большой, зеленый и толстый. Полностью регенирирует свое здоровье каждый ход";
		}
		public override void MonsterSkill(Character Hero)
		{
			if (Health != 40)
			{
				Health = 40;
				Console.WriteLine();
				Console.WriteLine("Тролль полностью восстановил свое здоровье!");
				Console.WriteLine("По-моему это нечестно.");
				Console.WriteLine();
			}
		}
	}
}
