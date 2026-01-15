using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project1.Models;
using project1.ViewModels;

namespace project1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        { 
            var listEmployee = _appDbContext.Employee.ToList();
            ViewBag.Message = "Connect success";
            return View(listEmployee);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var emp = _appDbContext.Employee.FirstOrDefault(item => item.Id == id);
            var salary = _appDbContext.Salary.FirstOrDefault(item => item.EmployeeId == id);

            if (emp == null)
                return NotFound();

            var vm = new EmployeeDetailVM
            {
                Employee = emp,
                Salary = salary,
                SalaryInputVM = new SalaryInputVM()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(EmployeeDetailVM employeeDetailVM)
        {
            if (employeeDetailVM == null)
            {
                return BadRequest("Model binding thất bại");
            }

            int idEmp = employeeDetailVM.Employee!.Id;

            decimal baseSalary = employeeDetailVM.SalaryInputVM?.BaseSalary ?? 0;
            decimal bonusSalary = employeeDetailVM.SalaryInputVM?.Bonus ?? 0;
            decimal totalSalary = baseSalary + bonusSalary;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Detail", new { id = idEmp});
            }

            var checkExist = _appDbContext.Salary.FirstOrDefault(
                e => e.EmployeeId == idEmp);

            if (checkExist != null)
            {
                checkExist.BaseSalary = baseSalary;
                checkExist.Bonus = bonusSalary;
                checkExist.TotalSalary = totalSalary;
            }
            else
            {
                var salary = new Salary
                {
                    EmployeeId = idEmp,
                    BaseSalary = baseSalary,
                    Bonus = bonusSalary,
                    TotalSalary = totalSalary
                };

                _appDbContext.Salary.Add(salary);

            }
            _appDbContext.SaveChanges();

            return RedirectToAction("Detail", new { id = idEmp});
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