using FirstNetCore2MvcApplication.WebUI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace FirstNetCore2MvcApplication.WebUI.DataAccess
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.GetRequiredService<AppDbContext>();
            context.Database.Migrate();

            if (!context.Brands.Any())
            {
                context.Brands.AddRange(
                     new Brand() { BrandName = "BMW" },
                     new Brand() { BrandName = "Mercedes" },
                     new Brand() { BrandName = "Honda" },
                     new Brand() { BrandName = "Volvo" },
                     new Brand() { BrandName = "Citroen" }
            );
                context.SaveChanges();
            }
        }
    }
}
