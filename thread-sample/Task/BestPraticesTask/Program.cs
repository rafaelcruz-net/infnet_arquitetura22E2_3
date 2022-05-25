using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPraticesTask
{
    class Program
    {
        static void Main(String[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            CallAsync();
            Console.WriteLine("Asynchronous Call:- " + sw.Elapsed.ToString());
            sw.Reset();

            sw.Start();
            CallNonAsync();
            Console.WriteLine("Synchronous Call:- " + sw.Elapsed.ToString());
            sw.Stop();

            Console.ReadLine();
        }

        public static async Task<String> Asyncfun()
        {
            //This is dummy return   
            return "Hello World";
        }
        public static async void CallAsync()
        {
            await Asyncfun();
        }

        public static string NonAsync()
        {
            //This is dummy return 
            return "Hello World";
        }

        public static void CallNonAsync()
        {
            NonAsync();
        }
        
    }
}
