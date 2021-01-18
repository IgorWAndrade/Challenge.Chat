using IWA.Challenge.Chat.Infra.Data.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IWA.Challenge.Chat.Service.Extension
{
    public static class DataBaseExtension
    {
        public static IApplicationBuilder AddDataBaseApp(this IApplicationBuilder app)
        {
            return app;
        }

        public static IServiceCollection AddDataBaseService(this IServiceCollection services)
        {
            services.AddDbContext<BaseContexto>(options => options.UseInMemoryDatabase("BaseDatabase"));

            return services;
        }
    }
}
