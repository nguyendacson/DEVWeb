using project1.Models;
using project1.ViewModels;

namespace project1.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployeeList();
        EmployeeDetailVM GetDetailVM(int id);

        void SaveSalary(EmployeeDetailVM vm);

        //void CreateEmployee(Employee employee);
        //void UpdateEmployee(Employee employee);
        //void DeleteEmployee(int id);
    }
}
