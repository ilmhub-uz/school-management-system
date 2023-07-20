using SchoolManagement.Common.Interfaces;
using Student.API.Entities;
using Student.API.HelperEntities.PaginationEntities;
using Student.API.Managers.Interfaces;
using Student.API.Models.StudentModels;
using Student.API.Repositories.Interfaces;

namespace Student.API.Managers;

public class StudentManager : IStudentManager
{
    private const string ImageFolderName = "StudentImages";

    private readonly IStudentRepository _studentRepository;
    private readonly IFileManager _fileManager;

    public StudentManager(IStudentRepository studentRepository, IFileManager fileManager)
    {
        _studentRepository = studentRepository;
        _fileManager = fileManager;
    }

    public async Task<StudentModel> CreateStudentAsync(CreateStudentModel model)
    {
        var student = new Entities.Student
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            MiddleName = model.MiddleName,
            PhoneNumber = model.PhoneNumber,
            Username = model.Username,
            Status = Status.Created,
        };

        if (model.StudentImage != null)
            student.PhotoUrl = await _fileManager.SaveFileAsync(model.StudentImage, ImageFolderName);

        await _studentRepository.AddStudentAsync(student);

        return MapToStudentModel(student);
    }


    public async Task<List<StudentModel>> GetStudentsAsync(StudentFilterPagination pageFilter)
    {
        var students = await _studentRepository.GetStudentsAsync(pageFilter);

        return students.Select(MapToStudentModel).ToList();
    }


    public async Task<StudentModel> GetStudentByIdAsync(Guid studentId)
    {
        var student = await _studentRepository.GetStudentByIdAsync(studentId);
        return MapToStudentModel(student);
    }

    public async Task<StudentModel> GetStudentByUserNameAsync(string username)
    {
        var student = await _studentRepository.GetStudentByUserNameAsync(username);
        return MapToStudentModel(student);
    }

    public async Task UpdateStudentAsync(Guid studentId, UpdateStudentModel model)
    {
        var student = await _studentRepository.GetStudentByIdAsync(studentId);

        student.FirstName = model.FirstName ?? student.FirstName;
        student.LastName = model.LastName ?? student.LastName;
        student.MiddleName = model.MiddleName ?? student.MiddleName;
        student.Username = model.Username ?? student.Username;
        student.PhoneNumber = model.PhoneNumber ?? student.PhoneNumber;
        student.UpdatedAt = DateTime.UtcNow;

        if (model.StudentImage is not null)
        {
            if (student.PhotoUrl is not null)
                _fileManager.DeleteFile(student.PhotoUrl);

            student.PhotoUrl = await _fileManager.SaveFileAsync(model.StudentImage, ImageFolderName);
        }

        await _studentRepository.UpdateStudentAsync(student);
    }

    public async Task DeleteStudentAsync(Guid studentId)
    {
        await _studentRepository.DeleteStudentAsync(studentId);
    }

    private StudentModel MapToStudentModel(Entities.Student student)
    {
        return new StudentModel
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            MiddleName = student.MiddleName,
            PhoneNumber = student.PhoneNumber,
            Username = student.Username,
            PhotoUrl = student.PhotoUrl,
            CreatedAt = student.CreatedAt,
            UpdatedAt = student.UpdatedAt,
            StudentSciences = student.StudentSciences,
            TasksResults = student.TasksResults,
        };
    }

}