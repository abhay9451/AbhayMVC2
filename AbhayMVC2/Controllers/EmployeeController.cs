using AbhayMVC2.Models;
using AbhayMVC2.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AbhayMVC2.Controllers
{
    public class EmployeeController : Controller
    {
        public ApplicationDBContext DBContext { get; }
        public IHostingEnvironment Environment { get; }

        public EmployeeController(ApplicationDBContext dBContext, IHostingEnvironment environment)
        {

            DBContext = dBContext;
            Environment = environment;
        }
        public IActionResult EmployeeList()
        {
            // var emps = DBContext.Employees.ToList();
            var emps = (from e in DBContext.Employees
                        join
                        d in DBContext.Departments
                        on e.Dept_Id equals d.Id
                        select new EmployeeVm()
                        {
                           Id =e.Id,
                           Name=e.Name,
                           Email= e.Email,
                           Mobile = e.Mobile,
                           Gender = e.Gender,
                           Salary = e.Salary,
                           DName = d.Name,
                           Image=e.Image
                        }).ToList();
            return View(emps);
        }
        public IActionResult CreateEmployee()
        {
            ViewBag.dept = DBContext.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            Employee em = new Employee();
            em.Name = Request.Form["Name"];
            em.Email = Request.Form["Email"];
            em.Mobile = Request.Form["Mobile"];
            em.Gender = Request.Form["Gender"];
            em.Image = Request.Form["Image"];
            var dept = Request.Form["Dept_Id"];
            var Salary = Request.Form["Salary"];
            if (!string.IsNullOrEmpty(Salary))
            {
                em.Salary = Convert.ToDecimal(Salary);
            }
            if (!string.IsNullOrEmpty(dept))
            {
                em.Dept_Id = Convert.ToInt32(dept);
            }

            var file = Request.Form.Files["Image"];
            string err = string.Empty;
           em.Image=UploadFile(file, out err);
            if(!string.IsNullOrEmpty(err))
            {
                ViewBag.fileError = err;
                ViewBag.dept = DBContext.Departments.ToList();
                return View(employee);
            }

            DBContext.Employees.Add(em);
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
        /*public IActionResult Index()
        {
            var employee = DBContext.Employees.ToList();
            return View(employee);
        }*/

        public string UploadFile (IFormFile formFile, out string ErrorMessage)
        {
            ErrorMessage = null;
            string filepath = string.Empty;
            if (formFile != null)
            {
                string ext = Path.GetExtension(formFile.FileName);
                if (ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png" || ext.ToLower() == ".gif")
                {
                    long fsize = formFile.Length;
                    if (fsize / 1024 <= 100)
                    {
                        string p = Environment.WebRootPath;
                        String NewFileName = Guid.NewGuid().ToString() + ext;
                        string path = Path.Combine(p, "Images", NewFileName);
                        FileStream fs = new FileStream(path, FileMode.CreateNew);

                        formFile.CopyTo(fs);
                        filepath= Path.Combine("Images", NewFileName);
                        return filepath;
                    }
                    else
                    {
                        ErrorMessage = "Please select file size max 100kb !";
                    }
                }
                else
                {
                    ErrorMessage = "Please select jpeg/jpg/png/gif file only";
                }
            }
            else
            {
                ErrorMessage = "Please upload file !";
            }
            return filepath;
        }
    }

   
}
