using Mapster;
using SchoolManagement.Services.Students.Entities;
using SchoolManagement.Services.Students.Models.StudentAttendanceModels;
using SchoolManagement.Services.Students.Repositories;

namespace SchoolManagement.Services.Students.Managers;

public class StudentAttendanceManager : IStudentAttendanceManager
{
    private readonly IStudentAttendanceRepository _repos;
    public StudentAttendanceManager(IStudentAttendanceRepository repos)
    {
        _repos = repos;
    }
    public async Task<StudentAttendanceModel> AddStudentAtttendance(Guid studentId, CreateStudentAttendanceModel model)
    {
        var studentAttendance = new StudentAttendance()
        {
            StudentId = studentId,
            TopicId = Guid.NewGuid(),
            Attend = model.Attend,
        };
        await _repos.AddStudentAttendance(studentAttendance);
        return studentAttendance.Adapt<StudentAttendanceModel>();
    }

    public async Task<List<StudentAttendanceModel>> GetStudentAttendances(Guid studentId)
    {
       var studentAttendances = await _repos.GetAttendances(studentId);
        return studentAttendances.Adapt<List<StudentAttendanceModel>>();
    }

    public async Task UpdateStudentAttendance(Guid studentId,Guid topicId, UpdateStudentAttendanceModel model)
    {
        var studentAttendance = await _repos.GetAttendance(studentId, topicId);
        studentAttendance.Attend = model.Attend;
        await _repos.UpdateStudentAttendance(studentAttendance);
    }
}
