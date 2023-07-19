using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Student.API.Models.StudentModels;

namespace Student.Api_xUnitTests;

public class StudentControllerTests
{
    private readonly HttpClient _httpClient;
    public StudentControllerTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task AddStudent_Test()
    {
        // Arrange
        var createStudentModel = new CreateStudentModel
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = "1234567",
            Username = "Username",
            MiddleName = "MiddleName"
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "api/students");
        request.Content = JsonContent.Create(createStudentModel);

        // Act
        var response = await _httpClient.SendAsync(request);

        // Assert

        var result = await response.Content.ReadFromJsonAsync<StudentModel>();

        Assert.NotNull(result);
      //  Assert.Equal("Username", result.Username);
      //  Assert.IsType<StudentModel>(typeof(StudentModel));
    }
}