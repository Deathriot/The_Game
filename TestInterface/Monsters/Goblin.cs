using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Monsters
{
	public class Goblin : Monster
	{
		public Goblin()
		{
			Type = MonsterType.Goblin;

			Health = 20;
			Armour = 0;
			Attack = 3;
			Exp = 30;
			Discription = "Зелёный. Кроме этого делать ничего особо не умеет";
			Name = "Гоблин";
		}
	}
}
