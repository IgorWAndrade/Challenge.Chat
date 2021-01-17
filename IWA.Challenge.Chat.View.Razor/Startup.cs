using IWA.Challenge.Chat.View.Razor.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IWA.Challenge.Chat.View.Razor
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public static string API = "";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            API = Configuration.GetSection("Service").Value;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddHttpClient();

            services.AddScoped<UsuarioService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
