using Microsoft.EntityFrameworkCore;

namespace InterviewTest.DB.Repositories
{
    public interface IBaseRepository<TModel, Tkey> 
        where TModel : class
        where Tkey : struct
    {
        TModel GetById(Tkey id);

        Task<TModel> GetByIdAsync(Tkey id);

        IQueryable<TModel> GetAll();
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
    }
}
