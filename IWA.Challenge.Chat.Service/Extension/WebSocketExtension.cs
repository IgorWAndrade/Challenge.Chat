using IWA.Challenge.Chat.Service.Handler;
using IWA.Challenge.Chat.Service.Manager;
using IWA.Challenge.Chat.Service.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IWA.Challenge.Chat.Service.Extension
{
    public static class WebSocketExtension
    {
        public static IApplicationBuilder AddWebSocketApp(this IApplicationBuilder app,
                                                           PathString path,
                                                           WebSocketHandler handler)
        {
            return app.Map(path, (_app) => _app.UseMiddleware<WebSocketManagerMiddleware>(handler));
        }

        public static IServiceCollection AddWebSocketService(this IServiceCollection services)
        {
            services.AddTransient<ConnectionManager>();

            foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(WebSocketHandler))
                {
                    services.AddSingleton(type);
                }
            }

            return services;
        }
    }
}
