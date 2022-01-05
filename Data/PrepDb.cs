using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Entities;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                AddTestData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void AddTestData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("======> Adding test data");

                context.Platforms.AddRange(
                    new Platform { Name = "PlayStation 4", Publisher = "Sony", Cost = "100" },
                    new Platform { Name = "Xbox One", Publisher = "Microsoft", Cost = "100" },
                    new Platform { Name = "Nintendo Switch", Publisher = "Nintendo", Cost = "100" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("======> Platforms already exist");
            }
        }
    }
}