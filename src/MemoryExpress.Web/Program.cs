using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MemoryExpress.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MemoryExpress.Web
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    await ApplicationDbContextSeed.SeedAsync(context);
                }
                catch (Exception ex)
                {

                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var port = Environment.GetEnvironmentVariable("PORT");

            if (environment == EnvironmentName.Development)
            {
                var ports = port.Split(",");

                return WebHost.CreateDefaultBuilder(args)
                    .UseUrls(new string[] { "http://*:" + ports[0], "https://*:" + ports[1] })
                    .UseStartup<Startup>(); 
            }

            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:" + port)
                .UseStartup<Startup>();
        }
    }
}
