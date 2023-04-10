using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms.HiddenRooms.BehindFakeWallRooms
{
	public class Treassure : Room
	{
		public Treassure() : base(HiddenRoomType.Treassure, 1, 5, true, '!')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("Сокровище!");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{

		}
	}
}
