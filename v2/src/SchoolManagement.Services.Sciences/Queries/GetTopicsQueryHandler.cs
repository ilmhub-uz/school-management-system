using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Mappers;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public class GetTopicsQueryHandler : RequestHandlerBase, IRequestHandler<GetTopicsQuery, IEnumerable<TopicModel>>
{
    public GetTopicsQueryHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task<IEnumerable<TopicModel>> Handle(GetTopicsQuery request, CancellationToken cancellationToken)
	{
		var query = SciencesDb.Topics.AsQueryable();

		if (!string.IsNullOrWhiteSpace(request.Title))
		{
			query = query.Where(s => s.Title.Contains(request.Title));
		}

		var topics = await query.Where(t => t.ScienceId == request.ScienceId)
            .Select(s => s.ToModel())
            .ToListAsync(cancellationToken);

		return topics;
	}
}