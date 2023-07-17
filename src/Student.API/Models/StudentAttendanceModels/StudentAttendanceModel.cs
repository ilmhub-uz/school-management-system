namespace Student.API.Models.StudentAttendanceModels
{
    public class StudentAttendanceModel
    {
        public required Guid TopicId { get; set; }
        public required Guid StudentId { get; set; }
        public bool Attend { get; set; }
    }
}
