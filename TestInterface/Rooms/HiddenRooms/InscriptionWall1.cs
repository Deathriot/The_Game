using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms.HiddenRooms
{
	public class InscriptionWall1 : Room
	{
		public InscriptionWall1() : base(RoomType.Wall, 5,2,false,'-')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			if (!hero.TrueSight)
			{
				Console.WriteLine("Кажется, Это не просто стена. На ней выгравированы какие-то символы");
				Console.WriteLine("Но вы не можете их разобрать");
				return;
			}

			Console.WriteLine("на стене вы видете надпись:");
			Console.WriteLine("...укулас");
		}
	}
}
