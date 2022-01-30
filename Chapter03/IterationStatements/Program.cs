using System;
using System.Collections.Generic;
using static System.Console;

namespace IterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Adam", "Charlie", "Barry" };
            foreach (var name in names)
            {
                WriteLine($"Name {name} has {name.Length} characters.");
            }

            //PasswordExampleDoWhile();
        }

        private static void PasswordExampleDoWhile()
        {
            string password = string.Empty;
            int i = 0;
            do
            {
                i++;
                Write($"{i} - Enter your password: ");
                password = ReadLine();
            }
            while (password != "senha" && i < 5);

            if (password != "senha" && i >= 5)
            {
                WriteLine("No more tries.");
                return;
            }
            WriteLine("Correct!");
        }
    }
}
