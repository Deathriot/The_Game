using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class Enemy2 : Room
	{
		public Enemy2() : base(RoomType.Enemy2, 3, 3, false, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("Вы встречаете врага, какого, я еще не придумал");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			base.Do(Hero, rooms);
		}
	}
}
