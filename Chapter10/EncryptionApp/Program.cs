using System;
using static System.Console;
using System.Security.Cryptography;
using Packt.Shared;

namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a message that you want to encrypt: ");
            string message = ReadLine();

            Write("Enter a password: ");
            string password = ReadLine();

            string cryptoText = Protector.Encrypt(message, password);

            WriteLine($"Encrypted text: {cryptoText}");

            Write("Enter the password: ");
            string password2 = ReadLine();

            try
            {
                string clearText = Protector.Decrypt(cryptoText, password2);
                WriteLine($"Decrypted text: {clearText}");
            }
            catch (CryptographicException ex)
            {
                WriteLine("{0}\nMore details: {1}", "You entered the wrong password!", ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine("Non-cryptographic exception: {0}, {1}", ex.GetType().Name, ex.Message);
            }
        }
    }
}
