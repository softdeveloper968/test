using Microsoft.EntityFrameworkCore;

namespace Employee_Amit_Chawla.Models
{
    public class EmployeeDbContext : DbContext
    {

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }

}
