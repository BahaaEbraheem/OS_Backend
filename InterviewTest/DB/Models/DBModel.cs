using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace InterviewTest.DB.Models
{
    public class DBModel
    {
        [Key]
        public long Id { get; set; }
    }
}