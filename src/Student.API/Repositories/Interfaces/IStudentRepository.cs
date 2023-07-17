namespace Student.API.Repositories.Interfaces;
using Student = Entities.Student;
 public interface IStudentRepository
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task AddStudentAsync(Student student);
        public Task UpdateStudentAsync(Student student);
        public Task DeleteStudentAsync(Student student);
        public Task<Student> GetStudentByIdAsync(Guid studentId);
        public Task<Student> GetStudentByUserNameAsync(string username);
 }

