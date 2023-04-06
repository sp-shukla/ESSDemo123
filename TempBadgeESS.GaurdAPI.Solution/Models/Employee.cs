using System.ComponentModel.DataAnnotations;

namespace TempBadgeESS.GuardAPI.Solution.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
