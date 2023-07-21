using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public interface IStudentAttendanceRepository
{
    Task<List<Entities.StudentAttendance>> GetAttendances(string username);

    Task AddStudentAttendance(string username, StudentAttendance studentAttendance);

    Task UpdateStudentAttendance(string username, StudentAttendance studentAttendance);
}

/*
    GET	 students/{username}/attendances
    POST students/{username}/attendances
    PUT	 students/{username}/attendances
 */