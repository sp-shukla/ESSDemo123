

namespace TempBadgeESS.Web.Solution.Models
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
