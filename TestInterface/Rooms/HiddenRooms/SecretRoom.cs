using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms.HiddenRooms
{
	public class SecretRoom : Room
	{
		public SecretRoom() : base(RoomType.SecretRoom, 5, 2, true, '?')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("А это у нас комната с секретом, пока что невидимая.");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			
		}
	}
}
