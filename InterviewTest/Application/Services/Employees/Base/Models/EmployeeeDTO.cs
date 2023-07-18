using AutoMapper;

using InterviewTest.AutoMapperRules.Profiles;
using InterviewTest.DB.Models;

namespace InterviewTest.Application.Services.Employees.Base.Models
{
    public class BaseEmployeeeDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public int BornIn { get; set; }

        internal static void CreateMappingRules(AutoMapperGlobalProfile profile)
        {
            profile.CreateMap<Employee, BaseEmployeeeDTO>()
                   .ForMember(c => c.BornIn, x => x.MapFrom(src => DateTime.Now.Year - src.Age))
                   ;
        }
    }
}
