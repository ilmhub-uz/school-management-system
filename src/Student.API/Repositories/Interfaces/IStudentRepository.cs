namespace Student.API.Repositories.Interfaces;

using HelperEntities.PaginationEntities;
using Student = Entities.Student;


 public interface IStudentRepository
 {
     Task<IEnumerable<Student>> GetStudentsAsync(StudentFilterPagination pageFilter);
     public Task AddStudentAsync(Student student);
     public Task UpdateStudentAsync(Student student);
     public Task DeleteStudentAsync(Guid studentId);
     public Task<Student> GetStudentByIdAsync(Guid studentId);
     public Task<Student> GetStudentByUserNameAsync(string username);
 }

