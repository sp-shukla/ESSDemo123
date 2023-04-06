using AutoMapper;
using TempBadgeESS.GuardAPI.Solution.Models;
using TempBadgeESS.GuardAPI.Solution.Models.DTO;

namespace TempBadgeESS.GuardAPI.Solution.Helper.MappingConfiguration
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDto, Employee>();
                config.CreateMap<Employee, EmployeeDto>();
                config.CreateMap<EmployeeEntryDto, EmployeeEntry>();
                config.CreateMap<EmployeeEntry, EmployeeEntryDto>();
            });
            return mappingConfig;
        }
    }
}
