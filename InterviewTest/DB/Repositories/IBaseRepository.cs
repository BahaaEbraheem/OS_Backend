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

        TModel Create(TModel model);

      //  IQueryable<TModel> GetTasksWithFilters(
      //Status? status = null,
      //Priority? priority = null,
      //int pageNumber = 1,
      //int pageSize = 10,
      //int? employeeId = null);

        //Task<TModel> AddTask(TModel model,int pageNumber = 1,int pageSize = 10);

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

        public TModel Create(TModel model)
        {
            var entry= this.Table.Add(model);
            this.DbContext.SaveChanges();
            return entry.Entity;

        }
    }
}
