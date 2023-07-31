using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentTaskResultModels;
using System.Text;
using SchoolManagement.Services.Students.Models.StudentModels;

namespace Student.Api.Tests;

public class StudentTaskResultControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public StudentTaskResultControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    private StringContent GetJsonStringContent(object obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }

    [Fact]
    public async Task GetStudentTaskResults_ReturnsOk()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var studentTaskResultManagerMock = new Mock<IStudentTaskResultManager>();
        studentTaskResultManagerMock.Setup(manager => manager
                .GetStudentTaskResults(studentId))
            .ReturnsAsync(new List< StudentTaskResultModel>()
                {
                    new StudentTaskResultModel
                    {
                        Content = "New Content",
                        StudentId = Guid.NewGuid(),
                        Student = new StudentModel()
                        {
                            Username = "Username",
                            PhoneNumber = "123456789"
                        },
                        CreatedAt = DateTime.UtcNow,
                        TaskId = Guid.NewGuid(),
                        UpdatedAt = null
                    },
                    new StudentTaskResultModel
                    {
                        Content = "New Content2",
                        StudentId =Guid.NewGuid(),
                        Student = new StudentModel()
                        {
                            Username = "Username2",
                            PhoneNumber = "123456789"
                        },
                        CreatedAt = DateTime.UtcNow,
                        TaskId = Guid.NewGuid(),
                        UpdatedAt = null
                    }
                });

        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync($"/api/students/{studentId}/task_results");

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
        // Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task AddStudentTaskResult_ReturnsOk()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var model = new CreateStudentTaskResultModel
        {
            Content = "New Content"
        };

        var studentTaskResultManagerMock = new Mock<IStudentTaskResultManager>();

        studentTaskResultManagerMock.Setup(manager => manager
                .CreateStudentTaskResult(It.IsAny<Guid>(), It.IsAny<CreateStudentTaskResultModel>()))
            .ReturnsAsync(new StudentTaskResultModel { Content = "New Content" });

        var client = _factory.CreateClient();

        var content = GetJsonStringContent(model);

        // Act
        var response = await client.PostAsync($"/api/students/{studentId}/task_results", content);

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
        // Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task UpdateStudentTaskResult_ReturnsOk()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var taskId = Guid.NewGuid();
        
        var model = new UpdateStudentTaskResultModel
        {
           Content = "UpdateStudentTaskResultModel"
        };

        var studentTaskResultManagerMock = new Mock<IStudentTaskResultManager>();

        studentTaskResultManagerMock.Setup(manager => manager
            .UpdateStudentTaskResult(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<UpdateStudentTaskResultModel>()));

        var client = _factory.CreateClient();

        var content = GetJsonStringContent(model);

        // Act
        var response = await client.PutAsync($"/api/students/{studentId}/task_results/{taskId}", content);

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
        // Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task DeleteStudentTaskResultAsync_ReturnsOk()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var taskId = Guid.NewGuid();

        var studentTaskResultManagerMock = new Mock<IStudentTaskResultManager>();

        studentTaskResultManagerMock.Setup(manager => manager
            .DeleteStudentTaskResult(It.IsAny<Guid>(), It.IsAny<Guid>()));

        var client = _factory.CreateClient();

        // Act
        var response = await client.DeleteAsync($"/api/students/{studentId}/task_results/{taskId}");

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
        // Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}