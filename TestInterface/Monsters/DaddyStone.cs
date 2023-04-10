using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Monsters
{
	public class DaddyStone : Monster
	{
		public DaddyStone()
		{
			Type = MonsterType.Daddy;

			Health = 1000;
			Armour = 100;
			Attack = 100;
			Exp = 100;
			Name = "Злой папа кирпич";
			Discription = "Благославление кирпичных богов СтоунБрика делает папу кирпича неуязвимым и непобедимым";
		}
	}
}
