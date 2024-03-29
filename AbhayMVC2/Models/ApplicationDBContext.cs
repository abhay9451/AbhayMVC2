﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace AbhayMVC2.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options): base(options )
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
