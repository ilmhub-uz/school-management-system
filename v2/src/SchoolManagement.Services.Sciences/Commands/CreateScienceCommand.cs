using MediatR;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Commands;

public class CreateScienceCommand : IRequest<ScienceModel>
{
	public string? Name { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
}