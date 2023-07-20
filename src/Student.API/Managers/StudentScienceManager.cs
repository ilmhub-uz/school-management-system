using Student.API.Entities;
using Student.API.Managers.Interfaces;
using Student.API.Models.StudentScienceModels;
using Student.API.Repositories.Interfaces;

namespace Student.API.Managers;

public class StudentScienceManager : IStudentScienceManager
{
    private readonly IStudentScienceRepository _studentScienceRepos;
    public StudentScienceManager(IStudentScienceRepository studentScienceRepos)
    {
        _studentScienceRepos = studentScienceRepos;
    }

    public async Task<List<StudentScienceModel>> GetStudentSciencesAsync()
    {
        var studentSciences = await _studentScienceRepos.GetStudentSciencesAsync();

        return studentSciences.Select(MapToStudentScienceModel).ToList();
    }

    public async Task<StudentScienceModel> AddStudentScienceAsync(Guid studentId, Guid scienceId)
    {

        var studentScience = new StudentScience()
        {
            ScienceId = scienceId,
            StudentId = studentId,
            CreatedAt = DateTime.UtcNow
        };
        await _studentScienceRepos.AddStudentScienceAsync(studentScience);
        return MapToStudentScienceModel(studentScience);
    }

    public async Task<StudentScienceModel> GetStudentScienceByScienceIdAsync(Guid studentId, Guid scienceId)
    {
        var studentScience = await _studentScienceRepos.GetStudentScienceByScienceIdAsync(scienceId, studentId);

        return MapToStudentScienceModel(studentScience);
    }

    public async Task UpdateStudentScienceAsync(Guid studentId, Guid scienceId, Status? status)
    {

        var studentScience = await _studentScienceRepos.GetStudentScienceByScienceIdAsync(scienceId, studentId);

        studentScience.Status = status ?? studentScience.Status;
        studentScience.UpdatedAt = DateTime.UtcNow;

        await _studentScienceRepos.UpdateStudentScienceAsync(studentScience);
    }

    private StudentScienceModel MapToStudentScienceModel(StudentScience studentScience)
    {
        return new StudentScienceModel()
        {
            ScienceId = studentScience.ScienceId,
            StudentId = studentScience.StudentId,
            CreatedAt = studentScience.CreatedAt,
            UpdatedAt = studentScience.UpdatedAt,
            Status = studentScience.Status
        };
    }
}