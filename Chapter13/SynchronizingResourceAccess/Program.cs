using System;
using static System.Console;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SynchronizingResourceAccess
{
    class Program
    {
        static Random r = new Random();
        static string Message;
        static object conch = new object();

        static int Counter;

        static void Main(string[] args)
        {
            ExecuterOne();
        }

        static void ExecuterOne()
        {
            WriteLine("Please wait for the task to complete.");
            Stopwatch watch = Stopwatch.StartNew();
            Task a = Task.Factory.StartNew(MethodA);
            Task b = Task.Factory.StartNew(MethodB);
            Task.WaitAll(new Task[] { a, b });
            WriteLine();
            WriteLine($"Results: {Message}.");
            WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");
            WriteLine($"{Counter} string modifications.");
        }

        static void MethodA()
        {
            try
            {
                if (Monitor.TryEnter(conch, TimeSpan.FromSeconds(15)))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(r.Next(2000));
                        Message += "A";
                        Interlocked.Increment(ref Counter);
                        Write(".");
                    }
                }
                else
                {
                    WriteLine("Method A failed to enter a monitor lock.");
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }

        static void MethodB()
        {
            try
            {
                if (Monitor.TryEnter(conch, TimeSpan.FromSeconds(15)))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(r.Next(2000));
                        Message += "B";
                        Interlocked.Increment(ref Counter);
                        Write(".");
                    }
                }
                else
                {
                    WriteLine("Method B failed to enter a monitor lock.");
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }
    }
}
