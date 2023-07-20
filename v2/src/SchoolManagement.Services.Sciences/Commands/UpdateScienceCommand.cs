using MediatR;
using System.Text.Json.Serialization;

namespace SchoolManagement.Services.Sciences.Commands;

public record UpdateScienceCommand(string? Title, string? Description) : IRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public Guid Id { get; set; }
}