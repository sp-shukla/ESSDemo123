using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TempBadgeESS.Web.Solution.Models;
using TempBadgeESS.Web.Solution.Services.Interface;

namespace TempBadgeESS.Web.Solution.Controllers
{
    
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult>Search(EmployeeDto modelDto)
        {
            List<EmployeeDto> list = new();
           
                var response = await _service.GetEmployeeByName<ResponseDto>(modelDto);
                if (response != null && response.IsSuccess)
                {
                  list = JsonConvert.DeserializeObject<List<EmployeeDto>>(Convert.ToString(response.Result));
                    return View(list);
                }
            
           
               
               
           
            return RedirectToAction("SignIn");
        }

    }
}
