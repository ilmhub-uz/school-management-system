using Student.API.Models.StudentAttendanceModels;

namespace Student.API.Managers.Interfaces;

public interface IStudentAttendanceManager
{
    Task<StudentAttendanceModel> AddStudentAttendanceAsync(Guid studentId, Guid topicId);
    Task<List<StudentAttendanceModel>> GetStudentAttendancesAsync();
    Task<StudentAttendanceModel> UpdateStudentAttendanceAsync(Guid studentId, Guid topicId, UpdateStudentAttendanceModel model);
}
