using MediatR;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Commands;

public record CreateScienceCommand(string? Title, string? Description) : IRequest<ScienceModel>;