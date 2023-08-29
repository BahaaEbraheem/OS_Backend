using AutoMapper;

using InterviewTest.AutoMapperRules.Profiles;
using InterviewTest.DB.Models;
using System.ComponentModel.DataAnnotations;
using static InterviewTest.DB.Enums.Enum;
using Task = InterviewTest.DB.Models.Task;

namespace InterviewTest.Application.Services.Tasks.Base.Models
{
    public class BaseTaskDTO
    {
        public long Id { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Title must be at least 10 characters long")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]

        public DateTime EndDate { get; set; }
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        internal static void CreateMappingRules(AutoMapperGlobalProfile profile)
        {
            profile.CreateMap<Task, BaseTaskDTO>()
                   ;
        }
    }
}
