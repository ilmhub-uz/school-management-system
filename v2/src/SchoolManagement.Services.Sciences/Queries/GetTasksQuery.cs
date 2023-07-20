using MediatR;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public record GetTasksQuery(string? Title) : IRequest<IEnumerable<TaskModel>>
{
    public Guid? TopicId { get; set; }
}