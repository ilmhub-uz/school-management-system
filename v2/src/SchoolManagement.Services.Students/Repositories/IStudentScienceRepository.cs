using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public interface IStudentScienceRepository
{
    public Task<StudentScience> CreateStudentScienceAsync(StudentScience studentScience);
    public Task<StudentScience?> GetStudentScienceAsync(Guid studentId, Guid scienceId);
    public Task<StudentScience> UpdateStudentScienceAsync(StudentScience studentScience);
    public Task<bool> DeleteStudentScienceAsync(StudentScience studentScience);
    public Task<List<StudentScience>?> GetStudentSciencesByStudentIdAsync(Guid studentId);
}