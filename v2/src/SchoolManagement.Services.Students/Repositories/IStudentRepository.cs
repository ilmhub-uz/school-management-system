using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public interface IStudentRepository : IGenericRepository<Student, StudentsDbContext, Guid>
{
	
}