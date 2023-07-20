using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public record GetTopicByIdQuery(Guid Id) : IRequest<TopicModel>
{
    [BindNever]
    public Guid ScienceId { get; set; }
}