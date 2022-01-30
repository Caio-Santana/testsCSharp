using System;
using static System.Console;

namespace Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Write("Enter a number between 0 and 255: ");
                string input1 = ReadLine();
                Write("Enter another number between 0 and 255: ");
                string input2 = ReadLine();

                WriteLine($"{input1} divided by {input2} is {int.Parse(input1) / int.Parse(input2)}");

            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType().Name}: {ex.Message}");
            }

            int x, y;

            x = 3;
            y = 2 + (++x);
            WriteLine(y); // 6

            x = 3 << 2;   // 0000 0011
            y = 10 >> 1;  // 0000 1010
            WriteLine(x); // 0000 1100 = 12
            WriteLine(y); // 0000 0101 = 5

            x = 10 & 8;   // 0000 1010 & 0000 1000
            y = 10 | 7;   // 0000 1010 | 0000 0111
            WriteLine(x); // 0000 1000 = 8
            WriteLine(y); // 0000 1111 = 15

        }
    }
}
