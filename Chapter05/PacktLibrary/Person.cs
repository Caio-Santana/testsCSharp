using System;
using static System.Console;
using System.Collections.Generic;

namespace Packt.Shared
{
    public partial class Person : IComparable<Person>
    {
        public event EventHandler Shout;
        public int AngerLevel;
        public const string Species = "Homo Sapien";
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavoriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();

        public Person()
        {
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                Shout?.Invoke(this, EventArgs.Empty);
            }
        }

        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}.";
        }

        public (string, int) GetFruit()
        {
            return ("Apples", 5);
        }

        public (string Name, int Number) GetNamedFruit()
        {
            return (Name: "Oranges", Number: 6);
        }

        public string SayHello()
        {
            return $"{Name} says 'Hello!'";
        }

        public string SayHello(string name)
        {
            return $"{Name} says 'Hello {name}!'";
        }

        public string SayHelloTo(string name)
        {
            return $"{Name} says 'Hello {name}!'";
        }

        public string OptionalParameters(
            string command = "Run!",
            double number = 0.0,
            bool active = true
        )
        {
            return string.Format(
                format: "command is {0}, number is {1}, active is {2}.",
                arg0: command, arg1: number, arg2: active
            );
        }

        public void PassingParameters(int x, ref int y, out int z)
        {
            z = 99;

            x++;
            y++;
            z++;
        }

        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }

        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }

        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        public static string operator +(Person p1, Person p2)
        {
            return Person.Marry(p1, p2);
        }
        public static string Marry(Person p1, Person p2)
        {
            return $"{p1.Name} married with {p2.Name}";
        }

        public string MarryWith(Person partner)
        {
            return Person.Marry(this, partner);
        }

        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
            }
            return localFactorial(number);
            int localFactorial(int localNumber)
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                throw new PersonException("If you travel back in time to a date earlier than your own birth, then the universe will explode!");
            }
            else
            {
                WriteLine($"Wellcome to {when:yyyy}");
            }
        }
    }
}
