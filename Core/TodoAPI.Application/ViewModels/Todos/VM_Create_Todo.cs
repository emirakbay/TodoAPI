using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Domain.Entities;

namespace TodoAPI.Application.ViewModels.Todos
{
    public class VM_Create_Todo
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Users { get; set; }

        public List<string> Departments { get; set; }

        public DateTime EndTime { get; set; }
    }
}
