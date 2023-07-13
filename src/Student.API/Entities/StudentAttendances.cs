namespace Student.API.Entities;

public class StudentAttendances
{
    public Guid TopicId { get; set; }
    public Guid StudentId { get; set; }
    public bool Attend { get; set; }
}

}
