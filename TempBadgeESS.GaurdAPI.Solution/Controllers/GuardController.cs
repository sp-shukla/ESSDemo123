using Microsoft.AspNetCore.Mvc;
using TempBadgeESS.GuardAPI.Solution.Models.DTO;
using TempBadgeESS.GaurdAPI.Solution.Repository.Interface;
using TempBadgeESS.GaurdAPI.Solution.Models.DTO;
using TempBadgeESS.GuardAPI.Solution.Models;
using Microsoft.AspNetCore.Authorization;

namespace TempBadgeESS.GaurdAPI.Solution.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class GuardController : ControllerBase
    {
        private readonly IGuardRepository _repo;
        protected ResponseDto _response;

        public GuardController(IGuardRepository repo)
        {
            _repo = repo;
            _response = new ResponseDto();
        }

        // /CreateBadge/id
        [HttpGet("{id}")]
        public async Task<ResponseDto> CreateBadge(int id)
        {
            try
            {
                EmployeeEntryDto NewBadge = await _repo.CreateTempBadgeId(id);
                _response.Result = NewBadge;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;

        }

     



        [HttpPost]
        public async Task<object> SignOutEmployee(EmployeeEntryDto modeldto)
        {
            try
            {
                EmployeeEntryDto empSignOut = await _repo.SignOutEmployee(modeldto);
                _response.Result = empSignOut;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;

        }

        [HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<object> GetAllTempEmployeeList()
        {
            try
            {
                IEnumerable<GuardDto> list = await _repo.GetAllTempBadgeList();
                _response.Result = list;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;

        }

        [HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<object> GetBadgeQueueList()
        {
            try
            {
                IEnumerable<GuardDto> list = await _repo.GetAllTempBadgeQueue();
                _response.Result = list;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;

        }

        [HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<object> GetBadgeOutList()
        {
            try
            {
                IEnumerable<GuardDto> list = await _repo.GetBadgeOutPage();
                _response.Result = list;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;

        }

      
        [HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<object> Filter(EmployeeEntryDto modelDto)
        {
            try
            {
                IEnumerable<EmployeeEntryDto> list = await _repo.FilterEmployeelist(modelDto);
                _response.Result = list;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;

        }

    }
}
