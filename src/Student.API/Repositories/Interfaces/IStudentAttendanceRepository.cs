using Student.API.Entities;

namespace Student.API.Repositories.Interfaces
{
    public interface IStudentAttendanceRepository
    {
        Task<List<StudentAttendance>> GetStudentAttendance(string studentUsername);
        Task AddStudentAttendance(StudentAttendance studentAttendance, string studentUsername);
        Task UpdateStudentAttendance(StudentAttendance studentAttendance, string studentUsername);
        
    }
}
