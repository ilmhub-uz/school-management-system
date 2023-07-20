using Mapster;
using SchoolManagement.Services.Students.Entities;
using SchoolManagement.Services.Students.Models;
using SchoolManagement.Services.Students.Repositories;

namespace SchoolManagement.Services.Students.Managers;

public class StudentManager : IStudentManager
{
	private readonly IUnitOfWork _unitOfWork;

	public StudentManager(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async ValueTask<IEnumerable<StudentModel>> GetStudents()
	{
		var students = await _unitOfWork.Students.Get();

		return students.Select(e => e.Adapt<StudentModel>());
	}

	public async ValueTask<StudentModel> CreateAsync(CreateStudentModel model)
	{
		var student = new Student()
		{
			FirstName = model.FirstName,
			LastName = model.LastName,
			MiddleName = model.MiddleName,
			PhoneNumber = model.PhoneNumber,
			Username = model.Username
		};

		await _unitOfWork.Students.CreateAsync(student);

		return student.Adapt<StudentModel>();
	}
}