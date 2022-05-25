using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // int workerThreads, ioThreads;
            // ThreadPool.GetMaxThreads(out workerThreads, out ioThreads);
            // ThreadPool.SetMaxThreads(Environment.ProcessorCount, ioThreads);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseKestrel(opt =>
                    {
                        opt.Limits.MaxConcurrentConnections = 20;
                    });
                })
                
                ;
    }
}
