using static System.Console;
using System.Collections.Generic;

namespace WorkingWithDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var keywords = new Dictionary<string, string>();
            keywords.Add("int", "32-bit integer data type");
            keywords.Add("long", "64-bit integer data type");
            keywords.Add("float", "Single precision floating point number");

            WriteLine("Keywords and their definitions");
            foreach (var keyword in keywords)
            {
                WriteLine($"{keyword.Key}: {keyword.Value}");
            }
            WriteLine($"The definition of long is {keywords["long"]}");
        }
    }
}
