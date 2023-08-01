using SchoolManagement.Services.Students.Models.StudentAttendanceModels;

namespace SchoolManagement.Services.Students.Managers;

public interface IStudentAttendanceManager
{
    public Task<List<StudentAttendanceModel>> GetStudentAttendances(Guid studentId);
    public Task<StudentAttendanceModel> AddStudentAtttendance(Guid studentId,CreateStudentAttendanceModel model);
    public Task UpdateStudentAttendance(Guid StudentId,Guid topicId, UpdateStudentAttendanceModel model);
}
