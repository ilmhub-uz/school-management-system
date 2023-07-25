using MediatR;
using System.Text.Json.Serialization;

namespace SchoolManagement.Services.Sciences.Commands;

public record UpdateTaskCommand(
    string? Title,
    string? Description,
    string? Content) : IRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public Guid Id { get; set; }
}