using System;
using static System.Console;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            string fmt = "{0,-10} {1,-30} {2,30} {3,30}";

            WriteLine();

            WriteLine(
                format: fmt,
                "Type", "Byte(s) of memory", "Min", "Max"
            );

            WriteLine();

            WriteLine(
                format: fmt,
                typeof(sbyte).Name, sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue
            );
            WriteLine(
                format: fmt,
                typeof(byte).Name, sizeof(byte), byte.MinValue, byte.MaxValue
            );
            WriteLine(
                format: fmt,
                typeof(short).Name, sizeof(short), short.MinValue, short.MaxValue
            );
            WriteLine(
                format: fmt,
                typeof(ushort).Name, sizeof(ushort), ushort.MinValue, ushort.MaxValue
            );
            WriteLine(
                format: fmt,
                typeof(int).Name, sizeof(int), int.MinValue, int.MaxValue
            );
            WriteLine(
                format: fmt,
                typeof(uint).Name, sizeof(uint), uint.MinValue, uint.MaxValue
            );
            WriteLine(
                format: fmt,
                typeof(long).Name, sizeof(long), long.MinValue, long.MaxValue
            );
            WriteLine(
                format: fmt,
                typeof(ulong).Name, sizeof(ulong), ulong.MinValue, ulong.MaxValue
            );
            WriteLine(
                format: fmt,
                typeof(float).Name, sizeof(float), float.MinValue, float.MaxValue
            );
            WriteLine(
                format: fmt,
                typeof(double).Name, sizeof(double), double.MinValue, double.MaxValue
            );
            WriteLine(
                format: fmt,
                typeof(decimal).Name, sizeof(decimal), decimal.MinValue, decimal.MaxValue
            );
            
            WriteLine();
        }
    }
}
