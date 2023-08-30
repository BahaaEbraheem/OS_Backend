using InterviewTest.DB.Models;
using static InterviewTest.DB.Enums.Enum;
using Task = InterviewTest.DB.Models.Task;

namespace InterviewTest.DB.Repositories
{
    public interface ITaskRepo : IBaseRepository<Task, long>
    {
        Task TaskExists(string title);


        IQueryable<Task> GetTasksWithFilters(
  Status? status = null,
  Priority? priority = null,
  int pageNumber = 1,
  int pageSize = 10,
  int? employeeId = null);


        Task<Task> AddTask(Task model, int pageNumber = 1, int pageSize = 10);
    }



    public class TaskRepo : BaseRepository<Task, long>, ITaskRepo
    {
        public TaskRepo(InterviewTestDbContext dbContext) : base(dbContext)
        {
        }
        public  IQueryable<Task> GetTasksWithFilters(Status? status = null, Priority? priority = null, int pageNumber = 1, int pageSize = 10, int? employeeId = null)
        {
            var query = this.Table.AsQueryable();
            // Apply a filter based on the status parameter if it's not null
            if (status.HasValue)
            {
                query = query.Where(task => task.Status == status);
            }
            // Apply a filter based on the priority parameter if it's not null
            if (priority.HasValue)
            {
                query = query.Where(task => task.Priority == priority);
            }
            // Apply a filter based on the employeeId parameter if it's not null
            if (employeeId.HasValue)
            {
                query = query.Where(task => task.EmployeeId == employeeId);
            }
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
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
    }
}
