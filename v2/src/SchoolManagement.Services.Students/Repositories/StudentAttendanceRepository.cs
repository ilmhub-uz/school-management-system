using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;
using System.Runtime.CompilerServices;

namespace SchoolManagement.Services.Students.Repositories;

public class StudentAttendanceRepository : IStudentAttendanceRepository
{
    private readonly StudentsDbContext _studentsDbContext;

    public StudentAttendanceRepository(StudentsDbContext studentsDbContext)
    {
        _studentsDbContext = studentsDbContext;
    }
    public async Task<List<StudentAttendance>> GetAttendances(Guid studentId)
    {
       var students = await _studentsDbContext.StudentAttendances.Where(s => s.StudentId == studentId).ToListAsync();
       return students;
    }

    public async Task AddStudentAttendance(StudentAttendance studentAttendance)
    {
        _studentsDbContext.StudentAttendances.Add(studentAttendance);
        await _studentsDbContext.SaveChangesAsync();
    }

    public async Task UpdateStudentAttendance(StudentAttendance studentAttendance)
    {
        _studentsDbContext.StudentAttendances.Update(studentAttendance);
        await _studentsDbContext.SaveChangesAsync();
    }

    public async Task<StudentAttendance> GetAttendance(Guid studentId, Guid topicId)
    {
        return await _studentsDbContext.StudentAttendances.Where(s => s.StudentId == studentId && s.TopicId == topicId).FirstOrDefaultAsync();

    }
}