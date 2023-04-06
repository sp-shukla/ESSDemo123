using Microsoft.EntityFrameworkCore;
using TempBadgeESS.GuardAPI.Solution.Models;

namespace TempBadgeESS.GuardAPI.Solution.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

       public DbSet<Employee> Employees { set; get; }
        public DbSet<EmployeeEntry> EmployeeEntries { set; get; }
    }
}
