using MassTransit;
using SchoolManagement.Services.Chats.Context;
using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Chats.Consumers;

public class StudentConsumer : IConsumer<Student>
{
    private readonly ChatsDbContext _dbContext;

    public StudentConsumer(ChatsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<Student> context)
    {
        Student student = context.Message;

        await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();
    }
}