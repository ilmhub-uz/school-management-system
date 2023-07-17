using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.FluentValidators;
using Student.API.Models.StudentAttendanceModels;
using Student.API.Repositories;

namespace Student.API.Managers;

public class StudentAttendanceManager
{
    private readonly StudentAttendanceRepository _studentAttendanceRepos;
    public StudentAttendanceManager(StudentAttendanceRepository studentAttendanceRepos)
    {
        _studentAttendanceRepos = studentAttendanceRepos;
    }

    public async Task<List<StudentAttendanceModel>> GetStudentAttendances()
    {
        var studentAttendances = await _studentAttendanceRepos.GetStudentAttendanceAsync();

        return ToStudentAttendanceModels(studentAttendances);
    }
    public async Task<StudentAttendanceModel> AddStudentAttendance(AddStudentAttendanceModel model)
    {
        var validator = new AddStudentAttendanceValidator();
        var result = validator.Validate(model);
        if (!result.IsValid)
        {
            throw new AddStudentAttendanceValiadtionIsNotValid("Invalid input try again");
        }
        var studentAttendance = new StudentAttendance()
        {
            StudentId = model.StudentId,
            TopicId = model.TopicId,
            Attend = true
        };

        await _studentAttendanceRepos.AddStudentAttendanceAsync(studentAttendance);

        return ToStudentAttendanceModel(studentAttendance);

    }

    public async Task<StudentAttendanceModel> UpdateStudentAttendance(UpdateStudentAttendanceModel model)
    {
        var validator = new UpdateStudentAttendanceValidator();
        var result = validator.Validate(model);
        if (!result.IsValid)
        {
            throw new UpdateStudentAttendanceValidationInValid("Invalid update input try again");
        }
        var studentAttendance = await _studentAttendanceRepos.GetStudentAttendanceAsync(model.StudentId, model.TopicId);

        studentAttendance.Attend = model.Attend;

        await _studentAttendanceRepos.UpdateStudentAttendanceAsync(studentAttendance);

        return ToStudentAttendanceModel(studentAttendance);
    }

    private StudentAttendanceModel ToStudentAttendanceModel(StudentAttendance? studentAttendance)
    {
        StudentAttendanceModel studentAttendanceModel = new StudentAttendanceModel()
        {
            StudentId = studentAttendance.StudentId,
            TopicId = studentAttendance.TopicId,
            Attend = studentAttendance.Attend,
        };
        return studentAttendanceModel;
    }
    private List<StudentAttendanceModel> ToStudentAttendanceModels(List<StudentAttendance>? studentAttendances)
    {
        var studentAttendanceModels = new List<StudentAttendanceModel>();

        if(studentAttendances == null || studentAttendances.Count==0) 
        {
            return new List<StudentAttendanceModel>();
        }

        foreach(var studentAttendance in studentAttendances)
        {
            studentAttendanceModels.Add(ToStudentAttendanceModel((StudentAttendance)studentAttendance));
        };
        return studentAttendanceModels;
    }
}
