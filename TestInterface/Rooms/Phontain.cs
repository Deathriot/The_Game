using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class Phontain : Room
	{
		public Phontain() : base(RoomType.Phontain, 1, 4, false, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("Вы видете фонтан");
			Console.WriteLine("Этот фонтан будет давать какие-нибдуь плюшки.");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			base.Do(Hero, rooms);
		}
	}
}
