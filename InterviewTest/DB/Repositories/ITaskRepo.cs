using InterviewTest.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using static InterviewTest.DB.Enums.Enum;
using Task = InterviewTest.DB.Models.Task;

namespace InterviewTest.DB.Repositories
{
    public interface ITaskRepo : IBaseRepository<Task, long>
    {
        Task TaskExists(string title);

        public Task<List<Task>> GetTasksWithFilters(int skipCount, int maxResultCount, string sorting, string filter=null,
            Status? status = null,Priority? priority = null, long? employeeId = null);
  //      IQueryable<Task> GetTasksWithFilters(
  //Status? status = null,
  //Priority? priority = null,
  //int pageNumber = 1,
  //int pageSize = 10,
  //int? employeeId = null);


        Task<Task> AddTask(Task model, int pageNumber = 1, int pageSize = 10);
    }



    public class TaskRepo : BaseRepository<Task, long>, ITaskRepo
    {
        public TaskRepo(InterviewTestDbContext dbContext) : base(dbContext)
        {
        }
    


        public async Task<Task> AddTask(Task model, int pageNumber, int pageSize)
        {
            var addedEntity = await this.Table.AddAsync(model);
            await this.DbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }


        Task  ITaskRepo.TaskExists(string title)
        {
            var EntityExist =  this.Table.Where(a=>a.Title==title).FirstOrDefault();
            return (Task)EntityExist;
        }

        public async Task<List<Task>> GetTasksWithFilters(int skipCount, int maxResultCount, string sorting, string filter=null, Status? status = null, Priority? priority = null, long? employeeId = null)
        {
            var query = this.DbContext.Tasks.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query =query.Where(task => task.Title == filter || task.Description == filter);
            }
            if (status.HasValue && status != 0)
            {
                query = query.Where(task => task.Status == status);
            }
          //  Apply a filter based on the priority parameter if it's not null
            if (priority.HasValue && priority!=0)
            {
                query = query.Where(task => task.Priority == priority);
            }
            // Apply a filter based on the employeeId parameter if it's not null
            if (employeeId.HasValue && employeeId != 0)
            {
                query =query.Where(task => task.EmployeeId == employeeId);
            }
            return  query.Skip(skipCount).Take(maxResultCount).ToList();
        }


    }
}
