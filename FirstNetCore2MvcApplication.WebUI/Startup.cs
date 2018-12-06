using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstNetCore2MvcApplication.WebUI.DataAccess;
using FirstNetCore2MvcApplication.WebUI.DataAccess.EfRepository;
using FirstNetCore2MvcApplication.WebUI.DataAccess.FakeRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstNetCore2MvcApplication.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("AppDbConnectionString")));

            //FakeRepository için
            //services.AddScoped<IProductRepository, FakeProductRepository>();
            //services.AddScoped<IBrandRepository, FakeBrandRepository>();


            // EFRepository için
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IBrandRepository, EfBrandRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CreateProduct",
                    template: "urunler/urun-ekle",
                    defaults: new { controller = "Product", action = "Create" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
