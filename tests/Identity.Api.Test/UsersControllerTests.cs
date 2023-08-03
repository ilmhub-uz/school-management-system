using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Moq;
using SchoolManagement.Core.Models;
using SchoolManagement.Services.Identity.Managers;
using SchoolManagement.Services.Identity.Models;
using System.Net.Http.Json;

namespace Identity.Api.Test;

public class UsersControllerTests
{
     private readonly HttpClient _httpClient;

    public UsersControllerTests()
    {
        var webAppFactory = new CustomWebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task GetUsersByFilterTest()
    {
        // Arrange
        var filter = new UserFilter()
        {
           UserName= "true ;)",
        };

        //Act 
        var request = new HttpRequestMessage(HttpMethod.Get, "api/Users");
        request.Content = JsonContent.Create(filter);

        var response = await _httpClient.SendAsync(request);

        //Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccessStatusCode);

    }

    [Fact]
    public async Task GetUserByUserNameTest()
    {
        // Arrage 

        string username = "Abdulloh";

        // Act 

        var request = new HttpRequestMessage(HttpMethod.Get, "api/Users/{username}");

        var response = await _httpClient.SendAsync(request);

        // Assert

        Assert.NotNull(response);
        Assert.True(response.IsSuccessStatusCode);

    }

    [Fact]
    public async Task GetUserByIdTest()
    {
        // Arrage 
        Guid id = Guid.NewGuid();

        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "api/Users/{id}");
        var response =await _httpClient.SendAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccessStatusCode);
    }

}

public class TCustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureServices(async services =>
        {
            var usermanager = services.SingleOrDefault(s=>s.ServiceType == typeof(UserManager));
            if(usermanager != null ) 
                services.Remove(usermanager);

            var mockUserManager = new Mock<IUserManager>();

            mockUserManager.Setup(s => s.GetUsersAsync(It.IsAny<UserFilter>())).ReturnsAsync(new List<UserModel>
            {
                        new UserModel(Guid.NewGuid(), "alijon1", DateTime.Now, null, UserStatus.Active, new List<string>()),
                        new UserModel(Guid.NewGuid(), "Shamsiddn", DateTime.Now, null, UserStatus.Blocked, new List<string>()),
                        new UserModel(Guid.NewGuid(), "Akmaljon", DateTime.Now, null, UserStatus.Active, new List<string>()),
                        new UserModel(Guid.NewGuid(), "Azizbek", DateTime.Now, null, UserStatus.Active, new List<string>()),
                        new UserModel(Guid.NewGuid(), "VALIJON", DateTime.Now, null, UserStatus.Active, new List<string>())
            });
            mockUserManager.Setup(u => u.GetUserAsync("Abdulloh")).ReturnsAsync(new UserModel(Guid.NewGuid(), "Abdulloh", DateTime.Now, null, UserStatus.Active, new List<string>()));
            mockUserManager.Setup(y => y.GetUserAsync(It.IsAny<Guid>())).ReturnsAsync(new UserModel(Guid.NewGuid(), "Samandar", DateTime.Now, null, UserStatus.Created, new List<string>()));

            services.AddScoped(s => mockUserManager.Object);
        });

        builder.UseEnvironment("Development");
    }
}