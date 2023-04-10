using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms.HiddenRooms.BehindFakeWallRooms
{
	public class EmptyRoom1 : Room
	{
		public EmptyRoom1() : base(HiddenRoomType.EmptyRoom1, 1,1,true,' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("В этой комнате ничего нет...");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			Console.WriteLine("здесь правда ничего нет, двигайся дальше!");
		}
	}
}
