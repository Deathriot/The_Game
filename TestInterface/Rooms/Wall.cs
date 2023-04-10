using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class Wall : Room
	{
		public Wall() : base(RoomType.Wall, -1, -1, false, '-')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("Перед вами обычная стена");
			Console.WriteLine();
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			Console.WriteLine("Сюда невозможно попасть!!!");
			Console.WriteLine("Ашибка! Ашибка!");
			Console.ReadKey();
			throw new NotSupportedException();
		}
	}
}
