using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Mappers;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public class GetTasksQueryHandler : RequestHandlerBase, IRequestHandler<GetTasksQuery, IEnumerable<TaskModel>>
{
    public GetTasksQueryHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task<IEnumerable<TaskModel>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
	{
		var query = SciencesDb.TopicTasks.AsQueryable();

		if (!string.IsNullOrWhiteSpace(request.Title))
		{
			query = query.Where(s => s.Title.Contains(request.Title));
		}

        if (request.TopicId is not null)
        {
            query = query.Where(s => s.TopicId == request.TopicId);
        }

        var tasks = await query.Select(s => s.ToModel())
            .ToListAsync(cancellationToken);

		return tasks;
	}
}