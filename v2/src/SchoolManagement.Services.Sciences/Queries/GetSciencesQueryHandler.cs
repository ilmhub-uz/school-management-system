using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public class GetSciencesQueryHandler : IRequestHandler<GetSciencesQuery, IEnumerable<ScienceModel>>
{
	private readonly SciencesDbContext _sciencesDbContext;

	public GetSciencesQueryHandler(SciencesDbContext sciencesDbContext)
	{
		_sciencesDbContext = sciencesDbContext;
	}

	public async Task<IEnumerable<ScienceModel>> Handle(GetSciencesQuery request, CancellationToken cancellationToken)
	{
		var query = _sciencesDbContext.Sciences.AsQueryable();

		if (!string.IsNullOrWhiteSpace(request.Title))
		{
			query = query.Where(s => s.Title.Contains(request.Title));
		}

		var sciences = await query.Select(s => s.ToModel()).ToListAsync();

		return sciences;
	}
}