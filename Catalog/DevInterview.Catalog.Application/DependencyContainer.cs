using AutoMapper;
using DevInterview.Catalog.Application.Mapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DevInterview.Catalog.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Automapper
            var automapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddMaps(typeof(MapProfile).Assembly);
            });
            IMapper mapper = automapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}