using Student.API.Entities;

namespace Student.API.Repositories.Interfaces
{
    public interface IStudentScienceRepository
    {
        public Task<List<StudentScience>> GetStudentSciences(string studentUsername);
        public Task AddStudentScience(string studentUsername, StudentScience science);
        public Task GetStudentScienceByScienceId(string studentUsername,int scienceId);
        public Task UpdateStudentScienceByScienceId(string studentUsername, int scienceId);
        public Task DeleteStudentScienceByScienceId(string studentUsername, int scienceId);





    }
}
