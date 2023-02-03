using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Application.Repositories;
using TodoAPI.Domain.Entities;
using TodoAPI.Persistence.Contexts;

namespace TodoAPI.Persistence.Repositories
{
    public class TodoReadRepository : ReadRepository<Todo>, ITodoReadRepository
    {
        public TodoReadRepository(TodoAPIDbContext todoAPIDbContext) : base(todoAPIDbContext)
        {
        }
    }
}
