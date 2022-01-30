using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names;

            names = new string[4];

            names[0] = "Kate";
            names[1] = "Jack";
            names[2] = "Rebecca";
            names[3] = "Tom";

            for (int i = 0; i < names.Length; i++)
            {
                System.Console.WriteLine(names[i]);
            }
        }
    }
}
