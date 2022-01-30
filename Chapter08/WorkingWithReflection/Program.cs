using System;
using System.Reflection;
using static System.Console;
using Packt.Shared;
using System.Runtime.CompilerServices;
using System.Linq;

namespace WorkingWithReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Assembly metadata:");
            Assembly assembly = Assembly.GetEntryAssembly();
            WriteLine($"Full name: {assembly.FullName}");
            WriteLine($"Location: {assembly.Location}");

            var attributes = assembly.GetCustomAttributes();
            WriteLine("Attributes:");
            foreach (var attribute in attributes)
            {
                WriteLine(attribute.GetType());
            }

            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            WriteLine($"version: {version.InformationalVersion}");

            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            WriteLine($"Company: {company.Company}");

            WriteLine();
            WriteLine($" Types:");
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                WriteLine();
                WriteLine($"Type: {type.FullName}");
                
                MemberInfo[] members = type.GetMembers();
                foreach (var member in members)
                {
                    WriteLine("{0}: {1} ({2})",
                        arg0: member.MemberType,
                        arg1: member.Name,
                        arg2: member.DeclaringType.Name
                    );

                    var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);
                    foreach (var coder in coders)
                    {
                        WriteLine("-> Modified by {0} on {1}",
                        arg0: coder.Coder,
                        arg1: coder.LastModified.ToShortDateString());
                    }
                }
            }
        }

        [Coder("Mark Price","22 August 2019")]
        [Coder("Jhonni Rasmussen","13 September 2019")]
        public static void DoStuff()
        {

        }
    }
}
