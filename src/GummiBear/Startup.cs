using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using GummiBear.Models;
using System;

namespace GummiBear
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //for testing later, can set up a separate in-memory context(NOT TravelBlogContext)
            //services.AddDbContext<TravelBlogContext>(opt => opt.UseInMemoryDatabase());
            services.AddMvc();

            services.AddEntityFramework()
                .AddDbContext<GummiBearDbContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
        }


        public void Configure(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<GummiBearDbContext>();
            AddTestData(context);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{id?}");
            });

            app.UseStaticFiles();

            app.Run(async (context1) =>
            {
                await context1.Response.WriteAsync("Hello World!");
            });
        }

        private static void AddTestData(GummiBearDbContext context)
        {
            var dummyBear = new Models.Bear
            {
                Name = "Black Forest Organic Gummi Bears",
                Cost = 12,
                Country = "Germany"

            };

            context.Bears.Add(dummyBear);

            var dummyBear2 = new Models.Bear
            {
                Name = "Vitacost Gummi Bears",
                Cost = 10,
                Country = "USA"
            };

            context.Bears.Add(dummyBear2);

            context.SaveChanges();
        }
    }
}