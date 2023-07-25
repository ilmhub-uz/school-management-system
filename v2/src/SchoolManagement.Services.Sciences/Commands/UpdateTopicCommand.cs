using MediatR;
using System.Text.Json.Serialization;

namespace SchoolManagement.Services.Sciences.Commands;

public record UpdateTopicCommand(
    string? Title,
    string? Description,
    string? Content,
    DateTime? Date) : IRequest
{

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public Guid Id { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public Guid ScienceId { get; set; }
}