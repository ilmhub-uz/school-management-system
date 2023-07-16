using Student.API.Entities;

namespace Student.API.Repositories.Interfaces
{
    public interface IStudentAttendanceRepository
    {
        Task<List<StudentAttendance>> GetStudentAttendanceAsync();
        Task AddStudentAttendanceAsync(StudentAttendance studentAttendance);
        Task UpdateStudentAttendanceAsync(StudentAttendance studentAttendance);
        
    }
}
