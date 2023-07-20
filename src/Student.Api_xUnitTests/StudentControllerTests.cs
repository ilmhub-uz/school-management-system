using Microsoft.AspNetCore.Mvc.Testing;
using Student.API.HelperEntities.PaginationEntities;
using Student.API.Models.StudentModels;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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
    public async Task GetStudents_Test()
    {
        // Arrange
        var studentFilter = new StudentFilterPagination();

        var request = new HttpRequestMessage(HttpMethod.Get, "api/students");
        request.Content = JsonContent.Create(studentFilter);

        // Act
        var response = await _httpClient.SendAsync(request);

        // Assert

        Assert.True(response.IsSuccessStatusCode);
        Assert.NotNull(response);

        var result = await response.Content.ReadAsStringAsync();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task AddStudent_Test()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Post, "api/students");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent("ali"), "Username");
        content.Add(new StringContent("131313"), "PhoneNumber");
        request.Content = content;

        // Act
		var response = await _httpClient.SendAsync(request);

        // Assert

        Assert.True(response.IsSuccessStatusCode);

        StudentModel? studentModel = await response.Content.ReadFromJsonAsync<StudentModel>();

        Assert.NotNull(studentModel);
        Assert.Equal("Username", studentModel.Username);
        //  Assert.IsType<StudentModel>(typeof(StudentModel));
    }


    [Fact]
    public async Task UpdateStudent_Test()
    {
        // Arrange
        Guid studentId = Guid.Parse("051e3b12-31bb-414a-8afc-d9030386b163");
        var updateStudentModel = new UpdateStudentModel
        {
            Username = "Hello",
            PhoneNumber = "123456789"
        };

        var request = new HttpRequestMessage(HttpMethod.Put, $"api/students/{studentId}");
        request.Content = JsonContent.Create(updateStudentModel);

        // Act
		var response = await _httpClient.SendAsync(request);
        //var response = await _httpClient.PutAsJsonAsync($"api/students/{studentId}", updateStudentModel);


		// Assert

		Assert.NotNull(response);
        Assert.True(response.IsSuccessStatusCode);

        StudentModel? studentModel = await response.Content.ReadFromJsonAsync<StudentModel>();

        Assert.NotNull(studentModel);
    }

    [Fact]
    public async Task GetStudentById_Test()
    {
        // Arrange
        Guid studentId = Guid.Parse("051e3b12-31bb-414a-8afc-d9030386b163");

        var request = new HttpRequestMessage(HttpMethod.Get, $"api/students/{studentId}");

        //Act
        var response = await _httpClient.SendAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task GetStudentByUsername_Test()
    {
        // Arrange
        var userName = "salom";

        var request = new HttpRequestMessage(HttpMethod.Get, $"api/students/{userName}");

        //Act
        var response = await _httpClient.SendAsync(request);

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task DeleteStudent_Test()
    {
        // Arrange
        Guid studentId = Guid.Parse("051e3b12-31bb-414a-8afc-d9030386b163");

        var request = new HttpRequestMessage(HttpMethod.Delete, $"api/students/{studentId}");

        //Act
        var response = await _httpClient.SendAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccessStatusCode);
    }
}
