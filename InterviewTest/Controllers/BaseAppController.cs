using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace InterviewTest.Controllers
{
    public class ApiResponse<T>
    {
        public bool Succeed { get; set; }
        public string Error { get; set; }
        public int? ErrorCode { get; set; }
        public T Data { get; set; }
    }
    public class BaseAppController : ControllerBase
    {


        protected ApiResponse<T> WrapResult<T>(T result)
        {
            return new ApiResponse<T>
            {
                Data = result,
                Succeed = true,
            };
        }

        protected ApiResponse<T> WrapErrorResult<T>(string errorMessage, int? errorCode = null)
        {
            return new ApiResponse<T>
            {
                Error = errorMessage,
                Succeed = false,
                ErrorCode = errorCode
            };
        }
    }
}