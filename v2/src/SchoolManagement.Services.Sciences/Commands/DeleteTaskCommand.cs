using MediatR;

namespace SchoolManagement.Services.Sciences.Commands;

public record DeleteTaskCommand(Guid Id) : IRequest;