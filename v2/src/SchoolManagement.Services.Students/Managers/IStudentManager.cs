using SchoolManagement.Services.Students.Helpers.PaginationEntities;
using SchoolManagement.Services.Students.Models.StudentModels;

namespace SchoolManagement.Services.Students.Managers;

public interface IStudentManager
{
    ValueTask<IEnumerable<StudentModel>> GetStudentsAsync(StudentFilter studentFilter);
    ValueTask<StudentModel> GetByIdAsync(Guid studentId);
    ValueTask UpdateAsync(Guid studentId, UpdateStudentModel model);
    ValueTask DeleteAsync(Guid studentId);
}