using SchoolManagement.Services.Students.Models.StudentModels;

namespace SchoolManagement.Services.Students.Managers;

public interface IStudentManager
{
	ValueTask<IEnumerable<StudentModel>> GetStudentsAsync();
    ValueTask<StudentModel> GetByIdAsync(Guid studentId);
    ValueTask<StudentModel> CreateAsync(CreateStudentModel model);
    ValueTask UpdateAsync(Guid studentId, UpdateStudentModel model);
    ValueTask DeleteAsync(Guid studentId);
}