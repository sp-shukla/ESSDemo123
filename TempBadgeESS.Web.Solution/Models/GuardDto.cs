namespace TempBadgeESS.Web.Solution.Models
{
    public class GuardDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public int TemporaryBadge { get; set; }
        public DateTime SignIn { get; set; }
        public DateTime SignOut { get; set; }

        public TimeSpan ActiveTime { get; set; }
        public string Status { get; set; }
    }
}
