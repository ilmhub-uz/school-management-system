using Student.API.HelperEntities.PaginationEntities;
using Student.API.Models.StudentModels;

namespace Student.API.Managers.Interfaces;

public interface IStudentManager
{
    Task<StudentModel> CreateStudentAsync(CreateStudentModel model);
    Task<List<StudentModel>> GetStudentsAsync(StudentFilterPagination pageFilter);
    Task<StudentModel> GetStudentByIdAsync(Guid studentId);
    Task<StudentModel> GetStudentByUserNameAsync(string username);
    Task UpdateStudentAsync(Guid studentId, UpdateStudentModel model);
    Task DeleteStudentAsync(Guid studentId);
}