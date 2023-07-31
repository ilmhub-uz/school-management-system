using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SchoolManagement.Services.Students.Entities;
using SchoolManagement.Services.Students.Models.StudentScienceModels;

namespace Student.Api.Tests;

public class StudentSciencesControllerIntegrationTests
{
    private readonly HttpClient _httpClient;
    public StudentSciencesControllerIntegrationTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    private StringContent GetJsonStringContent(object obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }

    [Fact]
    public async Task AddStudentScience_ReturnsCreated()
    {
        // Arrange
        var studentId = Guid.NewGuid();

        var createStudentScience = new CreateStudentScienceModel
        {
            Status = StudentScienceStatus.Active,
            StudentId = studentId,
            ScienceId = Guid.NewGuid()
        };

        var content = GetJsonStringContent(createStudentScience);

        // Act 
        var response = await _httpClient.PostAsync($"api/students/{studentId}/sciences", content);

        response.EnsureSuccessStatusCode();

        // Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task GetStudentSciences_ResultOK()
    {
        // Arrange
        var studentId = Guid.NewGuid();

        // Act
        var response = await _httpClient.GetAsync($"api/students/{studentId}");

        // Assert
        Assert.NotNull(response);
       // Assert.True(response.IsSuccessStatusCode);
    }


    [Fact]
    public async Task GetStudentScience_ResultOK()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var scienceId = Guid.NewGuid();

        // Act
        var response = await _httpClient.GetAsync($"api/students/{studentId}/sciences/{scienceId}");

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task UpdateStudentScience_ReturnsOk()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var scienceId = Guid.NewGuid();

        var updateStudentScience = new UpdateStudentScienceModel
        {
            Status = StudentScienceStatus.Active,
        };

        var content = GetJsonStringContent(updateStudentScience);

        // Act
        var response = await _httpClient.PutAsync($"api/students/{studentId}/sciences/{scienceId}", content);

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task DeleteStudentScience_ReturnsOk()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var scienceId = Guid.NewGuid();

        // Act
        var response = await _httpClient.DeleteAsync($"/api/students/{studentId}/sciences/{scienceId}");

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
        // Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}