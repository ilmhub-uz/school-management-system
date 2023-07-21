using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public class StudentRepository : GenericRepository<Student, StudentsDbContext, Guid>, IStudentRepository
{
	public StudentRepository(StudentsDbContext dbContext) : base(dbContext)
	{
	}
}