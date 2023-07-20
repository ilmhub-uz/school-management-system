using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public record GetTopicsQuery(string? Title) : IRequest<IEnumerable<TopicModel>>
{
    [BindNever]
    public Guid ScienceId { get; set; }
}