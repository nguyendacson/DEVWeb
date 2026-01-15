using project1.Models;
using project1.Services.Interfaces;
using project1.ViewModels;
using System.Linq;

namespace project1.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {

        private readonly AppDbContext _appDbContext;

        public EmployeeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public EmployeeDetailVM GetDetailVM(int id)
        {
            var emp = _appDbContext.Employee.FirstOrDefault(e => e.Id == id);
                if(emp == null)
                {
                    return new EmployeeDetailVM();
                }
                var salary = _appDbContext.Salary.FirstOrDefault(s => s.EmployeeId == id);
                var vm = new EmployeeDetailVM
                {
                    Employee = emp,
                    Salary = salary
                };
            return vm;
        }

        public List<Employee> GetEmployeeList()
        {
            return _appDbContext.Employee.ToList();
        }

        public void SaveSalary(EmployeeDetailVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
