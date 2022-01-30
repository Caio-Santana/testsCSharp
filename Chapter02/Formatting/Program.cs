using System;

namespace Formatting
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfApples = 12;
            decimal pricePerApple = 0.35M;

            System.Console.WriteLine(
                format: "{0} apples costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples);

            string formmated = string.Format(
                format: "{0} apples costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples);

            string appleText = "Apples";
            int applesCount = 1234;

            string bananasText = "Bananas";
            int bananasCount = 56789;

            System.Console.WriteLine(
                format: "{0,-8} {1,6:N0}",
                arg0: "Name",
                arg1: "Count"
            );

            System.Console.WriteLine(
                format: "{0,-8} {1,6:N0}",
                arg0: appleText,
                arg1: applesCount
            );

            System.Console.WriteLine(
                format: "{0,-8} {1,6:N0}",
                arg0: bananasText,
                arg1: bananasCount
            );

            Console.Write("Press any key combination: ");
            ConsoleKeyInfo key = Console.ReadKey();
            System.Console.WriteLine();
            System.Console.WriteLine($"Key: {key.Key}, Char: {key.KeyChar}, Modifier: {key.Modifiers}.");

        }
    }
}
