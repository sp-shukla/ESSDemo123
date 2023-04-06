using Newtonsoft.Json.Linq;
using TempBadgeESS.Web.Solution.Models;
using TempBadgeESS.Web.Solution.Services.Interface;

namespace TempBadgeESS.Web.Solution.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IHttpClientFactory _clientFactory;
        public EmployeeService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> GetEmployeeByName<T>(EmployeeDto modelDto)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = modelDto,
                Url = StaticDetails.EmployeeAPIBase+ "api/Employee",
                AccessToken = ""
            });
        }
    }
}
