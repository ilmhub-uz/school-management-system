using Microsoft.EntityFrameworkCore;
using Student.API.Context;
using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.Repositories.Interfaces;

namespace Student.API.Repositories;
using Student = Entities.Student;

public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext _studentDbContext;

    public StudentRepository(StudentDbContext studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _studentDbContext.Students.ToListAsync();

    }
    public async Task AddStudentAsync(Student student)
    {
        _studentDbContext.Students.Add(student);
        await _studentDbContext.SaveChangesAsync();

    }

    public async Task DeleteStudentAsync(Student student)
    {
        _studentDbContext.Students.Remove(student);
        await _studentDbContext.SaveChangesAsync();

    }

    public async Task<Student> GetStudentByIdAsync(Guid studentId)
    {
        var student = await _studentDbContext.Students.FirstOrDefaultAsync(s => s.Id == studentId);
        if (student == null)
        {
            throw new StudentNotFoundException();
        }
        return student;
    }

    public async Task<Student> GetStudentByUserNameAsync(string username)
    {
        var student = await _studentDbContext.Students.FirstOrDefaultAsync(s => s.Username == username);
        if (student == null)
        {
            throw new StudentNotFoundException();
        }
        return student;
    }

    public async Task UpdateStudentAsync(Student student)
    {
        _studentDbContext.Students.Update(student);
        await _studentDbContext.SaveChangesAsync();
    }
}
