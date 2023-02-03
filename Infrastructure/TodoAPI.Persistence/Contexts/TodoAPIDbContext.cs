using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Domain.Entities;
using TodoAPI.Domain.Entities.Common;

namespace TodoAPI.Persistence.Contexts
{
    public class TodoAPIDbContext : DbContext
    {
        public TodoAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Department> Departments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.Created = DateTime.UtcNow,
                    EntityState.Modified => item.Entity.Updated = DateTime.UtcNow,
                    _ => DateTime.UtcNow,
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
