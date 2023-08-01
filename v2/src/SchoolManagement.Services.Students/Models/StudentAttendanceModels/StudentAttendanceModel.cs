using SchoolManagement.Services.Students.Models.StudentModels;

namespace SchoolManagement.Services.Students.Models.StudentAttendanceModels;

public class StudentAttendanceModel 
{ 

public required Guid TopicId { get; set; }
public required Guid StudentId { get; set; }
public StudentModel? Student { get; set; }
public bool Attend { get; set; }
}
