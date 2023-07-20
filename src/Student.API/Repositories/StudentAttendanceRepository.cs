using Microsoft.EntityFrameworkCore;
using Student.API.Context;
using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.Repositories.Interfaces;

namespace Student.API.Repositories;

public class StudentAttendanceRepository : IStudentAttendanceRepository
{
    private readonly StudentDbContext _studentDbContext;
    public StudentAttendanceRepository(StudentDbContext studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }

    public async Task<List<StudentAttendance>> GetStudentAttendancesAsync()
    {
        return await _studentDbContext.StudentAttendances.ToListAsync();
    }

    public async Task<StudentAttendance> GetStudentAttendanceByIdAsync(Guid studentId, Guid topicId)
    {
        var studentAttendance = await _studentDbContext.StudentAttendances.FirstOrDefaultAsync(s => s.TopicId == topicId && s.StudentId == studentId);
        if (studentAttendance == null)
        {
            throw new StudentAttendanceNotFoundException("Student Attendance not found");
        }
        return studentAttendance;
    }

    public async Task AddStudentAttendanceAsync(StudentAttendance studentAttendance)
    {
        _studentDbContext.StudentAttendances.Add(studentAttendance);
        await _studentDbContext.SaveChangesAsync();
    }

    public async Task UpdateStudentAttendanceAsync(StudentAttendance studentAttendance)
    {
        try
        {
            _studentDbContext.StudentAttendances.Update(studentAttendance);
            await _studentDbContext.SaveChangesAsync();
        }
        catch 
        {
            throw new UpdateStudentAttendanceValidationInValidException("Update repository exception!");
        }
    }

    public async Task DeleteStudentAttendanceAsync(Guid studentId, Guid topicId)
    {
        var studentAttendance = await _studentDbContext.StudentAttendances.FirstOrDefaultAsync(s => s.TopicId == topicId && s.StudentId == studentId);

        if (studentAttendance is null)
            throw new StudentAttendanceNotFoundException("Student Attendance not found");
        

        _studentDbContext.StudentAttendances.Remove(studentAttendance);
        await _studentDbContext.SaveChangesAsync();
    }

}
