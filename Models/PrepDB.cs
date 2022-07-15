using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ColourAPI.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColorContext>());

            }
        }
        public static void SeedData(ColorContext context)
        {
            System.Console.WriteLine("Appling Migrations.....");
            context.Database.Migrate();
            if(!context.ColorItems.Any())
            {
                System.Console.WriteLine("Adding data... Seeding...");
                context.ColorItems.AddRange(
                    new Color() {ColorName="Red"},
                    new Color() {ColorName="Blue"},
                    new Color() {ColorName="Yellow"},
                    new Color() {ColorName="Green"},
                    new Color() {ColorName="Orange"}
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Data already exist... Nothing to do!");
            }
        }
    }
}