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
        public IActionResult DeleteEmployee(int id)
        {
            var emp = DBContext.Employees.SingleOrDefault(e => e.Id == id);
            DBContext.Employees.Remove(emp);
            DBContext.SaveChanges();
            return RedirectToAction("EmployeeList");
        }
        public IActionResult EditEmployee(int id)
        {
            var emp = DBContext.Employees.SingleOrDefault(e => e.Id == id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee emp)
        {
            DBContext.Employees.Update(emp);
            DBContext.SaveChanges();
            return RedirectToAction("EmployeeList");
        }
    }
}
