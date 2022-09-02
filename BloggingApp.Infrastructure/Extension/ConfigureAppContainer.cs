using BloggingApp.Service.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingApp.Infrastructure.Extension
{
    public static class ConfigureAppContainer
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }

        public static void ConfigureLoggerFactory(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
        }
    }
}
