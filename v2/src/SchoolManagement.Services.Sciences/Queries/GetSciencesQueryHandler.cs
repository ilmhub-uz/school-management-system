using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Mappers;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public class GetSciencesQueryHandler : RequestHandlerBase, IRequestHandler<GetSciencesQuery, IEnumerable<ScienceModel>>
{
    public GetSciencesQueryHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task<IEnumerable<ScienceModel>> Handle(GetSciencesQuery request, CancellationToken cancellationToken)
	{
		var query = SciencesDb.Sciences.AsQueryable();

		if (!string.IsNullOrWhiteSpace(request.Title))
		{
			query = query.Where(s => s.Title.Contains(request.Title));
		}

		var sciences = await query.Select(s => s.ToModel()).ToListAsync(cancellationToken);

		return sciences;
	}
}