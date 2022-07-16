using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tasks.Application.Task.Services;
using Tasks.Application.Board.Services;
using Tasks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace Tasks.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services, string connectionString)
        {
            services.RegisterRepository(connectionString);

            services.AddAutoMapper(typeof(Application.ConfigurationModule).Assembly);

            services.AddMediatR(typeof(Application.ConfigurationModule).Assembly);

            services.AddScoped<IBoardServices, BoardServices>();
            services.AddScoped<ITaskServices, TaskServices>();

            return services;

        }
    }
}
