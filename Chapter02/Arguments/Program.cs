using System;
using static System.Console;

namespace Arguments
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            WriteLine($"There are {args.Length} arguments.");
            foreach (var item in args)
            {
                WriteLine(item);
            }
            */

            if (args.Length < 3)
            {
                WriteLine("You must specify two colors and cursor size, e.g.");
                WriteLine("dotnet run red yellow 50");
                return;
            }

            ForegroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: args[0],
                ignoreCase: true
            );

            BackgroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: args[1],
                ignoreCase: true
            );

            try
            {
                CursorSize = int.Parse(args[2]);
            }
            catch (PlatformNotSupportedException)
            {
                WriteLine("The current plataform does not support changing the size of the cursor.");
            }
        }
    }
}
