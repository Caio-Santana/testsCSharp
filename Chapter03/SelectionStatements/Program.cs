using System;
using static System.Console;
using System.IO;

namespace SelectionStatements
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\caios\Desktop\ProjetosC#\Code\Chapter03";
            Write("Press R for readonly or W for write: ");
            ConsoleKeyInfo key = ReadKey();
            WriteLine();

            Stream s = null;

            if (key.Key == ConsoleKey.R)
            {
                s = File.Open(
                    Path.Combine(path, "file.txt"),
                    FileMode.OpenOrCreate,
                    FileAccess.Read
                );
            }
            else
            {
                s = File.Open(
                    Path.Combine(path, "file.txt"),
                    FileMode.OpenOrCreate,
                    FileAccess.Write
                );
            }

            string message = string.Empty;

            switch (s)
            {
                case FileStream writeableFile when s.CanWrite:
                    message = "The stream is a file that I can Write to.";
                    break;
                case FileStream readOnlyFile:
                    message = "The stream is a read-only file.";
                    break;
                case MemoryStream ms:
                    message = "The stream is a memory address.";
                    break;
                default: //always evaluated last despite its current position
                    message = "The stream is some other type.";
                    break;
                case null:
                    message = "The stream is null.";
                    break;
            }
            WriteLine(message);


            message = s switch
            {
                FileStream writeableFile when s.CanWrite
                  => "The stream is a file that I can Write to.",
                FileStream readOnlyFile
                  => "The stream is a read-only file.",
                MemoryStream ms
                  => "The stream is a memory address.",
                null
                  => "The stream is null.",
                _
                  => "The stream is some other type."
            };
            WriteLine(message);

            object o = 3;
            int j = 4;

            if (o is int i)
            {
                System.Console.WriteLine($"{i} x {j} = {i * j}");
            }
            else
            {
                System.Console.WriteLine("o is not an int so it cannot multiply!");
            }




        A_label:
            var number = (new Random()).Next(1, 7);
            System.Console.WriteLine($"My random number is {number}.");

            switch (number)
            {
                case 1:
                    System.Console.WriteLine("One");
                    break;
                case 2:
                    System.Console.WriteLine("Two");
                    goto case 1;
                case 3:
                case 4:
                    System.Console.WriteLine("Three or four");
                    goto case 1;
                case 5:
                    System.Threading.Thread.Sleep(500);
                    goto A_label;
                default:
                    System.Console.WriteLine("Default");
                    break;
            }

        }
    }
}
