
using Microsoft.AspNetCore.Identity;

namespace ESS.IDentity.Solution.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
