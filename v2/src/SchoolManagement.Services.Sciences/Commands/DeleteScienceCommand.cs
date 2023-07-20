using MediatR;

namespace SchoolManagement.Services.Sciences.Commands;

public record DeleteScienceCommand(Guid Id) : IRequest;