using InterviewTest.DB.Models;

namespace InterviewTest.DB.Repositories
{
    public interface IEmployeeRepo : IBaseRepository<Employee, long>
    {
    }


    public class EmployeeRepo : BaseRepository<Employee, long>, IEmployeeRepo
    {
        public EmployeeRepo(InterviewTestDbContext dbContext) : base(dbContext)
        {
        }

    }
}
