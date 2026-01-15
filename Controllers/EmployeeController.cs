using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project1.Models;
using project1.Services.Interfaces;
using project1.ViewModels;

namespace project1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        { 

            var listEmployee = _employeeService.GetEmployeeList();
            return View(listEmployee);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var idEmployee = _employeeService.GetDetailVM(id);
            if(idEmployee == null)
            {
                return NotFound();
            }
            return View(idEmployee);
        }

        [HttpPost]
        public IActionResult Create(EmployeeDetailVM employeeDetailVM)
        {
            if(!ModelState.IsValid)
            {
                return View(employeeDetailVM);
            }
            _employeeService.SaveSalary(employeeDetailVM);
            return RedirectToAction("Detail", new { id = employeeDetailVM.Employee!.Id});
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
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