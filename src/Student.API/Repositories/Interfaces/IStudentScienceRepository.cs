using Student.API.Entities;

namespace Student.API.Repositories.Interfaces
{
    public interface IStudentScienceRepository
    {
        Task<List<StudentScience>> GetStudentSciencesAsync();
        Task AddStudentScienceAsync(StudentScience science);
        Task<StudentScience> GetStudentScienceByScienceIdAsync(StudentScience science);
        Task UpdateStudentScienceByScienceIdAsync(StudentScience science);
        Task DeleteStudentScienceByScienceIdAsync(StudentScience science);

    }
}
