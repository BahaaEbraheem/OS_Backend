using AutoMapper;
using InterviewTest.Application.Services.Tasks.Base.Models;

namespace InterviewTest.AutoMapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseTaskDTO, Task>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ReverseMap();
            CreateMap<Task, BaseTaskDTO>()
             .ReverseMap();
            CreateMap<List<BaseTaskDTO>, List<Task>>();
        }
    }
}
