using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms.HiddenRooms.BehindFakeWallRooms
{
	public class EmptyRoom4 : Room
	{
		public EmptyRoom4() : base(HiddenRoomType.EmptyRoom4, 1, 4, true, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("В этой комнате ничего нет...");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			Console.WriteLine("И здесь ничего!");
		}
	}
}
