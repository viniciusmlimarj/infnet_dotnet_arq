using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tasks.Domain.Task.Repository;
using Tasks.Domain.User.Repository;
using Tasks.Domain.Board.Repository;
using Tasks.Repository.Context;
using Tasks.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Repository
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<TasksContext>(c =>
            {
                c.UseSqlServer(connectionString);
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            

            return services;

        }
    }
}
