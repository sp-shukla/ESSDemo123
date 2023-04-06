using System.ComponentModel.DataAnnotations;

namespace TempBadgeESS.GuardAPI.Solution.Models.DTO
{
    public class EmployeeDto
    {
      
        public int EmployeeId { get; set; }

       
        public string FirstName { get; set; }

        public string LastName { get; set; }
       
        public string ImageUrl { get; set; }
    }
}
