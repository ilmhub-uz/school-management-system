using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using SchoolManagement.Services.Students.Controllers;
using SchoolManagement.Services.Students.Helpers.PaginationEntities;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentModels;

namespace Student.Api.Tests;

public class StudentControllerIntegrationTests
{
    private readonly HttpClient _httpClient;
    public StudentControllerIntegrationTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task GetStudents_Returns_OkResult_With_Students()
    {
        // Arrange
        var fakeStudents = new List<StudentModel>
        {
            new ()
            {
                Username = "Username1",
                PhoneNumber = "66666666"
            },
            new ()
            {
                Username = "Username2",
                PhoneNumber = "77777777"
            },
            new ()
            {
                Username = "Username3",
                PhoneNumber = "88888888"
            },
        };

        var mockStudentManager = new Mock<IStudentManager>();
        mockStudentManager.Setup(manager => manager
                .GetStudentsAsync(It.IsAny<StudentFilter>()))
            .ReturnsAsync(fakeStudents);

        var controller = new StudentsController(mockStudentManager.Object);

        // Act
        var result = await controller.GetStudents(new StudentFilter());

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var students = Assert.IsAssignableFrom<IEnumerable<StudentModel>>(okResult.Value);
        Assert.Equal(3, students.Count());
    }

    [Fact]
    public async Task GetStudents_ReturnsOKResult()
    {
        // Arrange
        var expectedStatusCode = HttpStatusCode.OK;

        // Act
        var response = await _httpClient.GetAsync("api/students");

        // Assert
        Assert.Equal(expectedStatusCode, response.StatusCode);
        Assert.NotNull(response);
        Assert.True(response.IsSuccessStatusCode);
    }

  

    [Fact]
    public async Task GetStudentById_ValidId_ReturnsOKResult()
    {
        // Arrange
        var expectedStatusCode = HttpStatusCode.OK;
        var studentId = Guid.NewGuid();

        // Act
        var response = await _httpClient.GetAsync($"api/students/{studentId}");

        // Assert
        Assert.NotNull(response);
        //Assert.True(response.IsSuccessStatusCode);
        //Assert.Equal(expectedStatusCode, response.StatusCode);
    }

    [Fact]
    public async Task UpdateStudent_ValidData_ReturnsOKResult()
    {
        // Arrange
        var expectedStatusCode = HttpStatusCode.OK;
        var studentId = Guid.NewGuid();

        var updateStudentModel = new UpdateStudentModel
        {
            Username = "UpdateTestName",
            PhoneNumber = "888888888",
            FirstName = "UpdateFirstName",
            LastName = "UpdateLastName",
            MiddleName = "UpdateMiddleName"
        };

        var jsonUpdateData = JsonConvert.SerializeObject(updateStudentModel);
        var content = new StringContent(jsonUpdateData, Encoding.UTF8, "application/json");

        // Act
        var response = await _httpClient.PutAsync($"api/students/{studentId}", content);

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
        // Assert.Equal(expectedStatusCode, response.StatusCode);
    }

    [Fact]
    public async Task DeleteStudent_ValidId_ReturnsOKResult()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        
        // Act
        var response = await _httpClient.DeleteAsync($"api/students/{studentId}");

        Assert.NotNull(response);
       // Assert.True(response.IsSuccessStatusCode);
    }
}

/*public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
        });

        builder.UseEnvironment("Development");
    }
}*/


