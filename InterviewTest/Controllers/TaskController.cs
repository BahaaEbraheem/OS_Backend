using InterviewTest.Application.Services.Employees.Base;
using InterviewTest.Application.Services.Employees.Base.Models;
using InterviewTest.Application.Services.Tasks.Base;
using InterviewTest.Application.Services.Tasks.Base.Models;
using InterviewTest.DB.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static InterviewTest.DB.Enums.Enum;
using Task = InterviewTest.DB.Models.Task;

namespace InterviewTest.Controllers
{
    public class TaskController : BaseAppController
    {
        public TaskController()
        {

        }

        /// <summary>
        /// Get a page of employees
        /// </summary>
        /// <param name="page"></param>
        /// <param name="taskService"></param>
        /// <returns></returns>
        [HttpGet("TasksList")]
        public async Task<ApiResponse<List<BaseTaskDTO>>> List(int? page, [FromServices] IBaseTaskService taskService)
        {
            if(page < 0)
                return WrapErrorResult<List<BaseTaskDTO>>("Page must be greater than 0");
            return WrapResult(await taskService.List(page.GetValueOrDefault(0)));
        }

        [HttpGet("GetTasksWithFilters")]
        public async Task<ApiResponse<List<BaseTaskDTO>>> GetTasksWithFilters(Status? status, Priority? priority, int pageNumber, int pageSize, int? employeeId, [FromServices] IBaseTaskService taskService)
        {

            return WrapResult(await taskService.GetTasksWithFilters(status,priority,pageNumber,pageSize,employeeId));
        }

        [HttpPost("addTask")]
        public  ApiResponse<BaseTaskDTO> AddTask(int pageNumber, int pageSize,[FromServices] IBaseTaskService taskService,[FromBody] BaseTaskDTO inputModel)
        {
            if (!ModelState.IsValid)
            {
                return  new ApiResponse<BaseTaskDTO>
                {
                    Succeed = false,
                    Error = "Invalid input data",
                    Data = null
                };
            }
            try
            {


                var newTask = new BaseTaskDTO
                {

                    Title = inputModel.Title,
                    Description = inputModel.Description,
                    Priority = inputModel.Priority,
                    EndDate = inputModel.EndDate
                };

                // Check if the same task already exists based on your criteria (e.g., title)
                bool taskExists =  taskService.TaskExists(inputModel.Title).Result;

                if (taskExists)
                {
                    throw new Exception("Task Exist Before");
                }


                var addedTasks =  taskService.AddTask(pageNumber, pageSize, newTask);

                var Response = new ApiResponse<BaseTaskDTO>
                {
                    Succeed = false,
                    Error = "An error occurred while adding the task",
                    Data = addedTasks.Result
                };
                return Response; 
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse<BaseTaskDTO>
                {
                    Succeed = false,
                    Error = "An error occurred while adding the task",
                    Data = null
                };
                return  errorResponse;
            }

        }


    }




}

