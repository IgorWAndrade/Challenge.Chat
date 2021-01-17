using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace IWA.Challenge.Chat.Service.Extension
{
    public static class SwaggerExtension
    {
        public static IApplicationBuilder AddSwaggerApp(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }

        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name = "Igor Andrade",
                        Email = string.Empty
                    }
                });
            });

            return services;
        }
    }
}
