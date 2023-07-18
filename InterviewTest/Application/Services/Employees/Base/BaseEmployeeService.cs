using AutoMapper;
using AutoMapper.QueryableExtensions;

using InterviewTest.Application.Services.Employees.Base.Models;
using InterviewTest.DB.Models;
using InterviewTest.DB.Repositories;

using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Application.Services.Employees.Base
{
    public interface IBaseEmployeeService
    {
        Task<List<BaseEmployeeeDTO>> List(int page);
    }

    public class BaseEmployeeService : BaseApplicationService<IEmployeeRepo, Employee, long>, IBaseEmployeeService
    {
        private readonly AutoMapper.IConfigurationProvider configsProvider;

        public BaseEmployeeService(IEmployeeRepo repo, AutoMapper.IConfigurationProvider configsProvider) : base(repo)
        {
            this.configsProvider = configsProvider;
        }


        public Task<List<BaseEmployeeeDTO>> List(int page)
        {
            return Repo.GetAll()
                        .Skip(page * 10).Take(10)
                        .ProjectTo<BaseEmployeeeDTO>(configsProvider)
                        .ToListAsync();
        }
    }
}
