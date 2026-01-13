using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project1.Models;

namespace project1.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _appDbContext;
        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var employeeCount = _appDbContext.Employee.Count();
            var listEmployee = _appDbContext.Employee.ToList();
            //foreach (var nameEmployee in listEmployee)
            //{
            //    Debug.WriteLine("Name Employee: " + nameEmployee.Name);
            //}

            var nameEmployee = _appDbContext.Employee.Select(name => name.Name).ToList();
           

            Debug.WriteLine("employeeCount111" + employeeCount);
            Debug.WriteLine("listEmployee" + listEmployee.ToString());
            ViewBag.Message = "Connect success";
            ViewBag.EmployeeCount = employeeCount;

            return View(listEmployee);
        }

        public IActionResult Privacy(int id)
        {
            //var emp = _appDbContext.Employee.FirstOrDefault(e => e.Id == id);
            //if (emp == null)
            //    return NotFound();

            //ViewData["Title"] = "Employee Detail";
            //return View(emp);
            return View();
        }

        public IActionResult Detail(int id)
        {
            var emp = _appDbContext.Employee.FirstOrDefault(item =>
            item.Id == id);
            if (emp == null)
                return NotFound();

            return View(emp);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }
    }
}
