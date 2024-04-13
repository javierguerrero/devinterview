using AutoMapper;
using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.Mapper;
using DevInterview.AdminPanel.Application.Queries;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
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

            // Api Gateway
            services.AddRefitClient<IWebApiGatewayCommunication>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration.GetSection("Communication:External:WebApiGateway").Value));

            return services;
        }
    }
}
