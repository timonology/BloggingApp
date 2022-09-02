using BloggingApp.Domain.Auth;
using BloggingApp.Persistence;
using BloggingApp.Persistence.Context;
using BloggingApp.Persistence.Interfaces;
using BloggingApp.Service.Implementation;
using BloggingApp.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BloggingApp.Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        public static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("IdentityConnection"),
                    b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@";
                options.User.RequireUniqueEmail = true;
            });

            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
