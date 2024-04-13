using AutoMapper;
using DevInterview.AdminPanel.Application.Mapper;
using DevInterview.AdminPanel.Application.Queries;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DevInterview.AdminPanel.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetAllSubjectsQuery).GetTypeInfo().Assembly);

            //// Automapper
            //var automapperConfig = new MapperConfiguration(mapperConfig =>
            //{
            //    mapperConfig.AddMaps(typeof(AdminPanelProfile).Assembly);
            //});
            //IMapper mapper = automapperConfig.CreateMapper();
            //services.AddSingleton(mapper);


            return services;
        }
    }
}
