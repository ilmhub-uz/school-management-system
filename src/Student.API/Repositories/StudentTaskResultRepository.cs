using Microsoft.EntityFrameworkCore;
using Student.API.Context;
using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.Repositories.Interfaces;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Student.API.Repositories;

public class StudentTaskResultRepository : IStudentTaskResultRepository
{
    private readonly StudentDbContext _studentDbContext;
    public StudentTaskResultRepository(StudentDbContext studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }
    public async Task<List<StudentTaskResult>> GetTaskResultsAsync()
    {
        return await _studentDbContext.TaskResults.ToListAsync();  
    }

    public async Task AddTaskResultAsync(StudentTaskResult result)
    {
        _studentDbContext.TaskResults.Add(result);
        await _studentDbContext.SaveChangesAsync();
    }

    public async Task DeleteTaskResultAsync(StudentTaskResult result)
    {
        _studentDbContext.TaskResults.Remove(result);
        await _studentDbContext.SaveChangesAsync();
    }

    public async Task<StudentTaskResult> GetTaskResultAsync(Guid taskId, Guid studentId)
    {
        var result = await _studentDbContext.TaskResults.FirstOrDefaultAsync(r => r.TaskId == taskId && r.StudentId == studentId);
        if(result == null)
        {
            throw new StudentTaskResultNotFoundException();
        }

        return result;
    }


    public async Task UpdateTaskResultAsync(StudentTaskResult result)
    {
         _studentDbContext.TaskResults.Update(result);
         await _studentDbContext.SaveChangesAsync();
    }
}
