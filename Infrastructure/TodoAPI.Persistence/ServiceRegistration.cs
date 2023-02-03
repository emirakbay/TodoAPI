using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Application.Abstactions;
using TodoAPI.Persistence.Contexts;
using TodoAPI.Application.Repositories;
using TodoAPI.Persistence.Repositories;

namespace TodoAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TodoAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<ITodoReadRepository, TodoReadRepository>();
            services.AddScoped<ITodoWriteRepository, TodoWriteRepository>();
            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
        }
    }
}
