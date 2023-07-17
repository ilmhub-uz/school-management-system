namespace Student.API.Models.StudentAttendanceModels;

public class AddStudentAttendanceModel
{
    public required Guid TopicId { get; set; }
    public required Guid StudentId { get; set; }
}
