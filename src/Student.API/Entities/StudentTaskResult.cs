namespace Student.API.Entities
{
    public class StudentTaskResult
    {
        public Guid TaskId { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public required DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set;}
        public string Content { get; set; }
    }
}
