using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public interface IStudentAttendanceRepository
{
    Task<List<StudentAttendance>> GetAttendances(Guid studentId);

    Task AddStudentAttendance( StudentAttendance studentAttendance);

    Task UpdateStudentAttendance(StudentAttendance studentAttendance);
    Task<StudentAttendance> GetAttendance(Guid studentId, Guid topicId);
}

