using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
            var listEmployee = _appDbContext.Employee.Select(e=> e.Name).ToList();
            
            Debug.WriteLine("employeeCount111" + employeeCount);
            Debug.WriteLine("listEmployee" + listEmployee);
            ViewBag.Message = "Connect success";
            ViewBag.EmployeeCount = employeeCount;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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
