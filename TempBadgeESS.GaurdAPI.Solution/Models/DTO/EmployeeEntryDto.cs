using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TempBadgeESS.GuardAPI.Solution.Models.DTO
{
    public class EmployeeEntryDto
    {
     
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int TemporaryBadge { get; set; }

        public DateTime SignIn { get; set; }

        public DateTime SignOut { get; set; }

       
        public int employeeId { get; set; }
       
    }
}
