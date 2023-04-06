using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TempBadgeESS.EmloyeeAPI.Solution.Data;

using TempBadgeESS.EmployeeAPI.Solution.Models;
using TempBadgeESS.EmployeeAPI.Solution.Models.DTO;

namespace TempBadgeESS.GaurdAPI.Solution.Repository.Interface
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _Db;
        private IMapper _mapper;
        public EmployeeRepository( ApplicationDbContext Db,IMapper mapper)
        {
           _Db= Db;
            _mapper= mapper;
        }
        public async Task<IEnumerable<EmployeeDto>> GetEmployees(EmployeeDto modelDto)
        {
            List<Employee> List_Of_Employee = await _Db.Employees.Where(x => x.FirstName.Equals(modelDto.FirstName) && x.LastName.Equals(modelDto.LastName)).ToListAsync();

            return _mapper.Map<List<EmployeeDto>>(List_Of_Employee);

        }


    }
}
