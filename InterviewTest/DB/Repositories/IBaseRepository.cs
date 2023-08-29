using AutoMapper.Execution;
using InterviewTest.DB.Models;
using Microsoft.EntityFrameworkCore;
using static InterviewTest.DB.Enums.Enum;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Task = InterviewTest.DB.Models.Task;

namespace InterviewTest.DB.Repositories
{
    public interface IBaseRepository<TModel, Tkey> 
        where TModel : class
        where Tkey : struct
    {
        TModel GetById(Tkey id);

        Task<TModel> GetByIdAsync(Tkey id);

        IQueryable<TModel> GetAll();
        IQueryable<TModel> GetTasksWithFilters(
      Status? status = null,
      Priority? priority = null,
      int pageNumber = 1,
      int pageSize = 10,
      int? employeeId = null);

        Task<TModel> AddTask(TModel model,int pageNumber = 1,int pageSize = 10);

    }


    public class BaseRepository<TModel, Tkey> : IBaseRepository<TModel, Tkey>
        where TModel : class
        where Tkey : struct
    {
        protected readonly InterviewTestDbContext DbContext;

        public DbSet<TModel> Table { get; }

        public BaseRepository(InterviewTestDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.Table = dbContext.Set<TModel>();
        }
        public TModel GetById(Tkey id)
        {
            return this.Table.Find(id);
        }

        public async Task<TModel> GetByIdAsync(Tkey id)
        {
            return await this.Table.FindAsync(id);
        }

        public IQueryable<TModel> GetAll()
        {
            return this.Table.AsQueryable();
        }

        public IQueryable<TModel> GetTasksWithFilters(Status? status = null, Priority? priority = null, int pageNumber = 1, int pageSize = 10, int? employeeId = null)
        {
        var query = this.DbContext.Set<Task>().AsQueryable();

        if (!string.IsNullOrEmpty(status.ToString()))
            query = query.Where(task => task.Status == status);

        if (!string.IsNullOrEmpty(priority.ToString()))
            query = query.Where(task => task.Priority == priority);

        if (employeeId != 0)
            query = query.Where(task => task.EmployeeId == employeeId);

        return (IQueryable<TModel>)query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }



        public async Task<TModel> AddTask(TModel model, int pageNumber, int pageSize)
        {
            var addedEntity = await this.Table.AddAsync(model);
            await this.DbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }
      
    }
}
