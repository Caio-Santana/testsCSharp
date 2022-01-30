using static System.Console;
using System;
using System.Linq;
using Packt.Shared;
using System.Text;

namespace MonitoringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            WriteLine("Processing. Please wait...");
            Recorder.Start();

            int[] largeArrayOfInts = Enumerable.Range(1, 10_000).ToArray();
            System.Threading.Thread.Sleep(new Random().Next(5, 10) * 1000);

            Recorder.Stop();
            */

            int[] number = Enumerable.Range(1, 50_000).ToArray();

            WriteLine("Using string with +");
            Recorder.Start();
            string s = "";
            for (int i = 0; i < number.Length; i++)
            {
                s += number[i] + ", ";
            }
            Recorder.Stop();

            WriteLine("Using StringBuilder");
            Recorder.Start();
            var builder = new StringBuilder();
            for (int i = 0; i < number.Length; i++)
            {
                builder.Append(number[i]);
                builder.Append(", ");
            }
            Recorder.Stop();
        }
    }
}
