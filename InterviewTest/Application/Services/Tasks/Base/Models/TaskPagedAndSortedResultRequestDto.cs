using Abp.Application.Services.Dto;
using static InterviewTest.DB.Enums.Enum;
using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Application.Services.Tasks.Base.Models
{
    public class TaskPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public Priority Priority { get; set; }
        public Status? Status { get; set; }
        public DateTime EndDate { get; set; }
        public long EmployeeId { get; set; }
    }
}
