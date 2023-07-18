using InterviewTest.Application.Services.Employees.Base.Models;

namespace InterviewTest.AutoMapperRules.Profiles
{
    public class AutoMapperGlobalProfile : AutoMapper.Profile
    {
        public AutoMapperGlobalProfile()
        {
            BaseEmployeeeDTO.CreateMappingRules(this);
        }
    }
}
