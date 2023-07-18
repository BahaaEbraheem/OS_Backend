using InterviewTest.DB.Models;

using Microsoft.EntityFrameworkCore;

namespace InterviewTest.DB
{
    public class InterviewTestDbContext : DbContext
    {
        public InterviewTestDbContext(DbContextOptions<InterviewTestDbContext> options) : base(options)
        {

        }


        public DbSet<Employee> Employees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
