using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public interface IUnitOfWork
{
	IStudentRepository Students { get; }
	IStudentScienceRepository StudentSciences { get; }
	IGenericRepository<StudentTaskResult> StudentTaskResults { get; }

	IStudentAttendanceRepository StudentAttendances { get; }
}