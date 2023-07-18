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
        var studentScience = await _studentScienceRepos.GetStudentSciencesAsync();

        return ToStudentScienceModels(studentScience);
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
        return ToStudentScienceModel(studentScience);
    }

    public async Task<StudentScienceModel> GetStudentScienceByScienceIdAsync(Guid studentId, Guid scienceId)
    {
        var studentScience = await _studentScienceRepos.GetStudentScienceByScienceIdAsync(scienceId, studentId);

        return ToStudentScienceModel(studentScience);
    }

    public async Task UpdateStudentScienceAsync(Guid studentId, Guid scienceId, Status? status)
    {

        var studentScience = await _studentScienceRepos.GetStudentScienceByScienceIdAsync(scienceId, studentId);

        studentScience.Status = status ?? studentScience.Status;
        studentScience.UpdatedAt = DateTime.UtcNow;

        await _studentScienceRepos.UpdateStudentScienceAsync(studentScience);
    }

    private StudentScienceModel ToStudentScienceModel(StudentScience studentScience)
    {
        var model = new StudentScienceModel()
        {
            ScienceId = studentScience.ScienceId,
            StudentId = studentScience.StudentId,
            CreatedAt = studentScience.CreatedAt,
        };
        if (studentScience.Status == Status.Created)
        {
            model.UpdatedAt = null;
        }
        else
        {
            model.UpdatedAt = studentScience.UpdatedAt;
        }
        return model;
    }
    private List<StudentScienceModel> ToStudentScienceModels(List<StudentScience> studentSciences)
    {
        if (studentSciences == null || studentSciences.Count == 0)
        {
            return new List<StudentScienceModel>();
        }
        var models = new List<StudentScienceModel>();
        foreach (var studentScience in studentSciences)
        {
            models.Add(ToStudentScienceModel(studentScience));
        }
        return models;
    }

}