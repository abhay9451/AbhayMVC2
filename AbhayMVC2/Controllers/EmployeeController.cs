using AbhayMVC2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbhayMVC2.Controllers
{
    public class EmployeeController : Controller
    {
        public ApplicationDBContext DBContext { get; }

        public EmployeeController(ApplicationDBContext dBContext)
        {
            DBContext = dBContext;
        }
        public IActionResult EmployeeList()
        {
            var emps = DBContext.Employees.ToList();
            return View(emps);
        }
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            DBContext.Employees.Add(employee);
            DBContext.SaveChanges();
            return RedirectToAction("EmployeeList");
        }
    }
}
