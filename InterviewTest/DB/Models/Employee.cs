namespace InterviewTest.DB.Models
{
    public class Employee : DBModel
    {
        public string Name { get; set; }

        public byte Age { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}
