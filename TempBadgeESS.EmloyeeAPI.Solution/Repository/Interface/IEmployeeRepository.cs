using TempBadgeESS.EmployeeAPI.Solution.Models.DTO;

namespace TempBadgeESS.GaurdAPI.Solution.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees(EmployeeDto modelDto);


    }
}
