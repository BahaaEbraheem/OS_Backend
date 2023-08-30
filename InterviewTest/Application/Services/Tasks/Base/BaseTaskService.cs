using AutoMapper;
using AutoMapper.QueryableExtensions;

using InterviewTest.Application.Services.Employees.Base.Models;
using InterviewTest.Application.Services.Tasks.Base.Models;
using InterviewTest.DB.Models;
using InterviewTest.DB.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static InterviewTest.DB.Enums.Enum;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;
using Task = InterviewTest.DB.Models.Task;

namespace InterviewTest.Application.Services.Tasks.Base
{
    public interface IBaseTaskService
    {
        Task<List<BaseTaskDTO>> List(int page);
        Task<List<BaseTaskDTO>> GetTasksWithFilters(Status? status, Priority? priority, int pageNumber, int pageSize, int? employeeId);
        Task<BaseTaskDTO> AddTask(int pageNumber, int pageSize, BaseTaskDTO inputModel);
        Task<bool> TaskExists(string title);
    }

    public class BaseTaskService : BaseApplicationService<ITaskRepo, Task, long>, IBaseTaskService
    {
        private readonly IConfigurationProvider configsProvider;
        private readonly IMapper _mapper;

        public BaseTaskService(ITaskRepo repo, IMapper mapper, IConfigurationProvider configsProvider) : base(repo)
        {
            this.configsProvider = configsProvider;
            _mapper = mapper;
        }


        Task<List<BaseTaskDTO>> IBaseTaskService.List(int page)
        {
            return Repo.GetAll()
                       .Skip(page * 10).Take(10)
                       .ProjectTo<BaseTaskDTO>(configsProvider)
                       .ToListAsync();
        }

        async Task<List<BaseTaskDTO>> IBaseTaskService.GetTasksWithFilters(
      Status? status = null,
      Priority? priority = null,
      int pageNumber = 1,
      int pageSize = 10,
      int? employeeId = null)
        {

            var tasks = Repo.GetTasksWithFilters(status, priority, pageNumber, pageSize, employeeId)
             .Skip((pageNumber - 1) * pageSize)
             .Take(pageSize)
             .ToListAsync().Result;
            return await Repo.GetTasksWithFilters(status, priority, pageNumber, pageSize, employeeId)
                       .Skip(pageSize * 10).Take(10)
                       .ProjectTo<BaseTaskDTO>(configsProvider)
                       .ToListAsync();
        }



        public async Task<BaseTaskDTO> AddTask(int pageNumber, int pageSize, BaseTaskDTO inputModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BaseTaskDTO, Task>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ReverseMap();
            });

            var mapper = config.CreateMapper();

            var taskToAdd = mapper.Map<Task>(inputModel);

            var task =_mapper.Map<BaseTaskDTO>(await Repo.AddTask(taskToAdd, pageNumber, pageSize));
           return  task;
                                  
    
        }

        public async Task<bool> TaskExists(string title)
        {
            var taskExists = Repo.TaskExists(title);
            if (taskExists!=null)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
