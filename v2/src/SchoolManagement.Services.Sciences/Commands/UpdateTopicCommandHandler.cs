using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Exceptions;
using SchoolManagement.Services.Sciences.Extensions;

namespace SchoolManagement.Services.Sciences.Commands;

public class UpdateTopicCommandHandler : RequestHandlerBase, IRequestHandler<UpdateTopicCommand>
{
    public UpdateTopicCommandHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await SciencesDb.Topics.SingleOrDefaultAsync(t => t.ScienceId == request.ScienceId && t.Id == request.Id, cancellationToken);

        if (topic == null)
        {
            throw new RecordNotFoundException("Topic");
        }

        topic.Name = request.Title!.ToNormalized();
        topic.Title = request.Title!;
        topic.Description = request.Description;
        topic.Content = request.Content;
        topic.Date = request.Date;
        
        SciencesDb.Topics.Update(topic);

        await SciencesDb.SaveChangesAsync(cancellationToken);
    }
}