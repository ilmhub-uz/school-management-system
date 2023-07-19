using Microsoft.EntityFrameworkCore;
using Student.API.Context;
using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.Extension;
using Student.API.HelperEntities.PaginationEntities;
using Student.API.Repositories.Interfaces;

namespace Student.API.Repositories;
using Student = Entities.Student;

public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext _studentDbContext;
    private readonly HttpContextHelper _contextHelper;

    public StudentRepository(StudentDbContext studentDbContext, HttpContextHelper contextHelper)
    {
        _studentDbContext = studentDbContext;
        _contextHelper = contextHelper;
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync(StudentFilterPagination pageFilter)
    {
        return await _studentDbContext.Students
            .Where(s => s.Status != Status.Deleted)
            .ToPagedListAsync(_contextHelper, pageFilter);
    }

    public async Task AddStudentAsync(Student student)
    {
        _studentDbContext.Students.Add(student);
        await _studentDbContext.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        var student = await GetStudentByIdAsync(studentId);
        student.Status = Status.Deleted;
        await _studentDbContext.SaveChangesAsync();
    }

    public async Task<Student> GetStudentByIdAsync(Guid studentId)
    {
        var student = await _studentDbContext.Students.FirstOrDefaultAsync(
            s => s.Id == studentId && s.Status != Status.Deleted);

        return student ?? throw new StudentNotFoundException();
    }

    public async Task<Student> GetStudentByUserNameAsync(string username)
    {
        var student = await _studentDbContext.Students.FirstOrDefaultAsync(
            s => s.Username == username && s.Status != Status.Deleted);

        return student ?? throw new StudentNotFoundException();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        _studentDbContext.Students.Update(student);
        await _studentDbContext.SaveChangesAsync();
    }
}
