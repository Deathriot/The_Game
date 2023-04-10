

using System;
using System.Threading;

namespace MyTools
{

    /// <summary>
    /// Класс пишет текст выделенный /.../ разными цветами. Вместо * пишет нужный объект
    /// </summary>
    public static class Write
    {
        private static void ColourfulWrite(string value, ConsoleColor colour)
        {
            bool open = true;
            char[] charArray = value.ToCharArray();
            foreach (char c in charArray)
            {
                if (c != '/')
                {
                    Console.Write(c);
                }
                else
                {
                    if (open)
                    {
                        Console.ForegroundColor = colour;
                        open = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        open = true;
                    }
                }
            }
            Console.WriteLine();
        }
        private static void ColourfulWrite(string value, ConsoleColor colour, object obj)
        {
            bool open = true;
            char[] charArray = value.ToCharArray();
            foreach (char c in charArray)
            {
                if (c == '*')
                {
                    Console.Write(obj);
                }
                else if (c != '/')
                {
                    Console.Write(c);
                }
                else
                {
                    if (open)
                    {
                        Console.ForegroundColor = colour;
                        open = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        open = true;
                    }
                }
            }
            Console.WriteLine();
        }
        public static void Red(string value)
        {
            ColourfulWrite(value, ConsoleColor.Red);
        }
        public static void Blue(string value)
        {
            ColourfulWrite(value, ConsoleColor.Blue);
        }
        public static void Green(string value)
        {
            ColourfulWrite(value, ConsoleColor.Green);
        }
        public static void Cyan(string value)
        {
            ColourfulWrite(value, ConsoleColor.Cyan);
        }
        public static void Yellow(string value)
        {
            ColourfulWrite(value, ConsoleColor.Yellow);
        }
        public static void DarkCyan(string value)
        {
            ColourfulWrite(value, ConsoleColor.DarkCyan);
        }
        public static void Magenta(string value)
        {
            ColourfulWrite(value, ConsoleColor.Magenta);
        }
        public static void DarkYellow(string value)
        {
            ColourfulWrite(value, ConsoleColor.DarkYellow);
        }
        public static void DarkRed(string value)
        {
            ColourfulWrite(value, ConsoleColor.DarkRed);
        }
        public static void DarkBlue(string value)
        {
            ColourfulWrite(value, ConsoleColor.DarkBlue);
        }
        public static void DarkGreen(string value)
        {
            ColourfulWrite(value, ConsoleColor.DarkGreen);
        }
        public static void DarkMagenta(string value)
        {
            ColourfulWrite(value, ConsoleColor.DarkMagenta);
        }
        public static void Red(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.Red, obj);
        }
        public static void Blue(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.Blue, obj);
        }
        public static void Green(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.Green, obj);
        }
        public static void Cyan(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.Cyan, obj);
        }
        public static void Yellow(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.Yellow, obj);
        }
        public static void DarkCyan(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.DarkCyan, obj);
        }
        public static void Magenta(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.Magenta, obj);
        }
        public static void DarkYellow(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.DarkYellow, obj);
        }
        public static void DarkRed(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.DarkRed, obj);
        }
        public static void DarkBlue(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.DarkBlue, obj);
        }
        public static void DarkGreen(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.DarkGreen, obj);
        }
        public static void DarkMagenta(string value, object obj)
        {
            ColourfulWrite(value, ConsoleColor.DarkMagenta, obj);
        }
    }
    /// <summary>
    /// Рисует картинки или анимации
    /// </summary>
    public static class PrintPicture
    {
        public static void DaddyBrick()
        {
			string test = "████████████████████████████████\n████░░██░░░░░░░░░░░░░░░░██░░████\n██████████░░░░░░░░░░░░██████████\n██░░░░░░░░██░░░░░░░░██░░░░░░░░██\n██░░░░██░░░░██░░░░██░░░░██░░░░██\n████░░░░░░██░░░░░░░░██░░░░░░████\n██░░██████░░░░░░░░░░░░██████░░██\n██░░░░░░░░░░░░████░░░░░░░░░░░░██\n██░░░░░░░░░░░░████░░░░░░░░░░░░██\n██░░██░░██░░░░░░░░░░░░██░░██░░██\n████░░██░░████████████░░██░░████\n██░░██░░░░░░░░████░░░░░░░░██░░██\n██░░██░░░░░░░░░░░░░░░░░░░░██░░██\n██░░░░██░░██░░██░░██░░░░██░░░░██\n██░░░░░░████████████████░░░░░░██\n██████████░░░░░░░░░░░░██████████";
			for(int i = 0; i<7;i++)
			{
				Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
				Console.WriteLine(test);
				Thread.Sleep(70);
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.White;
				Console.WriteLine(test);
				Thread.Sleep(70);
				Console.Clear();
			}
            Console.ForegroundColor= ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
		}
    }
}