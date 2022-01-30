using System;
using static System.Console;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            //WriteLine(byte.MaxValue);

            int max = 500;
            try
            {
                checked
                {
                    for (byte i = 0; i < max; i++)
                    {
                        WriteLine(i);
                    }
                }
            }
            catch (System.Exception ex)
            {
                WriteLine($"Tipo: {ex.GetType()}, Message: {ex.Message}");
            }
        }
    }
}
