using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyTools;


namespace Test2
{
	 class Program
	{
		static void ColourTest()
		{
			Write.Red("/Красный/");
			Write.DarkRed("/Темный красный/");
			Console.WriteLine();
			Write.Yellow("/Желтый/");
			Write.DarkYellow("/Темный желтый/");
			Console.WriteLine();
			Write.Cyan("/Циан/");
			Write.DarkCyan("/Темный циан/");
			Console.WriteLine();
			Write.Blue("/Синий/");
			Write.DarkBlue("/Темный синий/");
			Console.WriteLine();
			Write.Green("/Зеленый/");
			Write.DarkGreen("/Темный зеленый/");
			Console.WriteLine();
			Write.Magenta("/Фиолетовый/");
			Write.DarkMagenta("/Темный фиолетовый/");
			Console.ReadKey();
		}
		static void PrintScreamer()
		{

		}
		static void PrintBrew()
		{
			Console.ForegroundColor = ConsoleColor.White;
			string test = "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒/██/▒▒▒▒▒▒▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/██/▒▒▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒/██/▒▒▒▒/██/▒▒▒▒▒▒▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒/██/▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒▒▒/██/▒▒▒▒/██/▒▒▒▒▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒██████████████████▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒██████████████▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒██████████████████▒▒▒▒▒▒\r\n▒▒▒▒▒▒██████████████████▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒██████████████▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒▒▒██████████▒▒▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒▒▒██▒▒██▒▒██▒▒▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒██████████████▒▒▒▒▒▒▒▒\r\n▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\r\n";
			Write.Green(test);
			Console.ReadKey();
		}

		static void Main(string[] args)
		{
			PrintBrew(); 
		}
	}
}

