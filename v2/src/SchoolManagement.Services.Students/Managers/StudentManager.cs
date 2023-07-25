using System.Data;
using Mapster;
using SchoolManagement.Services.Students.Entities;
using SchoolManagement.Services.Students.Exceptions;
using SchoolManagement.Services.Students.Models.StudentModels;
using SchoolManagement.Services.Students.Repositories;

namespace SchoolManagement.Services.Students.Managers;

public class StudentManager : IStudentManager
{
	private readonly IUnitOfWork _unitOfWork;

	public StudentManager(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async ValueTask<IEnumerable<StudentModel>> GetStudentsAsync()
	{
		var students = await _unitOfWork.Students.GetAllEntitiesAsync();
        return students.Select(e => e.Adapt<StudentModel>());
	}

    public async ValueTask<StudentModel> GetByIdAsync(Guid studentId)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(studentId);
        return student is null ? throw new StudentNotFoundException() : student.Adapt<StudentModel>();
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

    public async ValueTask UpdateAsync(Guid studentId, UpdateStudentModel model)
    {
        var student =  await _unitOfWork.Students.GetByIdAsync(studentId);

        if (student is null)
            throw new StudentNotFoundException();

        if (model.Photo is not null)
            student.PhotoUrl = model.Photo.ToString();

		student.FirstName = model.FirstName ?? student.FirstName;
		student.LastName = model.LastName ?? student.LastName;
		student.MiddleName = model.MiddleName ?? student.MiddleName;
		student.PhoneNumber = model.PhoneNumber ?? student.PhoneNumber;
		student.Username = model.Username ?? student.Username;

        await _unitOfWork.Students.UpdateAsync(student);
    }

    public async ValueTask DeleteAsync(Guid studentId)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(studentId);

        if (student is null)
            throw new StudentNotFoundException();

        await _unitOfWork.Students.DeleteAsync(student);
    }
}