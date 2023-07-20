using MediatR;
using SchoolManagement.Services.Sciences.Models;
using System.Text.Json.Serialization;

namespace SchoolManagement.Services.Sciences.Commands;

public record CreateTopicCommand(
    string? Title,
    string? Description,
    string? Content,
    DateTime? Date) : IRequest<TopicModel>
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public Guid ScienceId { get; set; }
}