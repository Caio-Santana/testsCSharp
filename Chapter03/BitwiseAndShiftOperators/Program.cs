using System;

namespace BitwiseAndShiftOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10; // 0000 1010
            int b = 6;  // 0000 0110

            //bitwise
            System.Console.WriteLine($"a = {a}");
            System.Console.WriteLine($"b = {b}");
            System.Console.WriteLine($"a & b = {a & b}"); // = 2  - usando o & - pois olhando binariamente os valores de 'a' e 'b' apenas o bit do 2 estão ativos em ambos
            System.Console.WriteLine($"a | b = {a | b}"); // = 14 - usando o | - pois olhando binariamente os valores de 'a' e 'b' os bits do 8 4 e 2 estão ativos em 'a' ou 'b' ou ambos
            System.Console.WriteLine($"a ^ b = {a ^ b}"); // = 12 - usando o ^ - pois olhando binariamente os valores de 'a' e 'b' os bits do 8 e 4 estão ativos, este é exclusivo, não conta se ambos estiverem ativos

            //binary shift
            System.Console.WriteLine($"a << 3 = {a << 3}"); // empurrando os bits que representam o 'a' 3 casas para a esquerda temos 0101 0000, fica ativo o bit de 64 e 16 = 80
            System.Console.WriteLine($"b >> 1 = {b >> 1}"); // empurrando os bits que representam o 'b' 1 casa para a direita temos 0000 0011, fica ativo o bit de 2 e 1 = 3

        }
    }
}
