using AutoMapper;
using TempBadgeESS.EmployeeAPI.Solution.Models;
using TempBadgeESS.EmployeeAPI.Solution.Models.DTO;

namespace TempBadgeESS.GaurdAPI.Solution.Helper.MappingConfiguration
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDto, Employee>();
                config.CreateMap<Employee, EmployeeDto>();
            });
            return mappingConfig;
        }
    }
}
