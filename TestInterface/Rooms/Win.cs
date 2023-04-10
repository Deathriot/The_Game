using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class Win : Room
	{
		public Win() : base(RoomType.Win, 4, 4, false, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("А в эту победную комнату можно будет попасть если победить босса.");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			base.Do(Hero, rooms);
		}
	}
}
