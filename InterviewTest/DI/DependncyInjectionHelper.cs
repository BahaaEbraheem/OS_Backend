using InterviewTest.Application.Services.Employees.Base;
using InterviewTest.Application.Services.Tasks.Base;
using InterviewTest.DB.Repositories;

namespace InterviewTest.DI
{
    public static class DependncyInjectionHelper
    {


        public static void AddDependencyInjection(this IServiceCollection services)
        {
            AddRepos(services);
            AddAppServices(services);
        }

        private static void AddAppServices(IServiceCollection services)
        {
            services.AddTransient<IBaseEmployeeService, BaseEmployeeService>();
            services.AddTransient<IBaseTaskService, BaseTaskService>();
        }

        private static void AddRepos(IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepo, EmployeeRepo>();
            services.AddTransient<ITaskRepo, TaskRepo>();
        }
    }
}
