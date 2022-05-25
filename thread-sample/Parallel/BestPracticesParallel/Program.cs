using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPracticesParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            object syncRoot = new object(); 

            Parallel.For(0, 100, (i) =>
            {
                lock (syncRoot)
                {
                    Console.WriteLine($"{i}");
                }
            });

            Console.ReadKey();
        }

        private static long Soma(int i, long x)
        {
            return i + x;
        }
    }
}
