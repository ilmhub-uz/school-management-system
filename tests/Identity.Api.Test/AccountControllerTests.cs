using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SchoolManagement.Services.Identity.Context;
using SchoolManagement.Services.Identity.Entities;
using SchoolManagement.Services.Identity.Managers;
using SchoolManagement.Services.Identity.Models;
using System.Net.Http.Json;
using SchoolManagement.Core.Models;

namespace Identity.Api.Test;

public class AccountControllerTests
{
    private readonly HttpClient _httpClient;

    public AccountControllerTests()
    {
        var webAppFactory = new CustomWebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task Register_ReturnsSuccessStatus()
    {
        //Arrange
        var createUserModel = new CreateUserModel()
        {
            Username = "test",
            Password = "Salom1234",
            ConfirmPassword = "Salom1234"
        };

        
        //Act
        var request = new HttpRequestMessage(HttpMethod.Post, "api/Account/register");
        request.Content = JsonContent.Create(createUserModel);

        var response = await _httpClient.SendAsync(request);

        //Assert
        Assert.True(response.IsSuccessStatusCode);

        var user = await response.Content.ReadFromJsonAsync<UserModel>();
        Assert.NotNull(user);
    }

    [Theory]
    [InlineData("tes", "salom1234", "salom1234", StatusCodes.Status400BadRequest)]
    [InlineData("test", "salom1234", "salom1234", StatusCodes.Status400BadRequest)]
    [InlineData("test", "Salom1234", "salom1234", StatusCodes.Status400BadRequest)]
    [InlineData("test", "Salom", "Salom", StatusCodes.Status400BadRequest)]
    public async Task Register_ReturnsIsNotSuccessStatus(string username, string password, string confirmPassword, int statusCode)
    {
        //Arrange
        var createUserModel = new CreateUserModel()
        {
            Username = username,
            Password = password,
            ConfirmPassword = confirmPassword
        };

        //Act
        var request = new HttpRequestMessage(HttpMethod.Post, "api/Account/register");
        request.Content = JsonContent.Create(createUserModel);

        var response = await _httpClient.SendAsync(request);

        //Assert
        Assert.Equal((int)response.StatusCode, statusCode);
    }

    [Fact]
    public async Task Login_ReturnsSuccessStatus()
    {
        //Arrange
        var loginUserModel = new LoginUserModel()
        {
            Username = "test",
            Password = "Salom1234",
        };

        //Act
        var request = new HttpRequestMessage(HttpMethod.Post, "api/Account/login");
        request.Content = JsonContent.Create(loginUserModel);

        var response = await _httpClient.SendAsync(request);

        //Assert
        Assert.True(response.IsSuccessStatusCode);
    }
}

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var signInManager = services.SingleOrDefault(s => s.ServiceType == typeof(SignInManager));
            if (signInManager != null)
                services.Remove(signInManager);

            var mockSignInManager = new Mock<ISignInManager>();
            mockSignInManager.Setup(s => s.RegisterAsync(It.IsAny<CreateUserModel>())).ReturnsAsync(new UserModel(Guid.NewGuid(), "test", DateTime.UtcNow, null, UserStatus.Active, new List<string>()));
            mockSignInManager.Setup(s => s.LoginAsync(It.IsNotNull<LoginUserModel>())).ReturnsAsync(new TokenResultModel("token", 1200, DateTime.UtcNow));

            services.AddScoped(s => mockSignInManager.Object);
        });

        builder.UseEnvironment("Development");
    }
}
