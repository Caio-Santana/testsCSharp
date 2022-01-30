using static System.Console;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace LinqInParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            Write("Press ENTER to start: ");
            ReadLine();
            watch.Start();

            IEnumerable<int> numbers = Enumerable.Range(1, 2_000_000);

            var squares = numbers
                //.AsParallel()
                .Select(number => number * 2).ToArray();

            watch.Stop();
            WriteLine("{0:#,##0} elapsed milliseconds.", watch.ElapsedMilliseconds);
        }
    }
}
