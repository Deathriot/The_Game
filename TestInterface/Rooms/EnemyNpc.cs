using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms
{
	public class EnemyNpc : Room
	{
		public EnemyNpc() : base(RoomType.EnemyNpc, 2, 2, true, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("Вы встретили типичного тупорылого гоблина");
			Console.WriteLine("Однако он не выглядит опасно, наоборот, судя по виду, он очень доволен");
			Console.WriteLine("Как был бы доволен разбойник, который ограбил королевский караван без охраны.");
			Console.WriteLine();
			Console.WriteLine("Агрессии это зеленое чудо не источает, возможно с ним даже можно будет поговорить.");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			base.Do(Hero, rooms);
		}
	}
}
