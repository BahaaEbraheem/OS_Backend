using AutoMapper;
using InterviewTest.Application.Services.Employees.Base.Models;
using InterviewTest.Application.Services.Tasks.Base.Models;

namespace InterviewTest.AutoMapperRules.Profiles
{

    public class AutoMapperGlobalProfile : Profile
    {
        public AutoMapperGlobalProfile()
        {
            BaseEmployeeeDTO.CreateMappingRules(this);
            BaseTaskDTO.CreateMappingRules(this);

        }

    }
}
