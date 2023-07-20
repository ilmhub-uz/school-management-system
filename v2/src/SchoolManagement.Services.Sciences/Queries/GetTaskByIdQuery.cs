using MediatR;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public record GetTaskByIdQuery(Guid Id) : IRequest<TaskModel>
{

}