using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public class StudentAttendanceRepository: IStudentAttendanceRepository
{
    private readonly StudentsDbContext _studentsDbContext;

    public StudentAttendanceRepository(StudentsDbContext studentsDbContext)
    {
        _studentsDbContext = studentsDbContext;
    }

    public async Task<List<StudentAttendance>> GetAttendances(string username)
    {
        var student = GetStudentByUsername(username);
        return student.Attendances.ToList();
    }

    public async Task AddStudentAttendance(string username, StudentAttendance studentAttendance)
    {
        var student = GetStudentByUsername(username);
        _studentsDbContext.StudentAttendances.Add(studentAttendance);
        await _studentsDbContext.SaveChangesAsync();
    }

    public async Task UpdateStudentAttendance(string username, StudentAttendance studentAttendance)
    {
        var student = GetStudentByUsername(username);
        _studentsDbContext.StudentAttendances.Update(studentAttendance);
        await _studentsDbContext.SaveChangesAsync();
    }

    private Student? GetStudentByUsername(string username)
    {
        var student =  _studentsDbContext.Students.FirstOrDefault(u => u.Username == username);
        if (student == null)
            throw new Exception("Student Not Found");
        return student;
    }
}