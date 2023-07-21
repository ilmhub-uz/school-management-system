using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public class StudentScienceRepository : IStudentScienceRepository
{
	private readonly StudentsDbContext _studentsDbContext;

	public StudentScienceRepository(StudentsDbContext studentsDbContext)
	{
		_studentsDbContext = studentsDbContext;
	}

    public async Task<StudentScience> CreateStudentScienceAsync(StudentScience studentScience)
    {
        _studentsDbContext.StudentSciences.Add(studentScience);
        await _studentsDbContext.SaveChangesAsync();
        return studentScience;
    }

    public async Task<bool> DeleteStudentScienceAsync(StudentScience studentScience)
    {
        _studentsDbContext.StudentSciences.Remove(studentScience);
        await _studentsDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<StudentScience?> GetStudentScienceAsync(Guid studentId, Guid scienceId)
    {
        var studentScience = await _studentsDbContext.StudentSciences
            .SingleOrDefaultAsync(s => s.ScienceId == scienceId && s.StudentId == studentId);

        return studentScience;
    }

    public async Task<List<StudentScience>?> GetStudentSciencesByStudentIdAsync(Guid studentId)
    {
        var studentSciences = await _studentsDbContext.StudentSciences.Where(s => s.StudentId == studentId).ToListAsync();
        return studentSciences;
    }

    public async Task<StudentScience> UpdateStudentScienceAsync(StudentScience studentScience)
    {
        _studentsDbContext.StudentSciences.Update(studentScience);
        await _studentsDbContext.SaveChangesAsync();

        return studentScience;
    }
}