using static InterviewTest.DB.Enums.Enum;

namespace InterviewTest.DB.Models
{
    public class Task : DBModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime EndDate { get; set; }
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

    }
}
