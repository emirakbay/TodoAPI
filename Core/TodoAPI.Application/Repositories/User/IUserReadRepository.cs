using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Domain.Entities;

namespace TodoAPI.Application.Repositories
{
    public interface IUserReadRepository : IReadRepository<User>
    {
    }
}
