using MassTransit;
using SchoolManagement.Core.Models;
using SchoolManagement.Services.Students.Context;

namespace SchoolManagement.Services.Students.Consumers;

public class UserConsumer: IConsumer<UserModel>
{
    private StudentsDbContext _studentsDbContext;

    public UserConsumer(StudentsDbContext studentsDbContext)
    {
        _studentsDbContext = studentsDbContext;
    }

    public async Task Consume(ConsumeContext<UserModel> context)
    {
        var userModel = context.Message;
    }
}