using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class Empty2 : Room
	{
		public Empty2() : base(RoomType.Empty2, 4, 3, false, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("Эту комнату я придумаю позже");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			base.Do(Hero, rooms);
		}
	}
}
