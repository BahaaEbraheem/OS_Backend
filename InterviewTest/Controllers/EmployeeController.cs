using InterviewTest.Application.Services.Employees.Base;
using InterviewTest.Application.Services.Employees.Base.Models;

using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    public class EmployeeController : BaseAppController
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
        public async Task<ApiResponse<List<BaseEmployeeeDTO>>> List(int? page, [FromServices] IBaseEmployeeService employeeService)
        {
            if(page < 0)
                return WrapErrorResult<List<BaseEmployeeeDTO>>("Page must be greater than 0");
            return WrapResult(await employeeService.List(page.GetValueOrDefault(0)));
        }
    }
}
