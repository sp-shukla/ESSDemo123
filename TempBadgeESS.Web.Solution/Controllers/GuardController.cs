using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using TempBadgeESS.Web.Solution.Models;
using TempBadgeESS.Web.Solution.Services.Interface;

namespace TempBadgeESS.Web.Solution.Controllers
{
    public class GuardController : Controller
    {
        private readonly IGuardService _service;

        public GuardController(IGuardService service)
        {
            _service = service;
        }

        public async Task<IActionResult> CreateTempBadge(int id)
        {
            var response = await _service.CreateTempBadgeId<ResponseDto>(id);
            if (response != null && response.IsSuccess)
            {
                EmployeeEntryDto model = JsonConvert.DeserializeObject<EmployeeEntryDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return RedirectToAction("SignIn", "Employee");
        }

        
        public async Task<IActionResult> SignOutPage(EmployeeEntryDto modelDto)
        {
            var response = await _service.SignOutEmployee<ResponseDto>(modelDto);
            if (response != null && response.IsSuccess)
            {
                EmployeeEntryDto model = JsonConvert.DeserializeObject<EmployeeEntryDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return RedirectToAction("SignIn", "Employee");
        }
        public async Task<IActionResult> BadgeQueuePage()
        {
            List<GuardDto> list = new List<GuardDto>();
			var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _service.GetAllTempBadgeQueue<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
            {
                 list = JsonConvert.DeserializeObject<List<GuardDto>>(Convert.ToString(response.Result));
                return View(list);
            }

            return RedirectToAction("SignIn", "Employee");
        }
        public async Task<IActionResult> BadgeOutPage()
        {
            List<GuardDto> list = new List<GuardDto>();
			var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _service.GetAllTempBadgeOutList<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<GuardDto>>(Convert.ToString(response.Result));
                return View(list);
            }

            return RedirectToAction("SignIn", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> Report()
        {
            List<GuardDto> list = new List<GuardDto>();
			var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _service.GetAllTempBadgeList<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<GuardDto>>(Convert.ToString(response.Result));
                return View(list);
            }

            return RedirectToAction("SignIn", "Employee");

        }


        [HttpPost]
        public async Task<IActionResult>FilterPage(string fname,string lname,DateTime signin,DateTime signout)
        {
            EmployeeEntryDto model = new EmployeeEntryDto();
            model.FirstName = fname;
            model.LastName = lname;
            model.SignIn= signin;
            model.SignOut= signout;
           
            List<EmployeeEntryDto> list = new ();
          
          
            var response = await _service.FilterList<ResponseDto>(model);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EmployeeEntryDto>>(Convert.ToString(response.Result));
                return View("Report",list);
            }

            return RedirectToAction("SignIn", "Employee");
        }

    }

    
}
