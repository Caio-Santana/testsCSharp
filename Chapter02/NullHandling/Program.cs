using System;

#nullable enable

namespace NullHandling
{
    class Address
    {
        public string? Building;
        public string Street = string.Empty;
        public string City = string.Empty;
        public string Region = string.Empty;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int thisCannotBeNull = 4;
            //thisCannotBeNull = null;

            //int? thisCanBeNull = null;
            //System.Console.WriteLine(thisCanBeNull);
            //System.Console.WriteLine(thisCanBeNull.GetValueOrDefault());

            //var address = new Address();
            //address.Building = null;
            //address.Street = null;
            //address.City = "London";
            //address.Region = null;
            
            //int? y = address.Building?.Length;
        }
    }
}
