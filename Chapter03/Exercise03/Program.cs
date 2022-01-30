using System;
using System.Text;
using static System.Console;

namespace Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                divide by 3 = fizz
                divide by 5 = buzz
                divide by 3 and 5 = fizzbuzz
            */

            int length = 100;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= length; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    if (i % 3 == 0)
                    {
                        sb.Append("Fizz");
                    }
                    if (i % 5 == 0)
                    {
                        sb.Append("Buzz");
                    }
                }
                else
                {
                    sb.Append(i);
                }
                sb.Append(", ");
            }
            WriteLine(sb.ToString().TrimEnd(',', ' '));
        }
    }
}
