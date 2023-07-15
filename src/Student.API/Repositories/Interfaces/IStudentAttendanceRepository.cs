using Student.API.Entities;

namespace Student.API.Repositories.Interfaces
{
    public interface IStudentAttendanceRepository
    {
        Task<List<StudentAttendance>> GetStudentAttendance();
        Task AddStudentAttendance(StudentAttendance studentAttendance);
        Task UpdateStudentAttendance(StudentAttendance studentAttendance);
        
    }
}
