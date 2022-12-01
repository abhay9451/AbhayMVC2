using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AbhayMVC2.Models;
namespace AbhayMVC2.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDBContext DBContext { get; }

        public HomeController(ApplicationDBContext dBContext)
        {
            DBContext = dBContext;
        }
        public IActionResult Index()
        {
            /* String Message = "Welcome to MVC Application";
             ViewBag.msg = Message;
             List<string> Students = new List<string>() { "Abhay", "Akash", "Rajesh", "Karan", "Arjun" };
             //ViewBag.Students = Students;
             ViewData["Students"] = Students;*/

           // var employee = DBContext.Employees.ToList();
             return View();
            
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult More()
        {
            return View();
        }
    }
}
