using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TempBadgeESS.GuardAPI.Solution.Data;
using TempBadgeESS.GaurdAPI.Solution.Models;
using TempBadgeESS.GaurdAPI.Solution.Models.DTO;
using TempBadgeESS.GuardAPI.Solution.Models.DTO;
using TempBadgeESS.GuardAPI.Solution.Models;

namespace TempBadgeESS.GaurdAPI.Solution.Repository.Interface
{
    public class GuardRepository : IGuardRepository
    {
        private readonly ApplicationDbContext _Db;
        private IMapper _mapper;
        public GuardRepository( ApplicationDbContext Db,IMapper mapper)
        {
           _Db= Db;
            _mapper= mapper;
        }

        //Assigning A temporary Badge to the Employee

        public async Task<EmployeeEntryDto> CreateTempBadgeId(int id)
        {
             var e=_Db.Employees.Where(x=>x.EmployeeId==id).FirstOrDefault(); 

         
                EmployeeEntry emp = new EmployeeEntry();

                emp.FirstName = e.FirstName;
                emp.LastName = e.LastName;
                var x = await _Db.EmployeeEntries.OrderBy(x => x.TemporaryBadge).LastOrDefaultAsync();
                emp.TemporaryBadge = x.TemporaryBadge + 1;
                emp.SignIn = DateTime.Now;
                emp.employeeId = e.EmployeeId;
                _Db.EmployeeEntries.Add(emp);
                _Db.SaveChanges();

                return _mapper.Map<EmployeeEntryDto>(emp);


      /*      }

            return _mapper.Map<EmployeeEntryDto>(checks);*/

        }

        public async Task<IEnumerable<EmployeeEntryDto>> FilterEmployeelist(EmployeeEntryDto modelDto)
        {
            IQueryable<EmployeeEntry> query =  _Db.EmployeeEntries.Where(x => x.FirstName != null);
            if (!string.IsNullOrEmpty(modelDto.FirstName))
            {
                query = query.Where(x => x.FirstName.StartsWith(modelDto.FirstName));
            }
            if (!string.IsNullOrEmpty(modelDto.LastName))
            {
                query = query.Where(x => x.LastName.StartsWith(modelDto.LastName));
            }
            if (modelDto.SignIn != DateTime.MinValue)
            {
                query = query.Where(x => x.SignIn >= modelDto.SignIn);
            }
            if (modelDto.SignOut != DateTime.MinValue)
            {
                query = query.Where(x => x.SignIn <= modelDto.SignOut);
            }

             return  _mapper.Map<List<EmployeeEntryDto>>(await query.ToListAsync());



          
        }

        public async Task<IEnumerable<GuardDto>> GetAllTempBadgeList()
        {
          //  throw new NotImplementedException();

            var employeeList = await (from a in _Db.Employees
                                join b in _Db.EmployeeEntries on a.EmployeeId equals b.employeeId
                               // where b.SignOut == null
                                select new GuardDto
                                {
                                    FirstName = b.FirstName,
                                    LastName = b.LastName,
                                    TemporaryBadge = b.TemporaryBadge,
                                    SignIn = b.SignIn,
                                    SignOut = b.SignOut,
                                    Image = a.ImageUrl,
                                    ActiveTime = (TimeSpan)(b.SignOut - b.SignIn),



                                }).ToListAsync();
            return employeeList;
        }

        public async Task<IEnumerable<GuardDto>> GetAllTempBadgeQueue()
        {
            var ActiveEmployeeList = await (from a in _Db.EmployeeEntries
                                     join b in _Db.Employees on a.employeeId equals b.EmployeeId
                                     where a.SignOut == DateTime.MinValue
                                     select new GuardDto
                                     {
                                         FirstName = a.FirstName,
                                         LastName = a.LastName,
                                         TemporaryBadge = a.TemporaryBadge,
                                         SignIn = a.SignIn,
                                         SignOut = a.SignOut,
                                         Image = b.ImageUrl,
                                         Status = "Active",
                                       //  ActiveTime = (TimeSpan)(a.SignOut - a.SignIn),



                                     }).ToListAsync();
            return ActiveEmployeeList;
        }

        public async  Task<IEnumerable<GuardDto>> GetBadgeOutPage()
        {
            var EmployeeList= await(from a in _Db.Employees
                                     join b in _Db.EmployeeEntries on a.EmployeeId equals b.employeeId
                                     where b.SignOut != DateTime.MinValue && b.SignOut < DateTime.UtcNow
                                     select new GuardDto
                                     {
                                         FirstName = b.FirstName,
                                         LastName = b.LastName,
                                         TemporaryBadge = b.TemporaryBadge,
                                         SignIn = b.SignIn,
                                         SignOut = b.SignOut,
                                         Image = a.ImageUrl,
                                         ActiveTime = (TimeSpan)(b.SignOut - b.SignIn),



                                     }).ToListAsync();
            return EmployeeList;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            Employee employee=await _Db.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        //SignOut by Employee by Inserting Correct TempBadge Number;

        public async Task<EmployeeEntryDto> SignOutEmployee(EmployeeEntryDto modelDto)
        {
            EmployeeEntry employee=await _Db.EmployeeEntries.FirstOrDefaultAsync(x=>x.TemporaryBadge== modelDto.TemporaryBadge);

            if(employee!=null)
            {
                employee.SignOut = DateTime.Now;
                _Db.EmployeeEntries.Update(employee);
               await _Db.SaveChangesAsync();

                return _mapper.Map<EmployeeEntryDto>(employee);

            }
            return null;
        }
    }
}
