using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BestPracticesDeadLocks
{
    class Program
    {
        static void Main(string[] args)
        {
            ManualResetEventSlim mre = new ManualResetEventSlim();

            Enumerable.Range(0, Environment.ProcessorCount * 100).AsParallel().ForAll(x =>
            {
                if (x == Environment.ProcessorCount)
                {
                    Console.WriteLine($"Volta da thread {Thread.CurrentThread.ManagedThreadId} with value of {x}");
                    mre.Set();
                }
                else
                {
                    Console.WriteLine($"Esperando pela thread {Thread.CurrentThread.ManagedThreadId} with value of {x}");
                    mre.Wait();
                }

            });

            Console.Read();
        }

    }
}
