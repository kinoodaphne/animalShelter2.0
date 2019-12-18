using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Shelter.MVC.Context;
using Shelter.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Shelter.MVC.options;

namespace Shelter.MVC
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
            var optionbuilder = services.AddDbContext<ShelterContext>(options => options.UseSqlite(Configuration.GetConnectionString("ShelterContext")));
            services.AddMvc();
            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo{Title = "Shelter API", Version = "v1"});
            });
            // In onze appsettings.json gaat onze connection string komen.
            // In de "ConnectionStrings" gaat we onze connection strings schrijven.
            // Nu staat er een default string in.
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
            //Initialiseerd onze databank en populate deze ook ineens met meegegeven data van de DBinitializer
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDatabaseInitializer databaseInitializer)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(option => {
                option.SwaggerEndpoint("swagger/v1/swagger.json", "shelter api");
                option.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                /*
                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "{controller=Api}/{action=Shelter}/{id?}");
                */
            });
        }
    }
}
