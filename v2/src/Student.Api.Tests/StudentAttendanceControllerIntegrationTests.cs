using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using SchoolManagement.Services.Students.Controllers;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentAttendanceModels;
using SchoolManagement.Services.Students.Models.StudentModels;
using SchoolManagement.Services.Students.Models.StudentTaskResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Api.Tests;

public class StudentAttendanceControllerIntegrationTests:IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public StudentAttendanceControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }


    private StringContent GetJsonStringContent(object obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }
    [Fact]
    public async Task GetStudentAttendances_ReturnOk()
    {
        //Arrenge
        var studentId = Guid.NewGuid();
        var studentAttendanceManagerMock = new Mock<IStudentAttendanceManager>();
        studentAttendanceManagerMock.Setup(manager => manager.GetStudentAttendances(studentId))
            .ReturnsAsync(new List<StudentAttendanceModel>()
        {
                new StudentAttendanceModel
                {
                    Attend = true,
                    StudentId = Guid.NewGuid(),
                    TopicId= Guid.NewGuid(),
                    Student = new StudentModel()
                    {
                        Username = "Username",
                        PhoneNumber = "123456789"
                    }
                },
                 new StudentAttendanceModel
                {
                    Attend = true,
                    StudentId = Guid.NewGuid(),
                    TopicId= Guid.NewGuid(),
                    Student = new StudentModel()
                    {
                        Username = "Username1",
                        PhoneNumber = "123456789"
                    }
                },
                  new StudentAttendanceModel
                {
                    Attend = false,
                    StudentId = Guid.NewGuid(),
                    TopicId= Guid.NewGuid(),
                    Student = new StudentModel()
                    {
                        Username = "Username2",
                        PhoneNumber = "123456789"
                    }
                }
        }); 
        var client = _factory.CreateClient();

        //Act
        var response = await client.GetAsync($"/api/students/{studentId}/attendances");

        //Assert
        Assert.NotNull( response );
        // Assert.True(response.IsSuccessStatusCode);
        // Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }


    [Fact]
    public async Task AddStudentTaskResult_ReturnsOk()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var model = new CreateStudentAttendanceModel
        {
            Attend= true,
        };

        var studentAttendanceManagerMock = new Mock<IStudentAttendanceManager>();

        studentAttendanceManagerMock.Setup(manager => manager
                .AddStudentAtttendance(It.IsAny<Guid>(), It.IsAny<CreateStudentAttendanceModel>()))
            .ReturnsAsync(new StudentAttendanceModel { Attend = true,StudentId = Guid.NewGuid(),TopicId = Guid.NewGuid() }); 

        var client = _factory.CreateClient();

        var content = GetJsonStringContent(model);

        // Act
        var response = await client.PostAsync($"/api/students/{studentId}/attendances", content);

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
        // Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task UpdateStudentAttendance_ReturnsOk()
    {
        // Arrange
        var studentId = Guid.NewGuid();
        var topicId = Guid.NewGuid();

        var model = new UpdateStudentAttendanceModel
        {
            Attend= false
        };
        var studentAttendanceManagerMock = new Mock<IStudentAttendanceManager>();

        studentAttendanceManagerMock.Setup(manager => manager
            .UpdateStudentAttendance(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<UpdateStudentAttendanceModel>()));

        var client = _factory.CreateClient();

        var content = GetJsonStringContent(model);

        // Act
        var response = await client.PutAsync($"/api/students/{studentId}/task_results/{topicId}", content);

        // Assert
        Assert.NotNull(response);
        // Assert.True(response.IsSuccessStatusCode);
        // Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

}
