using TempBadgeESS.Web.Solution.Models;

namespace TempBadgeESS.Web.Solution.Services.Interface
{
    public interface IEmployeeService
    {
        Task<T> GetEmployeeByName<T>(EmployeeDto modelDto);
    }
}
