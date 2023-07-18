using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.FluentValidators;
using Student.API.Models.StudentAttendanceModels;

namespace Student.API.Managers.Interfaces
{
    public interface IStudentAttendanceManager
    {
        Task<List<StudentAttendanceModel>> GetStudentAttendancesAsync();
        Task<StudentAttendanceModel> AddStudentAttendanceAsync(Guid studentId);
        Task<StudentAttendanceModel> UpdateStudentAttendanceAsync(Guid studentId, Guid topicId, UpdateStudentAttendanceModel model);
        
    }
}
