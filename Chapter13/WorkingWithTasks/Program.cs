using static System.Console;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WorkingWithTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunningMethodsSynchronously();
            //RunningMethodsAsynchronously();
            //ProcessCallingWebServiceAndStoredProcedure();
        }

        static void RunningMethodsSynchronously()
        {
            var timer = Stopwatch.StartNew();
            WriteLine("Running methods synchronously on one thread.");
            MethodA();
            MethodB();
            MethodC();
            WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
        }

        static void RunningMethodsAsynchronously()
        {
            var timer = Stopwatch.StartNew();
            WriteLine("Running methods asynchronously on multiple threads.");
            Task taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Run(new Action(MethodC));
            Task[] tasks = { taskA, taskB, taskC };
            Task.WaitAll(tasks);
            WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
        }

        static void MethodA()
        {
            WriteLine("Starting Method A...");
            Thread.Sleep(3000); // 3 seconds
            WriteLine("Finished Method A.");
        }

        static void MethodB()
        {
            WriteLine("Starting Method B...");
            Thread.Sleep(2000); // 2 seconds
            WriteLine("Finished Method B.");
        }

        static void MethodC()
        {
            WriteLine("Starting Method C...");
            Thread.Sleep(1000); // 1 second
            WriteLine("Finished Method C.");
        }
    
        static void ProcessCallingWebServiceAndStoredProcedure()
        {
            var timer = Stopwatch.StartNew();
            WriteLine("Passing the result of one task as an input into another.");
            var taskCallWebServiceAndThenStoredProcedure = Task.Factory.StartNew(CallWebService)
                .ContinueWith(previousTask => CallStoredProcedure(previousTask.Result));
            WriteLine($"Result: {taskCallWebServiceAndThenStoredProcedure.Result}");
            WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
        }
        static decimal CallWebService()
        {
            WriteLine("Starting call to web service...");
            Thread.Sleep((new Random()).Next(2000,4000));
            WriteLine("Finished call to web service.");
            return 89.99M;
        }

        static string CallStoredProcedure(decimal amount)
        {
            WriteLine("Starting call to stored procedure...");
            Thread.Sleep((new Random()).Next(2000,4000));
            WriteLine("Finished call to stored procedure...");
            return $"12 products cost more than {amount:C}.";
        }
    }
}
