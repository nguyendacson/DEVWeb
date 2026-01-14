using project1.Models;

namespace project1.ViewModels
{
    public class EmployeeDetailVM
    {
        public Employee? Employee { get; set; }
        public Salary? Salary { get; set; }
        public SalaryInputVM? SalaryInputVM {  get; set; }
    }

    public class SalaryInputVM
    {
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
    }
}
