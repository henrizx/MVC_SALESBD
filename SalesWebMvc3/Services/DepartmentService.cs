﻿using SalesWebMvc3.Data;
using SalesWebMvc3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc3.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvc3Context _context;

        public DepartmentService(SalesWebMvc3Context context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
