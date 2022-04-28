using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace PL_LIBRARY
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
                        .UseUrls("http://localhost:6002");
                })
                .ConfigureAppConfiguration(configuration =>
                {
                    var currentEnv =
                        $"library.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json";

                    configuration
                        .SetBasePath(Directory.GetCurrentDirectory() + "/PL_LIBRARY")
                        .AddJsonFile("library.json", false, true)
                        .AddJsonFile(currentEnv, true);
                });
    }
}
