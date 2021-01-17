using AutoMapper;
using IWA.Challenge.Chat.Application.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IWA.Challenge.Chat.Service.Extension
{
    public static class AutoMapperExtension
    {
        public static IApplicationBuilder AddAutoMapperApp(this IApplicationBuilder app)
        {
            return app;
        }

        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BaseMapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
