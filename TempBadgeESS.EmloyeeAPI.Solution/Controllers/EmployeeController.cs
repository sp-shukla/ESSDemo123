using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TempBadgeESS.EmloyeeAPI.Solution.Models.DTO;
using TempBadgeESS.EmployeeAPI.Solution.Models.DTO;
using TempBadgeESS.GaurdAPI.Solution.Repository.Interface;

namespace TempBadgeESS.EmloyeeAPI.Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        protected ResponseDto _response;
        public EmployeeController(IEmployeeRepository repo)
        {
            _repo= repo;
            this._response= new ResponseDto();
        }

        [HttpPost]
        public async Task<object> GetListOfEmployee([FromBody] EmployeeDto modelDto)
        {
            try
            {
                IEnumerable<EmployeeDto> employeeList = await _repo.GetEmployees(modelDto);
                _response.Result = employeeList;
            }
            catch(Exception ex) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
