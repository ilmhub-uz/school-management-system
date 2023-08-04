using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Moq;
using SchoolManagement.Core.Models;
using SchoolManagement.Services.Identity.Managers;
using SchoolManagement.Services.Identity.Models;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace Identity.Api.Test;

public class UsersControllerTests
{
     private readonly HttpClient _httpClient;

    public UsersControllerTests()
    {
        var webAppFactory = new TCustomWebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task GetUsersByFilterTest()
    {
        // Arrange
        var filter = new UserFilter()
        {
           UserName= "true;)",
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
        string errorusername = "/";

        // Act 

        var Successrequest = new HttpRequestMessage(HttpMethod.Get, $"api/Users/{username}");
        var errorRequest = new HttpRequestMessage(HttpMethod.Get, $"api/Users/{errorusername}");

        var errorResponse = await _httpClient.SendAsync(errorRequest);
        var Successresponse = await _httpClient.SendAsync(Successrequest);

        // Assert

        Assert.NotNull(Successresponse);
        Assert.True(Successresponse.IsSuccessStatusCode);

        Assert.NotNull(errorResponse);
        Assert.Equal(HttpStatusCode.NotFound, errorResponse.StatusCode);

    }

    [Fact]
    public async Task GetUserByIdTest()
    {
        // Arrage 
        Guid id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        int errorId = 18974747;


        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/Users/{id}");
        var response =await _httpClient.SendAsync(request);

        var errorRequest = new HttpRequestMessage(HttpMethod.Get, $"api/Users/{errorId}");
        var errorResponse = await _httpClient.SendAsync(errorRequest);

        // Assert
        Assert.NotNull(response);      
        Assert.True(response.IsSuccessStatusCode); 
        
        Assert.NotNull(errorResponse);
        Assert.Equal(HttpStatusCode.NotFound, errorResponse.StatusCode);
    }

}

public class TCustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureServices(async services =>
        {
            var usermanager = services.SingleOrDefault(s=>s.ServiceType == typeof(IUserManager));
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
            mockUserManager.Setup(u => u.GetUserAsync("Abdulloh")).ReturnsAsync(new UserModel(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Abdulloh", DateTime.Now, null, UserStatus.Active, new List<string>()));
            mockUserManager.Setup(y => y.GetUserAsync(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"))).ReturnsAsync(new UserModel(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Samandar", DateTime.Now, null, UserStatus.Created, new List<string>()));

            services.AddScoped<IUserManager>(s => mockUserManager.Object);
        });

        builder.UseEnvironment("Development");
    }
}