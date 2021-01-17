using AutoMapper;
using IWA.Challenge.Chat.Application.Mappings;
using IWA.Challenge.Chat.Infra.CrossCutting;
using IWA.Challenge.Chat.Service.Extension;
using IWA.Challenge.Chat.Service.Handler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IWA.Challenge.Chat.Service
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();

            //services.AddSwaggerService();

            services.AddDataBaseService();

            services.AddWebSocketService();

            BootstrapInjector.Registrer(services);

            services.AddAutoMapper(x => x.AddProfile(new BaseMapping()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.AddSwaggerApp();

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;

            app.UseWebSockets();

            app.AddWebSocketApp("/public", serviceProvider.GetService<ChatMessageHandler>());

            app.AddDataBaseApp();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
