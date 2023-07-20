using MediatR;

namespace SchoolManagement.Services.Sciences.Commands;

public record DeleteTopicCommand(Guid Id, Guid ScienceId) : IRequest;