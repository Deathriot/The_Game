using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Witch_Tale.Rooms.HiddenRooms.BehindFakeWallRooms;

namespace The_Witch_Tale.Monsters
{
	public class Guard : Monster
	{
		public static bool Weaked = false; // Был ли страж ослаблен заклинанием
		public Guard() 
		{
			Type = MonsterType.TreassureGuard;

			Health = 70;

			if (!Weaked)
			{
				Armour = 3;
			}
			else
			{
				Armour = 0;
			}
			
			Attack = 6;
			Exp = 150;

			Name = "Страж СтоунБрик";
			Discription = "Легендарный страж алтаря давно забытого бога кирпичей";
		}
	}
}
