using System;
using System.Xml;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            object height = 1.88; //storing a double in an object
            object name = "Amir"; // storing a string in an object
            System.Console.WriteLine($"{name} is {height} metres tall.");

            //int length1 = name.Length; // gives compile error!
            int length2 = ((string)name).Length; // tell compiler it is a string
            System.Console.WriteLine($"{name} has {length2} characters.");

            dynamic anotherName = "Ahmed";
            int length = anotherName.Length;

            
            XmlDocument xml3 = new XmlDocument();
            // C# 9 feature - não precisa repetir
            XmlDocument xml4 = new();


        }
    }

}
