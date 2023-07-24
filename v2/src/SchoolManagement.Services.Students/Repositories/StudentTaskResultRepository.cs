using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public class StudentTaskResultRepository : IStudentTaskResultRepository
{
    private readonly StudentsDbContext _context;
    public StudentTaskResultRepository(StudentsDbContext context)
    {
        _context = context;
    }
    public async ValueTask<StudentTaskResult> CreateTaskResultAsync(StudentTaskResult studentTaskResult)
    {
        _context.StudentTaskResults.Add(studentTaskResult);
        await _context.SaveChangesAsync();

        return studentTaskResult;

    }

    public async ValueTask DeleteTaskResultAsync(StudentTaskResult studentTaskResult)
    {
        _context.StudentTaskResults.Remove(studentTaskResult);
        await _context.SaveChangesAsync();

    }

    public async ValueTask<StudentTaskResult?> GetTaskResultByTaskIdAsync(Guid studentId, Guid taskId)
    {
        return await _context.StudentTaskResults.Where(t => t.StudentId == studentId && t.TaskId == taskId).FirstOrDefaultAsync();
    }

    public async ValueTask<IEnumerable<StudentTaskResult>> GetTaskResultsAsync(Guid studentId)
    {
        return await _context.StudentTaskResults.Where(t => t.StudentId == studentId).ToListAsync();
    }

    public async ValueTask UpdateTaskResultAsync(StudentTaskResult studentTaskResult)
    {
        _context.StudentTaskResults.Remove(studentTaskResult);
        await _context.SaveChangesAsync();

    }
}