using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskContinuation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Thread com id: {Thread.CurrentThread.ManagedThreadId}");

            var getData = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Thread com id: {Thread.CurrentThread.ManagedThreadId}");

                Random rnd = new Random();

                int[] values = new int[100];

                for (int i = 0; i < values.Length; i++)
                    values[i] = rnd.Next();

                return values;
            });

            

            var processData = getData.ContinueWith((x) =>
            {
                Console.WriteLine($"Thread com id: {Thread.CurrentThread.ManagedThreadId}");

                int n = x.Result.Length;

                long sum = 0;

                for (int i = 0; i < x.Result.Length; i++)
                    sum += x.Result[i];

                return Tuple.Create(n, sum);
            });

            var displayData = processData.ContinueWith((x) =>
            {
                Console.WriteLine($"Thread com id: {Thread.CurrentThread.ManagedThreadId}");

                return String.Format("N={0:N0}, Total = {1:N0}", x.Result.Item1, x.Result.Item2);
            });

            Console.WriteLine(displayData.Result);

            Console.Read();
        }
    }
}
