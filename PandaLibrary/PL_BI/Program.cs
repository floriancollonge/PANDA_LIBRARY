using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace PL_BI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Directory.GetCurrentDirectory() + "/PL_BI";
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel(x => x.AddServerHeader = false)
                        .UseStartup<Startup>()
                        .UseUrls("http://localhost:6003");
                })
                .ConfigureAppConfiguration(configuration =>
                {
                    var currentEnv =
                        $"bi.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json";

                    configuration
                        .SetBasePath(Directory.GetCurrentDirectory() + "/PL_BI")
                        .AddJsonFile("bi.json", false, true)
                        .AddJsonFile(currentEnv, true);
                });
    }
}
