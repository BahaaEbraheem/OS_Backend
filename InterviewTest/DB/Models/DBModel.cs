using Microsoft.EntityFrameworkCore;

namespace InterviewTest.DB.Models
{
    [PrimaryKey("Id")]
    public class DBModel
    {
        public long Id { get; set; }
    }
}