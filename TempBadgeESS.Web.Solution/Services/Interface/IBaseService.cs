using TempBadgeESS.Web.Solution.Models;

namespace TempBadgeESS.Web.Solution.Services.Interface
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
      
    }
}
