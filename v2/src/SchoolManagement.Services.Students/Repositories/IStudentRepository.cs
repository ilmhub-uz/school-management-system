using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;
using SchoolManagement.Services.Students.Helpers.PaginationEntities;

namespace SchoolManagement.Services.Students.Repositories;

public interface IStudentRepository : IGenericRepository<Student, StudentsDbContext, Guid>
{
    ValueTask<IEnumerable<Student>> GetAllWithFilterAsync(StudentFilter filter);
}