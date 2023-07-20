using Microsoft.EntityFrameworkCore;
using Student.API.Context;
using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.Repositories.Interfaces;

namespace Student.API.Repositories
{
    public class StudentScienceRepository : IStudentScienceRepository
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentScienceRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public async Task<List<StudentScience>> GetStudentSciencesAsync()
        {
            return await _studentDbContext.StudentSciences.ToListAsync();
        }
        public async Task AddStudentScienceAsync(StudentScience science)
        {
            _studentDbContext.StudentSciences.Add(science);
            await _studentDbContext.SaveChangesAsync();
        }

        public async Task<StudentScience> GetStudentScienceByScienceIdAsync(Guid scienceId, Guid studentId)
        {
            var studentScience = await _studentDbContext.StudentSciences.FirstOrDefaultAsync(s => s.ScienceId == scienceId && s.StudentId == studentId);
            if (studentScience == null)
            {
                throw new StudentScienceNotFoundException();
            }
            return studentScience;

        }

        public async Task UpdateStudentScienceAsync(StudentScience studentScience)
        {
            _studentDbContext.StudentSciences.Update(studentScience);
            await _studentDbContext.SaveChangesAsync();
        }
    }
}
