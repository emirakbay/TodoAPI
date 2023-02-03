using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Persistence.Contexts;

namespace TodoAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoAPIDbContext>
    {
        public TodoAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TodoAPIDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<TodoAPIDbContext>();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
