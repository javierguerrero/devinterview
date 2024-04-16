﻿using DevInterview.AdminPanel.Domain.Interfaces;
using DevInterview.AdminPanel.Infrastructure.DataAccess;
using DevInterview.AdminPanel.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevInterview.AdminPanel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Dependencies
            services.AddScoped(typeof(IFirebaseContext), typeof(FirebaseContext));
            services.AddScoped(typeof(ITopicRepository), typeof(TopicRepository));
            services.AddScoped(typeof(IQuestionRepository), typeof(QuestionRepository));

            return services;
        }
    }
}