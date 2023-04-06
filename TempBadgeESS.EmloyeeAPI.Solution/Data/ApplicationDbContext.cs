using Microsoft.EntityFrameworkCore;
using TempBadgeESS.EmployeeAPI.Solution.Models;

namespace TempBadgeESS.EmloyeeAPI.Solution.Data
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }

            public DbSet<Employee> Employees { set; get; }
        }
    
}
