using InterviewTest.DB.Repositories;

namespace InterviewTest.Application.Services
{

    public interface IBaseApplicationService<Repo, TModel, Tkey>
        where Repo : IBaseRepository<TModel, Tkey>
        where TModel : class
        where Tkey : struct
    {

    }
    public class BaseApplicationService<ITRepo, TModel, Tkey> : IBaseApplicationService<ITRepo, TModel, Tkey>
        where ITRepo : IBaseRepository<TModel, Tkey>
        where TModel : class
        where Tkey : struct
    {
        public ITRepo Repo { get; }

        public BaseApplicationService(ITRepo repo)
        {
            Repo = repo;
        }

    }

}
