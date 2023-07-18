using InterviewTest.Application.Services.Employees.Base;
using InterviewTest.Application.Services.Employees.Base.Models;

using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    public class EmployeeController : ControllerBase
    {
        public EmployeeController()
        {

        }

        /// <summary>
        /// Get a page of employees
        /// </summary>
        /// <param name="page"></param>
        /// <param name="employeeService"></param>
        /// <returns></returns>
        [HttpGet("List")]
        public Task<List<BaseEmployeeeDTO>> List(int? page, [FromServices] IBaseEmployeeService employeeService)
        {
            return employeeService.List(page.GetValueOrDefault(0));
        }
    }
}
