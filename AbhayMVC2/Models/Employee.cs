﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbhayMVC2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public Decimal Salary { get; set; }

    }
}
