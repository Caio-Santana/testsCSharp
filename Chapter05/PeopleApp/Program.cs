using static System.Console;
using System;
using Packt.Shared;
using System.Collections.Generic;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            WriteLine($"{bob.Name} is a {Person.Species}.");
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");
            WriteLine(
                format: "{0} was born on {1:dddd, d MMMM yyyy}",
                arg0: bob.Name,
                arg1: bob.DateOfBirth
            );
            bob.FavoriteAncientWonder = WondersOfTheAncientWorld.SatueOfZeusAtOlympia;
            WriteLine(
                format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
                arg0: bob.Name,
                arg1: bob.FavoriteAncientWonder,
                arg2: (int)bob.FavoriteAncientWonder
            );
            bob.BucketList = WondersOfTheAncientWorld.HangingGardenOfBabylon
                            | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
            bob.Children = new List<Person>() {
                new Person {Name = "Lisa" },
                new Person {Name = "Junior"}
            };
            WriteLine($"{bob.Name} has {bob.Children.Count} children:");
            for (int child = 0; child < bob.Children.Count; child++)
            {
                WriteLine($"   {bob.Children[child].Name}");
            }


            Person alice = new Person
            {
                Name = "Alice Smith",
                DateOfBirth = new DateTime(1970, 5, 10)
            };
            WriteLine(
                format: "{0} was born on {1:dddd, d MMMM yyyy}",
                arg0: alice.Name,
                arg1: alice.DateOfBirth
            );
            alice.Children = new List<Person>() {
                new Person {Name = "Bill" },
                new Person {Name = "Mary"}
            };
            WriteLine($"{alice.Name} has {alice.Children.Count} children:");
            foreach (var child in alice.Children)
            {
                WriteLine($"   {child.Name}");
            }


            BankAccount.InterestRate = 0.012M;

            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            WriteLine(
                format: "{0} earned {1:C} interest.",
                arg0: jonesAccount.AccountName,
                arg1: jonesAccount.Balance * BankAccount.InterestRate
            );

            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;
            WriteLine(
                format: "{0} earned {1:C} interest.",
                arg0: gerrierAccount.AccountName,
                arg1: gerrierAccount.Balance * BankAccount.InterestRate
            );


            var blankPerson = new Person();
            WriteLine(
                format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0: blankPerson.Name,
                arg1: blankPerson.HomePlanet,
                arg2: blankPerson.Instantiated
            );
            var gunny = new Person("Gunny", "Mars");
            WriteLine(
                format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0: gunny.Name,
                arg1: gunny.HomePlanet,
                arg2: gunny.Instantiated
            );

            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());
            //WriteLine($"{bob.GetFruit().Item1}, {bob.GetFruit().Item2} there are.");
            (string, int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

            var fruitNamed = bob.GetNamedFruit();
            WriteLine($"{fruitNamed.Name}, {fruitNamed.Number} there are.");

            var thing1 = ("Neville", 4);
            WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

            var thing2 = (bob.Name, bob.Children.Count);
            WriteLine($"{thing2.Name} has {thing2.Count} children.");

            (string fruitName, int fruitNumber) = bob.GetFruit();
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}.");

            WriteLine(bob.SayHello());
            WriteLine(bob.SayHello("Overload"));
            WriteLine(bob.SayHelloTo("Emily"));
            WriteLine(bob.OptionalParameters());
            WriteLine(bob.OptionalParameters("Fire!"));
            WriteLine(bob.OptionalParameters("Fire!", 23, false));
            WriteLine(bob.OptionalParameters(number: 66));
            WriteLine(bob.OptionalParameters("Jump!", active: false));

            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Before: a = {a}, b = {b}, c = {c}");
            bob.PassingParameters(a, ref b, out c);
            WriteLine($"After: a = {a}, b = {b}, c = {c}");

            var sam = new Person();
            sam.Name = "Sam";
            sam.DateOfBirth = new DateTime(1991, 10, 23);
            WriteLine(sam.Origin);
            WriteLine(sam.Age);
            WriteLine(sam.Greeting);
            sam.FavoriteIceCream = "Chocolate";
            sam.FavoritePrimaryColor = "Red";
            WriteLine($"{sam.Name} favorite ice cream flavor is {sam.FavoriteIceCream}");
            WriteLine($"{sam.Name} favorite primary color is {sam.FavoritePrimaryColor}");
            sam.Children.Add(new Person { Name = "Charlie" });
            sam.Children.Add(new Person { Name = "Ella" });
            WriteLine($"{sam.Name} first child is {sam.Children[0].Name}");
            WriteLine($"{sam.Name} second child is {sam.Children[1].Name}");
            WriteLine($"{sam.Name} first child is {sam[0].Name}");
            WriteLine($"{sam.Name} second child is {sam[1].Name}");

            object[] passengers = {
                new FirstClassPassenger { AirMiles = 1_419 },
                new FirstClassPassenger { AirMiles = 16_562 },
                new BussinessClassPassenger(),
                new CoachClassPassenger { CarryOnKG = 25.7 },
                new CoachClassPassenger { CarryOnKG = 0 }
            };
            foreach (object passenger in passengers)
            {
                decimal flightCost = passenger switch
                {
                    // C# 8 syntax
                    //FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
                    //FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
                    //FirstClassPassenger _                         => 2000M,

                    // C# 9 syntax
                    FirstClassPassenger p => p.AirMiles switch
                    {
                        > 35000 => 1500M,
                        > 15000 => 1750M,
                        _ => 2000M
                    },
                    BussinessClassPassenger _ => 1000M,
                    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
                    CoachClassPassenger _ => 650M,
                    _ => 800M
                };

                WriteLine($"Flight costs {flightCost:C} for {passenger}");
            }

            var jeff = new ImmutablePerson { FirstName = "Jeff" };
            //jeff.FirstName = "Mike"; erro!

            var car = new ImmutableVehicle
            {
                Brand = "Mazda MX-5 RF",
                Color = "Soul Red Crystal Metallic",
                Wheels = 4
            };

            var repaintedCar = car with { Color = "Polymetal Grey Metallic" };

            WriteLine(
                format: "Original color was {0}, new color is {1}.",
                arg0: car.Color,
                arg1: repaintedCar.Color
            );

            var oscarAnimal = new ImmutableAnimal("Oscar", "Labrador");
            var (who, what) = oscarAnimal;
            WriteLine($"{who} is a {what}");

            var book = new ImmutableBook("Packt C# Book", 750);
            var (title, pages) = book;
            WriteLine($"{title} has {pages} pages.");

            Person.Procreate(sam, alice);
            alice.ProcreateWith(sam);
            foreach (var kid in sam.Children)
            {
                WriteLine(kid.Name);
            }
            var baby1 = bob * alice;
            WriteLine(baby1.Name);

            WriteLine(bob + alice);

            WriteLine($"5! is {Person.Factorial(5)}");

            bob.Shout += Bob_Shout;
            bob.Poke();
            bob.Poke();
            bob.Poke();
            bob.Poke();

            Person[] people = {
                new Person { Name = "Simon" },
                new Person { Name = "Jenny" },
                new Person { Name = "Adam" },
                new Person { Name = "Richard" }
            };

            WriteLine("Initial list of people:");
            foreach (var person in people)
            {
                WriteLine($"  {person.Name}");
            }

            WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach (var person in people)
            {
                WriteLine($"  {person.Name}");
            }

            WriteLine("Use PersonComparer IComparer implementation to sort:");
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($"  {person.Name}");
            }

            IPlayable dvdPlayer = new DvdPlayer();
            dvdPlayer.Play();
            dvdPlayer.Pause();
            dvdPlayer.Stop();

            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with a integer: {t1.Process(42)}");
            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with a string: {t2.Process("apple")}");

            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with a integer: {gt1.Process(42)}");
            var gt2 = new GenericThing<string>();
            gt2.Data = "apple";
            WriteLine($"GenericThing with a string: {gt2.Process("apple")}");

            string number1 = "4";
            WriteLine(
                format: "{0} squared is {1}",
                arg0: number1,
                arg1: Squarer.Square<string>(number1)
            );
            string number2 = "3";
            WriteLine(
                format: "{0} squared is {1}",
                arg0: number2,
                arg1: Squarer.Square(number2)
            );

            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

            Employee john = new Employee
            {
                Name = "John Jones",
                DateOfBirth = new DateTime(1990, 7, 28)
            };
            john.WriteToConsole();
            john.EmployeeCode = "JJ001";
            john.HireDate = new DateTime(2014, 11, 23);
            WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yyyy}");
            WriteLine(john.ToString());


            Employee aliceInEmployee = new Employee
            {
                Name = "Alice",
                EmployeeCode = "AA123"
            };

            Person aliceInPerson = aliceInEmployee;

            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            WriteLine(aliceInEmployee.ToString());
            WriteLine(aliceInPerson.ToString());

            if (aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee.");
                Employee explicitAlice = (Employee)aliceInPerson;
            }

            Employee aliceAsEmployee = aliceInPerson as Employee;
            if (aliceAsEmployee != null)
            {
                WriteLine($"{nameof(aliceInPerson)} AS an Employee.");
            }

            aliceInPerson = new Person();
            if (aliceInPerson is not Employee)
            {
                WriteLine("she is not a Employee anymore");
            }

            try
            {
                john.TimeTravel(new DateTime(1999, 11, 20));
                john.TimeTravel(new DateTime(1980, 5, 4));
            }
            catch (PersonException ex)
            {
                WriteLine(ex.Message);
            }

            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";
            WriteLine(
                format:"{0} is a valid e-mail address: {1}",
                arg0: email1,
                arg1: StringExtensions.IsValidEmail(email1)
            );
            WriteLine(
                format:"{0} is a valid e-mail address: {1}",
                arg0: email2,
                arg1: email2.IsValidEmail()
            );
        }

        private static void Bob_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
        }

    }
}
