using static System.Console;
using System;

namespace WorkingWithRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Samantha Jones";

            int lengthOfFirst = name.IndexOf(' ');
            int lengthOfLast = name.Length - lengthOfFirst - 1;
            string firstName = name.Substring(startIndex: 0, length: lengthOfFirst);
            string lastName = name.Substring(startIndex: name.Length - lengthOfLast, length: lengthOfLast);
            WriteLine($"First name: {firstName}, Last name: {lastName}");

            ReadOnlySpan<char> nameAsSpan = name.AsSpan();
            var firstNameAsSpan = nameAsSpan[0..lengthOfFirst];
            var lastNameAsSpan = nameAsSpan[^lengthOfLast..^0];
            WriteLine("First name: {0}, Last name: {1}", firstNameAsSpan.ToString(), lastNameAsSpan.ToString());
        }
    }
}
