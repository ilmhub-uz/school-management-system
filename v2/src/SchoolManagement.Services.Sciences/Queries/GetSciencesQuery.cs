using MediatR;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public class GetSciencesQuery : IRequest<IEnumerable<ScienceModel>>
{
	public string? Title { get; set; }
}