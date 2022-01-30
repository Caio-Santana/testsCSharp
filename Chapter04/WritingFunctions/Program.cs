using System;
using static System.Console;

namespace WritingFunctions
{
    class Program
    {

        static int[] vendasVendedores;
        static void Main(string[] args)
        {
            //RunTimesTable();
            //RunCalculateTax();
            //RunCardinalToOrdinal();
            //RunFatorial();
            //RunFibImperative();
            RunFibFuncional();
        }

        static void TimesTable(byte number)
        {
            WriteLine($"This is the {number} times table:");
            for (int row = 1; row <= 12; row++)
            {
                WriteLine($"{row} x {number} = {row * number}");
            }
            WriteLine();
        }

        static void RunTimesTable()
        {
            bool isNumber;
            do
            {
                Write("Enter a number between 0 and 255: ");

                isNumber = byte.TryParse(ReadLine(), out byte number);
                if (isNumber)
                {
                    TimesTable(number);
                }
                else
                {
                    WriteLine("You did not enter a valid number!");
                }
            } while (isNumber);
        }

        static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
        {
            decimal rate = 0.0M;

            switch (twoLetterRegionCode)
            {
                case "CH":          // Switzerland
                    rate = 0.08M;
                    break;
                case "DK":          // Denmark
                case "NO":          // Norway
                    rate = 0.25M;
                    break;
                case "GB":          // United Kingdom
                case "FR":          // France
                    rate = 0.2M;
                    break;
                case "HU":          // Hungary
                    rate = 0.27M;
                    break;
                case "OR":          // Oregon
                case "AK":          // Alaska
                case "MT":          // Montana
                    rate = 0.0M;
                    break;
                case "ND":          // North Dakota
                case "WI":          // Wisconsin
                case "ME":          // MaryLand
                case "VA":          // Virginia
                    rate = 0.05M;
                    break;
                case "CA":          // California
                    rate = 0.0825M;
                    break;
                default:            // most US states
                    rate = 0.06M;
                    break;
            }

            return amount * rate;
        }

        static void RunCalculateTax()
        {
            Write("Enter an amount: ");
            string amountInText = ReadLine();

            WriteLine("Enter a two-letter region code: ");
            string region = ReadLine();

            if (decimal.TryParse(amountInText, out decimal amount))
            {
                decimal taxToPay = CalculateTax(amount, region);
                WriteLine($"You must pay {taxToPay} in sales tax.");
            }
            else
            {
                WriteLine("You did not enter a valid amount.");
            }
        }

        /// <summary>
        /// Pass a 32-bit integer and it will be converted into its ordinal equivalent.
        /// </summary>
        /// <param name="number">Number is a cardinal value e.g. 1, 2, 3, and so on.</param>
        /// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.</returns>
        static string CardinalToOrdinal(int number)
        {
            switch (number)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    int lastDigit = number % 10;

                    string suffix = lastDigit switch
                    {
                        1 => "st",
                        2 => "nd",
                        3 => "rd",
                        _ => "th",
                    };
                    return $"{number}{suffix}";
            }
        }

        static void RunCardinalToOrdinal()
        {
            for (int number = 1; number < 40; number++)
            {
                Write($"{CardinalToOrdinal(number)} ");
            }
            WriteLine();
        }

        static int Fatorial(int number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                checked
                {
                    return number * Fatorial(number - 1);
                }
            }
        }

        static void RunFatorial()
        {
            for (int i = 0; i < 15; i++)
            {
                try
                {
                    WriteLine($"{i}! = {Fatorial(i):N0}");
                }
                catch (OverflowException)
                {
                    WriteLine($"{i}! is too big for a 32-bit integer.");
                }
            }
        }
        static int FibImperative(int term)
        {
            if (term == 1)
            {
                return 0;
            }
            else if (term == 2)
            {
                return 1;
            }
            else
            {
                return FibImperative(term - 1) + FibImperative(term - 2);
            }
        }

        static void RunFibImperative()
        {
            for (int i = 1; i <= 30; i++)
            {
                WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
                arg0: CardinalToOrdinal(i),
                arg1: FibImperative(term: i));
            }
        }

        static int FibFuncional(int term) =>
        term switch
        {
            1 => 0,
            2 => 1,
            _ => FibFuncional(term - 1) + FibFuncional(term - 2)
        };
        
        static void RunFibFuncional() 
        {
            for (int i = 1; i <= 30; i++)
            {
                WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
                arg0: CardinalToOrdinal(i),
                arg1: FibFuncional(term: i));
            }
        }
    }
}
