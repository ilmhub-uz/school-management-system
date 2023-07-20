namespace Student.API.Models.StudentAttendanceModels;

public class UpdateStudentAttendanceModel
{
    public Guid TopicId { get; set; }
    public bool? Attend { get; set; }
}