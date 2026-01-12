namespace project1.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal TotalSalary { get; set; }

        public Employee? Employee { get; set; }
    }
}
