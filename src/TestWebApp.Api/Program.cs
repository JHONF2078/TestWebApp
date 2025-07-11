using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.DataAccess.Context;

namespace TestWebApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host =  CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    context.Database.Migrate(); // migraciones
                    UserSeeder.SeedInitialUsers(context); //semilla
                }
                catch (Exception ex)
                {
                    // Puedes loguearlo o manejarlo como quieras
                    Console.WriteLine($"Error al aplicar migraciones: {ex.Message}");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
