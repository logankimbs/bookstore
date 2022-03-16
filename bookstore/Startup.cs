using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace bookstore
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
            services.AddControllersWithViews();

            services.AddDbContext<BookContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("BookstoreConnection"));
            });

            services.AddDbContext<AppIdentityDBContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("IdentityConnection"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDBContext>();

            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

            services.AddScoped<IDonationRepository, EFDonationRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddScoped(x => SessionBasket.GetBasket(x));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddServerSideBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "categorypage",
                    pattern: "{bookCategory}/Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 }
                );

                endpoints.MapControllerRoute(
                    name: "category",
                    pattern: "{bookCategory}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 }
                );

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();

                endpoints.MapBlazorHub();

                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
