using SchoolManagement.Services.Students.Models;

namespace SchoolManagement.Services.Students.Managers;

public interface IStudentManager
{
	ValueTask<IEnumerable<StudentModel>> GetStudents();
	ValueTask<StudentModel> CreateAsync(CreateStudentModel model);
}