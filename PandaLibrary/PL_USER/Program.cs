using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PL_USER
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel(x => x.AddServerHeader = false)
                        .UseStartup<Startup>()
                        .UseUrls("http://localhost:6001");
                })
                .ConfigureAppConfiguration(configuration =>
                {
                    var currentEnv =
                        $"user.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json";

                    configuration
                        .SetBasePath(Directory.GetCurrentDirectory() + "/PL_USER")
                        .AddJsonFile("user.json", false, true)
                        .AddJsonFile(currentEnv, true);
                });
    }
}
