using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms.HiddenRooms.BehindFakeWallRooms
{
	public class EmptyRoom2 : Room
	{
		public EmptyRoom2() : base(HiddenRoomType.EmptyRoom2, 1, 2, true, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("В этой комнате ничего нет...");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			Console.WriteLine("здесь тоже ничего, может хватит осматривать пустые комнаты?");
		}
	}
}
