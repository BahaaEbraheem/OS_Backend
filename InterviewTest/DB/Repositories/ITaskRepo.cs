using InterviewTest.DB.Models;
using Task = InterviewTest.DB.Models.Task;

namespace InterviewTest.DB.Repositories
{
    public interface ITaskRepo : IBaseRepository<Task, long>
    {
        Task TaskExists(string title);
    }


    public class TaskRepo : BaseRepository<Task, long>, ITaskRepo
    {
        public TaskRepo(InterviewTestDbContext dbContext) : base(dbContext)
        {
        }

        Task  ITaskRepo.TaskExists(string title)
        {
            var EntityExist =  this.Table.Find(title);
            return EntityExist;
        }
    }
}
