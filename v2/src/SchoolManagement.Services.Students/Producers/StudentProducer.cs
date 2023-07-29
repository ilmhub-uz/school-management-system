using MassTransit;
using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Producers;

public class StudentProducer : IStudentProducer
{
    private readonly IBus _bus;
    public StudentProducer(IBus bus)
    {
        _bus = bus;
    }
    public async Task PublishStudent(Student student)
    {
        await _bus.Publish<Student>(student);
    }
}
