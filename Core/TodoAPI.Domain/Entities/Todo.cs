using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Domain.Entities.Common;

namespace TodoAPI.Domain.Entities
{
    public class Todo : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Users { get; set; }

        public List<string> Departments { get; set; }

        //public ICollection<User> Users { get; set; }

        //public ICollection<Department> Departments { get; set; }

        public DateTime EndTime { get; set; }
    }
}
