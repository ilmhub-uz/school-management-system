using MediatR;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public record GetScienceByIdQuery(Guid Id) : IRequest<ScienceModel>;