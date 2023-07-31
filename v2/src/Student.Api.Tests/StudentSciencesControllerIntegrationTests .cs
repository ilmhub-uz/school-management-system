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
}