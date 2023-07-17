using Microsoft.EntityFrameworkCore;
using Student.API.Context;
using Student.API.Entities;
using Student.API.Repositories.Interfaces;

namespace Student.API.Repositories;

public class StudentAttendanceRepository : IStudentAttendanceRepository
{
    private readonly StudentDbContext _studentDbContext;
    public StudentAttendanceRepository(StudentDbContext studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }

    public async Task<List<StudentAttendance>> GetStudentAttendanceAsync()
    {
        return await _studentDbContext.StudentAttendances.ToListAsync();
    }

    public async Task AddStudentAttendanceAsync(StudentAttendance studentAttendance)
    {
        _studentDbContext.StudentAttendances.Add(studentAttendance);
         await _studentDbContext.SaveChangesAsync();    
    }

    public async Task UpdateStudentAttendanceAsync(StudentAttendance studentAttendance)
    {
        _studentDbContext.StudentAttendances.Update(studentAttendance);
        await _studentDbContext.SaveChangesAsync();
    }
}
