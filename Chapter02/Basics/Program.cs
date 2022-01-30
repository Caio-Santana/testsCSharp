using System;
using System.Linq;
using System.Reflection;


namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.DataSet ds;
            System.Net.Http.HttpClient client;
            //Console.WriteLine("Temperature on {0:D} is {1}°C.", DateTime.Today, 23.4);

            foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
            {
                var a = Assembly.Load(new AssemblyName(r.FullName));

                int methodCount = 0;
                foreach (var t in a.DefinedTypes)
                {
                    methodCount += t.GetMethods().Count();
                }
                Console.WriteLine("{0:N0} types with {1:N0} methods in {2} assembly.",
                arg0: a.DefinedTypes.Count(),
                arg1: methodCount,
                arg2: r.Name);
            }

        }
    }
}
