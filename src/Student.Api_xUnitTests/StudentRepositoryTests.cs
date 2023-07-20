using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Student.API.Context;
using Student.API.HelperEntities.PaginationEntities;
using Student.API.Repositories;
using Student.API.Repositories.Interfaces;

namespace Student.Api_xUnitTests;


public class StudentRepositoryTests
{
    private readonly StudentDbContext _studentDbContext;
    private readonly IStudentRepository _studentRepository;

    public StudentRepositoryTests()
    {
        var dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>();
        dbContextOptions.UseInMemoryDatabase("student_test_db");

        _studentDbContext = new StudentDbContext(dbContextOptions.Options);

        IHttpContextAccessor contextAccessor = new HttpContextAccessor();
        var contextHelper = new HttpContextHelper(contextAccessor);

        _studentRepository = new StudentRepository(_studentDbContext, contextHelper);
    }

    [Fact]
    public async Task GetStudentsAsync_ReturnsNonNullStudents()
    {
        // Arrange
        var pageFilter = new StudentFilterPagination();

        // Act
        var students = await _studentRepository.GetStudentsAsync(pageFilter);

        // Assert
        Assert.NotNull(students);
    }

    [Fact]
    public async Task AddStudentAsync_AddsNewStudent()
    {
        // Arrange
        var student = new API.Entities.Student
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "12345678910",
            Username = "Username",
            MiddleName = "MiddleName"
        };

        // Act
        await _studentRepository.AddStudentAsync(student);

        // Assert
        Assert.True(student.Id != Guid.Empty);
    }

    [Fact]
    public async Task DeleteStudentAsync_DeletesExistingStudent()
    {
        // Arrange
        var studentId = Guid.NewGuid();

        var student = new API.Entities.Student
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "12345678910",
            Username = "Username",
            MiddleName = "MiddleName"
        };
        _studentDbContext.Students.Add(student);
        await _studentDbContext.SaveChangesAsync();

        // Act
        await _studentRepository.DeleteStudentAsync(studentId);

        // Assert
        var deletedStudent = await _studentDbContext.Students.FirstOrDefaultAsync(s => s.Id == studentId);
        Assert.Null(deletedStudent);
    }

    [Fact]
    public async Task GetStudentByIdAsync_ReturnsExistingStudent()
    {
        // Arrange
        var studentId = Guid.NewGuid();

        var student = new API.Entities.Student
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "12345678910",
            Username = "Username",
            MiddleName = "MiddleName"
        };

        _studentDbContext.Students.Add(student);
        await _studentDbContext.SaveChangesAsync();

        // Act
        var result = await _studentRepository.GetStudentByIdAsync(studentId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(studentId, result.Id);
    }

    [Fact]
    public async Task GetStudentByUserNameAsync_ReturnsExistingStudent()
    {
        // Arrange
        var username = "Username";

        var student = new API.Entities.Student
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "12345678910",
            Username = username,
            MiddleName = "MiddleName"
        };

        _studentDbContext.Students.Add(student);
        await _studentDbContext.SaveChangesAsync();

        // Act
        var result = await _studentRepository.GetStudentByUserNameAsync(username);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(username, result.Username);
    }

    [Fact]
    public async Task UpdateStudentAsync_UpdatesExistingStudent()
    {
        // Arrange
        var studentId = Guid.NewGuid();

        var student = new API.Entities.Student
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "12345678910",
            Username = "Username",
            MiddleName = "MiddleName"
        };

        _studentDbContext.Students.Add(student);
        await _studentDbContext.SaveChangesAsync();


        student.FirstName = "UpdatedFirstName";
        student.LastName = "UpdatedLastName";

        // Act
        await _studentRepository.UpdateStudentAsync(student);

        // Assert
        var updatedStudent = await _studentDbContext.Students
            .FirstOrDefaultAsync(s => s.Id == studentId);

        Assert.NotNull(updatedStudent);
        Assert.Equal("UpdatedFirstName", updatedStudent.FirstName);
        Assert.Equal("UpdatedLastName", updatedStudent.LastName);
    }
}

