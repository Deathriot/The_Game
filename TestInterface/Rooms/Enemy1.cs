using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class Enemy1 : Room
	{
		public Enemy1() : base(RoomType.Enemy1, 1, 3, false, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("перед вами разъяренный огромный паук, из мандибул которого сочится едкий яд.");
			Console.WriteLine("Проскочить мимо него не получится...");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			base.Do(Hero, rooms);
		}
	}
}
