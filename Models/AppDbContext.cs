using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace project1.Models
{
    public class AppDbContext : DbContext  
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Salary> Salary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Salary)
                        .WithOne(s => s.Employee)
                        .HasForeignKey<Salary>(s => s.EmployeeId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
