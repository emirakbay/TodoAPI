using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Domain.Entities.Common;

namespace TodoAPI.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name;
        //public DEPARTMENT DEPARTMENT { get; set; }

        public List<string> Users { get; set; }
    }
}

public enum DEPARTMENT
{
    BACKEND,
    FRONTEND,
    TEST,
    DESIGN,
    HR
}