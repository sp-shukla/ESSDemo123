namespace TempBadgeESS.Web.Solution
{
    public static class StaticDetails
    {
        public static string EmployeeAPIBase { get; set; }
        public static string GuardAPIBase{ get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
