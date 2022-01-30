using System;
using System.Linq;
using static System.Console;
using static System.Convert;

namespace CastingConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            double b = a;
            WriteLine(b);

            b = 3.5;
            //explicit cast
            WriteLine(b);
            a = (int)b; // loses the .5
            WriteLine(a);

            //System.Convert
            double g = 9.8;
            int h = ToInt32(g); // rounded 

            WriteLine($"g is {g}. h is {h}.");


            double[] doubles = new[]
             { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };

            foreach (var n in doubles)
            {
                WriteLine($"ToInt32({n}) is {ToInt32(n)}");
            }

            foreach (var n in doubles)
            {
                WriteLine(
                    format: "Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
                    arg0: n,
                    arg1: Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero)
                );
            }

            int number = 12;
            WriteLine(number.ToString());

            bool boolean = true;
            WriteLine(boolean.ToString());

            DateTime now = DateTime.Now;
            WriteLine(now.ToString());

            object me = new object();
            WriteLine(me.ToString());


            byte[] binaryObject = new byte[2];

            (new Random()).NextBytes(binaryObject);

            WriteLine("Binary Object as bytes:");

            for (int index = 0; index < binaryObject.Length; index++)
            {
                Write($"{binaryObject[index]:X} ");
            }
            WriteLine();

            string encoded = Convert.ToBase64String(binaryObject);

            WriteLine($"Binary Object as Base64: {encoded}");

            foreach (var bt in Convert.FromBase64String(encoded))
            {
                Write($"{bt:X} ");
            }


            int age = int.Parse("27");
            DateTime birthday = DateTime.Parse("4 July 1980");

            WriteLine($"I was born {age} years ago.");
            WriteLine($"My birthday is {birthday}.");
            WriteLine($"My birthday is {birthday:D}.");

            WriteLine("How many eggs are there? ");
            string input = ReadLine();

            int count;
            if (int.TryParse(input, out count))
            {
                WriteLine($"There are {count} eggs.");
            }
            else
            {
                WriteLine("I Could not parse the input.");
            }
        }
    }
}
