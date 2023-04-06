using TempBadgeESS.Web.Solution.Models;

namespace TempBadgeESS.Web.Solution.Services.Interface
{
    public interface IGuardService
    {
        Task<T> CreateTempBadgeId<T>(int id);
        Task<T> SignOutEmployee<T>(EmployeeEntryDto modelDto);

        Task<T> GetAllTempBadgeList<T>(string token);
        Task<T> GetAllTempBadgeQueue<T>(string token);
        Task<T> GetAllTempBadgeOutList<T>(string token);

        Task<T>FilterList<T>(EmployeeEntryDto modelDto);
    }
}
