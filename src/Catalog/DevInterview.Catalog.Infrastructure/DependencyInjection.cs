using DevInterview.Catalog.Domain.Interfaces;
using DevInterview.Catalog.Infrastructure.DataAccess;
using DevInterview.Catalog.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevInterview.Catalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyección de dependencias de servicios personalizados
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            // Entity Framework
            var connectionString = $"Server={configuration.GetConnectionString("CatalogDB:HostName")};" +
                                            $"Database={configuration.GetConnectionString("CatalogDB:Catalogue")};" +
                                            $"User ID={configuration.GetConnectionString("CatalogDB:User")};" +
                                            $"Password={configuration.GetConnectionString("CatalogDB:Password")};" +
                                            $"Encrypt=False;MultipleActiveResultSets=True;";
            services.AddDbContext<CatalogContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}