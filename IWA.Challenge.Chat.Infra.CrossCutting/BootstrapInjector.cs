using Microsoft.Extensions.DependencyInjection;
using IWA.Challenge.Chat.Application.Interfaces;
using IWA.Challenge.Chat.Application.Services;
using IWA.Challenge.Chat.Domain.Interfaces.Repositories;
using IWA.Challenge.Chat.Infra.Data.Repositories;
using IWA.Challenge.Chat.Domain.Interfaces.Services;
using IWA.Challenge.Chat.Domain.Services;

namespace IWA.Challenge.Chat.Infra.CrossCutting
{
    public static class BootstrapInjector
    {
        public static void Registrer(IServiceCollection services)
        {
            //Application
            services.AddScoped(typeof(IBaseApp<>), typeof(BaseServiceApp<>));

            //Domínio
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            //Repositorio
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
