using AutoMapper;
using DevInterview.Students.Application.Mapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Students.Application
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
                mapperConfig.AddMaps(typeof(MapperProfile).Assembly);
            });
            IMapper mapper = automapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
