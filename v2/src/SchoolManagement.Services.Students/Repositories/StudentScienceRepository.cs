using SchoolManagement.Services.Students.Context;

namespace SchoolManagement.Services.Students.Repositories;

public class StudentScienceRepository : IStudentScienceRepository
{
	private readonly StudentsDbContext _studentsDbContext;

	public StudentScienceRepository(StudentsDbContext studentsDbContext)
	{
		_studentsDbContext = studentsDbContext;
	}
}