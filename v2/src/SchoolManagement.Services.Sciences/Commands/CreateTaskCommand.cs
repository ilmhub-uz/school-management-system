using MediatR;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Commands;

public record CreateTaskCommand(
    string? Title,
    string? Description,
    string? Content) : IRequest<TaskModel>
{
    public Guid TopicId { get; set; }
}