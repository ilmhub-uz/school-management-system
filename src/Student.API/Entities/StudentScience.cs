namespace Student.API.Entities;

public class StudentScience
{
    public required int ScienceId { get; set; }
    public required Guid StudentId { get; set; }
    public Student? Student { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Status Status { get; set; }
}

