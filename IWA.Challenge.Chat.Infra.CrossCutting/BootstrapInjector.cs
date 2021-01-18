using IWA.Challenge.Chat.Application.Interfaces;
using IWA.Challenge.Chat.Application.Services;
using IWA.Challenge.Chat.Domain.Interfaces.Repositories;
using IWA.Challenge.Chat.Domain.Interfaces.Services;
using IWA.Challenge.Chat.Domain.Services;
using IWA.Challenge.Chat.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IWA.Challenge.Chat.Infra.CrossCutting
{
    public static class BootstrapInjector
    {
        public static void Registrer(IServiceCollection services)
        {
            //Application
            services.AddScoped(typeof(IBaseApp<>), typeof(BaseServiceApp<>));
            services.AddScoped(typeof(IUsuarioApp), typeof(UsuarioApp));

            //Domínio
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));

            //Repositorio
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
        }
    }
}
