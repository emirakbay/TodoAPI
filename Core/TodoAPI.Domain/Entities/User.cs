using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Domain.Entities.Common;

namespace TodoAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public enum USER_TYPE
        {
            ADMIN,
            NORMAL
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }

        public List<string> Todos { get; set; }
    }
}
