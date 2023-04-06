using System;
using TempBadgeESS.Web.Solution.Models;
using TempBadgeESS.Web.Solution.Services.Interface;

namespace TempBadgeESS.Web.Solution.Services
{
    public class GuardService : BaseService, IGuardService
    {
        private readonly IHttpClientFactory _clientFactory;
        public GuardService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateTempBadgeId<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
               //  Data = id,
                Url = StaticDetails.GuardAPIBase + "CreateBadge/"+id,
                AccessToken = ""
            });
        }

        public async Task<T> FilterList<T>(EmployeeEntryDto modelDto)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = modelDto,
                Url = StaticDetails.GuardAPIBase + "Filter",
                
            });
        }

        public async Task<T> GetAllTempBadgeList<T>(string token)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                
                Url = StaticDetails.GuardAPIBase + "GetAllTempEmployeeList",
                AccessToken = token
            });
        }

        public async Task<T> GetAllTempBadgeOutList<T>(string token)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                //   Data = id,
                Url = StaticDetails.GuardAPIBase + "GetBadgeOutList",
                AccessToken = token
            });
        }

        public async Task<T> GetAllTempBadgeQueue<T>(string token)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                //   Data = id,
                Url = StaticDetails.GuardAPIBase + "GetBadgeQueueList",
                AccessToken = token
            });
        }

        public async Task<T> SignOutEmployee<T>(EmployeeEntryDto modelDto)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = modelDto,
                Url = StaticDetails.GuardAPIBase + "SignOutEmployee",
                AccessToken = ""
            });
        }
    }
}
