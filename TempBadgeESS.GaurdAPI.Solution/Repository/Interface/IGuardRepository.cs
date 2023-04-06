
using TempBadgeESS.GuardAPI.Solution.Models;
using TempBadgeESS.GuardAPI.Solution.Models.DTO;

namespace TempBadgeESS.GaurdAPI.Solution.Repository.Interface
{
    public interface IGuardRepository
    {
        /*Task<IEnumerable<EmployeeDto>> GetEmployees(EmployeeDto modelDto);*/

        Task<EmployeeEntryDto> CreateTempBadgeId(int id);
        //Task<EmployeeEntry> CreateTempBadgeId(int id);
        Task<EmployeeDto>GetEmployeeById(int id);

        Task<EmployeeEntryDto> SignOutEmployee(EmployeeEntryDto modelDto);

        Task<IEnumerable<GuardDto>> GetAllTempBadgeList();

        Task<IEnumerable<GuardDto>>GetAllTempBadgeQueue();

        Task<IEnumerable<EmployeeEntryDto>> FilterEmployeelist(EmployeeEntryDto modelDto);

        Task<IEnumerable<GuardDto>> GetBadgeOutPage();
    }
}
