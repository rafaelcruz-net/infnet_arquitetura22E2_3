using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BestPracticesTaskTryCatch
{
    class Program
    {
        static void Main(String[] args)
        {
            try
            {
                Console.WriteLine(Call());
                Console.WriteLine("Fim");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
           
        }

        public static async Task Asyncfun()
        {
            throw new Exception("This is my exception");
        }
        public static Task<Int32> Call()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(10000);
                return 10;
            });
        }

    }
}
