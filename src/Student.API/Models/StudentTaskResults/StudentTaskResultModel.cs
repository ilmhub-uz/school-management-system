namespace Student.API.Models.StudentTaskResults
{
    public class StudentTaskResultModel
    {
        public Guid TaskId { get; set; }
        public Guid StudentId { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required string Content { get; set; }
    }
}
