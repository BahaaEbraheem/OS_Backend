using InterviewTest.DB.Models;

using Microsoft.EntityFrameworkCore;
using Task = InterviewTest.DB.Models.Task;

namespace InterviewTest.DB
{
    public class InterviewTestDbContext : DbContext
    {
        public InterviewTestDbContext(DbContextOptions<InterviewTestDbContext> options) : base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
