using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Exceptions;
using SchoolManagement.Services.Sciences.Mappers;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public class GetTopicByIdQueryHandler : RequestHandlerBase, IRequestHandler<GetTopicByIdQuery, TopicModel>
{
    public GetTopicByIdQueryHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task<TopicModel> Handle(GetTopicByIdQuery request, CancellationToken cancellationToken)
    {
        var topic = await SciencesDb.Topics
            .Include(t => t.Science)
            .FirstOrDefaultAsync(t => t.ScienceId == request.ScienceId && t.Id == request.Id, cancellationToken);

        if (topic == null)
        {
            throw new RecordNotFoundException("Topic");
        }

        return topic.ToModel();
    }

}