using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempBadgeESS.GuardAPI.Solution.Models
{
    public class EmployeeEntry
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int TemporaryBadge { get; set; }

        public DateTime SignIn { get; set; }

        public DateTime SignOut { get; set; }

        [ForeignKey("Employee")]
        public int employeeId { get; set; }
        public Employee employee { get; set; }
    }
}
