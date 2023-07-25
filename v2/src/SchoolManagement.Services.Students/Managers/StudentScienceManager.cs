using Mapster;
using SchoolManagement.Services.Students.Entities;
using SchoolManagement.Services.Students.Models.StudentScienceModels;
using SchoolManagement.Services.Students.Repositories;

namespace SchoolManagement.Services.Students.Managers;

public class StudentScienceManager : IStudentScienceManager
{
    private readonly IStudentScienceRepository _studentScienceRepository;

    public StudentScienceManager(IStudentScienceRepository studentScienceRepository)
    {
        _studentScienceRepository = studentScienceRepository;
    }

    public async Task<StudentScienceModel> CreateStudentScienceAsync(CreateStudentScienceModel createStudentScience)
    {
        var studentScience = createStudentScience.Adapt<StudentScience>();

        await _studentScienceRepository.CreateStudentScienceAsync(studentScience);

        var studentScienceModel = studentScience.Adapt<StudentScienceModel>();

        return studentScienceModel;
    }

    public async Task<bool> DeleteStudentScienceAsync(Guid studentId, Guid scienceId)
    {
        var studentScience = await _studentScienceRepository.GetStudentScienceAsync(studentId, scienceId);

        if (studentScience == null)
            return false;

        var result = await _studentScienceRepository.DeleteStudentScienceAsync(studentScience);

        return result;
    }

    public async Task<StudentScienceModel?> GetStudentScienceAsync(Guid studentId, Guid scienceId)
    {
        var studentScience = await _studentScienceRepository.GetStudentScienceAsync(studentId, scienceId);

        var studentScienceModel = studentScience.Adapt<StudentScienceModel>();

        return studentScienceModel;
    }

    public async Task<List<StudentScienceModel>?> GetStudentSciencesByStudentIdAsync(Guid studentId)
    {
        var studentScience = await _studentScienceRepository.GetStudentSciencesByStudentIdAsync(studentId);
        if (studentScience == null)
            return null;

        var studentScienceModels = studentScience.Adapt<List<StudentScienceModel>>();

        return studentScienceModels;
    }

    public async Task<StudentScienceModel> UpdateStudentScienceAsync(Guid studentId, Guid scienceId, UpdateStudentScienceModel updateStudentScience)
    {
        var studentScience = await _studentScienceRepository.GetStudentScienceAsync(studentId, scienceId);
        if (studentScience == null)
            throw new Exception("StudentScience is not found");

        studentScience.Status = updateStudentScience.Status;
        await _studentScienceRepository.UpdateStudentScienceAsync(studentScience);

        var studentScienceModel = studentScience.Adapt<StudentScienceModel>();
        return studentScienceModel;
    }
}
