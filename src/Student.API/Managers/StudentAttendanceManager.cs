using Student.API.Entities;
using Student.API.Managers.Interfaces;
using Student.API.Models.StudentAttendanceModels;
using Student.API.Repositories.Interfaces;

namespace Student.API.Managers;

public class StudentAttendanceManager : IStudentAttendanceManager
{
    private readonly IStudentAttendanceRepository _studentAttendanceRepos;
    public StudentAttendanceManager(IStudentAttendanceRepository studentAttendanceRepos)
    {
        _studentAttendanceRepos = studentAttendanceRepos;
    }

    public async Task<List<StudentAttendanceModel>> GetStudentAttendancesAsync()
    {
        var studentAttendances = await _studentAttendanceRepos.GetStudentAttendancesAsync();

        return studentAttendances.Select(MapToStudentAttendanceModel).ToList();
    }

    public async Task<StudentAttendanceModel> GetStudentAttendanceByIdAsync(Guid studentId, Guid topicId)
    {
        var studentAttendance = await _studentAttendanceRepos.GetStudentAttendanceByIdAsync(studentId, topicId);
        return MapToStudentAttendanceModel(studentAttendance);
    }

    public async Task<StudentAttendanceModel> AddStudentAttendanceAsync(Guid studentId, Guid topicId)
    {
        var studentAttendance = new StudentAttendance()
        {
            StudentId = studentId,
            TopicId = topicId,
            Attend = true
        };

        await _studentAttendanceRepos.AddStudentAttendanceAsync(studentAttendance);

        return MapToStudentAttendanceModel(studentAttendance);
    }

    public async Task<StudentAttendanceModel> UpdateStudentAttendanceAsync(Guid studentId, UpdateStudentAttendanceModel model)
    {
        var studentAttendance = await _studentAttendanceRepos.GetStudentAttendanceByIdAsync(studentId, model.TopicId);

        studentAttendance.Attend = model.Attend ?? studentAttendance.Attend;

        await _studentAttendanceRepos.UpdateStudentAttendanceAsync(studentAttendance);

        return MapToStudentAttendanceModel(studentAttendance);
    }

    public async Task DeleteStudentAttendancesAsync(Guid studentId, Guid topicId)
    {
        await _studentAttendanceRepos.DeleteStudentAttendanceAsync(studentId, topicId);
    }

    private StudentAttendanceModel MapToStudentAttendanceModel(StudentAttendance studentAttendance)
    {
        StudentAttendanceModel studentAttendanceModel = new StudentAttendanceModel()
        {
            StudentId = studentAttendance.StudentId,
            TopicId = studentAttendance.TopicId,
            Attend = studentAttendance.Attend,
        };
        return studentAttendanceModel;
    }
}
