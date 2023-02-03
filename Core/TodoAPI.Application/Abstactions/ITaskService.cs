using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Domain.Entities;

namespace TodoAPI.Application.Abstactions
{
    public interface ITodoService
    {
        List<Todo> GetTodos();
    }
}
