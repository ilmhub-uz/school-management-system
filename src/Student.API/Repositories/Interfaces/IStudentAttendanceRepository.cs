using Student.API.Entities;

namespace Student.API.Repositories.Interfaces;

public interface IStudentAttendanceRepository
{

    Task<List<StudentAttendance>> GetStudentAttendancesAsync();
    Task<StudentAttendance> GetStudentAttendanceAsync(Guid studentId, Guid topicId);
    Task AddStudentAttendanceAsync(StudentAttendance studentAttendance);
    Task UpdateStudentAttendanceAsync(StudentAttendance studentAttendance);
    Task DeleteStudentAttendanceAsync(Guid studentId, Guid topicId);
}

