using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Producers;

public interface IStudentProducer
{
    Task PublishStudent(Student student);
}
