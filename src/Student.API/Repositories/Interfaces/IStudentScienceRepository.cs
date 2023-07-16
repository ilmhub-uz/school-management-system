using Student.API.Entities;

namespace Student.API.Repositories.Interfaces
{
    public interface IStudentScienceRepository
    {
        Task<List<StudentScience>> GetStudentSciencesAsync(string studentUsername);
        Task AddStudentScienceAsync(string studentUsername, StudentScience science);
        Task GetStudentScienceByScienceIdASync(string studentUsername,int scienceId);
        Task UpdateStudentScienceByScienceIdASync(string studentUsername, int scienceId);
        Task DeleteStudentScienceByScienceIdAsync(string studentUsername, int scienceId);





    }
}
