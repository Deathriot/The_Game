using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale.Rooms.HiddenRooms.BehindFakeWallRooms
{
	public class EmptyRoom3 : Room
	{
		bool _firstTimeDrink = false; // Выпито ли зелье
		public EmptyRoom3() : base(HiddenRoomType.EmptyRoom3, 1, 3, true, ' ')
		{

		}
		public override void Info(Character hero, RoomsManager rooms)
		{
			Console.WriteLine("В этой комнате ничего нет... Наверное");
		}
		public override void Do(Character Hero, RoomsManager rooms)
		{
			if (!_firstTimeDrink)
			{
				Console.WriteLine("Что ж, ваша упертость была вознаграждена...");
				Console.WriteLine("В пыльном углу всеми богами забытой команты вы нашли зелье здоровья.");
				Console.WriteLine("Вы незамедлительно выпиваете его и чувствуете, как вы становитесь сильнее!");
				Hero.HealthUp(2);
				_firstTimeDrink = true;
				return;
			}

			Console.WriteLine("нет, здесь вы точно больше ничего не найдете.");
			
		}
	}
}
