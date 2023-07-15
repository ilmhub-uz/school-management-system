namespace Student.API.Repositories.Interfaces;
using Student = Entities.Student;
 public interface IStudentRepository
    {
        public Task<List<Student>> GetStudents();
        public Task AddStudent(Student student);
        public Task UpdateStudent(Student student);
        public Task DeleteStudent(Student student);
        public Task<Student> GetStudentById(Guid studentId);
        public Task<Student> GetStudentByUserName(string username);
 }

