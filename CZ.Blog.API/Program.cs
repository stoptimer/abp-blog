using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CZ.Blog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

           // CreateLoggerUsingJSONFile();
            CreateHostBuilder(args).Build().Run();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 })
                 .UseAutofac();



        //private static void CreateLoggerUsingJSONFile()
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json").Build();
        //}

    }
}
