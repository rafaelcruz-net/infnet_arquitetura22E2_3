using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDeattached
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Dettached();
            Attached();
            Console.Read();

        }

        private static void Dettached()
        {
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task beginning.");

                var child = Task.Factory.StartNew(() =>
                {
                    Thread.SpinWait(5000000);
                    Console.WriteLine("Detached task completed.");
                });

            });

            outer.Wait();
            Console.WriteLine("Outer task completed.");
        }

        private static void Attached()
        {
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task começando.");

                for (int i = 0; i < 10; i++)
                {
                    var taskChild = i;
                    var child = Task.Factory.StartNew((x) =>
                    {
                        Thread.SpinWait(5000000);
                        Console.WriteLine($"Attached child {x} para o parent.");
                    }, taskChild, TaskCreationOptions.AttachedToParent);
                }

            });

            outer.Wait();
            Console.WriteLine("Outer task completada.");
            
        }
    }
}
