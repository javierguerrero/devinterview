using DevInterview.Students.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevInterview.Students.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyección de dependencias de servicios personalizados


            // Entity Framework
            var connectionString = $"Server={configuration.GetConnectionString("StudentsDB:HostName")};" +
                                            $"Database={configuration.GetConnectionString("StudentsDB:Catalogue")};" +
                                            $"User ID={configuration.GetConnectionString("StudentsDB:User")};" +
                                            $"Password={configuration.GetConnectionString("StudentsDB:Password")};" +
                                            $"Encrypt=False;MultipleActiveResultSets=True;";
            
            services.AddDbContext<StudentsContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
