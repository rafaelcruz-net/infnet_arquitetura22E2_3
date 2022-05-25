using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task em rodando modo implicito
            Parallel.Invoke(() => DoSomeWork(), () => DoSomeWork());

            //mesma coisa que somente em modo explicito
            Task task1 = new Task(() => DoSomeWork());
            Task task2 = new Task(() => DoSomeWork());

            task1.Start();
            task2.Start();

            Task.WaitAll(task1, task2);

            Console.Read();

        }

        private static void DoSomeWork()
        {
            Console.WriteLine("Trabalho feito");
        }
    }
}
