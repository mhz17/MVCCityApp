using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CityAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration(SetupConfigration)
                .UseStartup<Startup>()
                .Build();

        //private static void SetupConfigration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        //{
        //    var env = ctx.HostingEnvironment;

        //    builder.Sources.Clear();

        //    builder.AddJsonFile("appsettings.json", false, true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
        //        .AddEnvironmentVariables();
        //}
    }
}
