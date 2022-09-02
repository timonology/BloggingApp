using AutoMapper;
using BloggingApp.Infrastructure.Mapping;
using BloggingApp.Persistence;
using BloggingApp.Persistence.Context;
using BloggingApp.Persistence.Interfaces;
using BloggingApp.Service.Implementation;
using BloggingApp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        }
        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDateTimeService, DateTimeService>();
            serviceCollection.AddTransient<IAccountService, AccountService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
