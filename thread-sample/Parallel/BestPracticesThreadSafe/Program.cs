using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BestPracticesThreadSafe
{
    class Program
    {
        static FileStream fs = File.OpenWrite("Thread.txt");

        static void Main(string[] args)
        {
            
            byte[] bytes = new Byte[10000000];

            var result = Parallel.For(0, bytes.Length, (i) =>
            {
                lock (fs)
                {
                    fs.WriteByte(bytes[i]);
                }                
            });

            fs.Flush();

            Console.Write($"acabou de escrever {result.IsCompleted}");
            Console.Read();
        }
    }
}
