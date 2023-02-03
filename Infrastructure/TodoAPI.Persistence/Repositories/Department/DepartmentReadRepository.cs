﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Application.Repositories;
using TodoAPI.Domain.Entities;
using TodoAPI.Persistence.Contexts;

namespace TodoAPI.Persistence.Repositories
{
    public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(TodoAPIDbContext todoAPIDbContext) : base(todoAPIDbContext)
        {
        }
    }
}
