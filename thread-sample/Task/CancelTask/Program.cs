using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancelTask
{
    class Program
    {
        static void Main(string[] args)
        {
            TryTask();
            Console.Read();
        }

        private static void TryTask()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            source.CancelAfter(TimeSpan.FromSeconds(5));

            Task<int> task = Task.Run(() => slowFunc(1, 2, source.Token));

            try
            {
                // (A canceled task will raise an exception when awaited).
                task.Wait();
                Console.Write($"Resultado é {task.Result}");
                Console.Read();

            }
            catch (AggregateException ex)
            {
                foreach (var v in ex.InnerExceptions)
                {
                    Console.WriteLine("Exception: {0}", v.Message);
                }
            }
          

        }

        private static int slowFunc(int a, int b, CancellationToken cancellationToken)
        {
            string someString = string.Empty;
            for (int i = 0; i < 100; i++)
            {
                someString += "a";
                Task.Delay(500).Wait();

                cancellationToken.ThrowIfCancellationRequested();
            }

            return a + b;
        }
    }
}
