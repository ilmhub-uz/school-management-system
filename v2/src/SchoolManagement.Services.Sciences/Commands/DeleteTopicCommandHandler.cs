using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Exceptions;

namespace SchoolManagement.Services.Sciences.Commands;

public class DeleteTopicCommandHandler : RequestHandlerBase, IRequestHandler<DeleteTopicCommand>
{
    public DeleteTopicCommandHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await SciencesDb.Topics.SingleOrDefaultAsync(t => t.ScienceId == request.ScienceId && t.Id == request.Id, cancellationToken);

        if (topic == null)
        {
            throw new RecordNotFoundException("Topic");
        }

        SciencesDb.Topics.Remove(topic);

        await SciencesDb.SaveChangesAsync(cancellationToken);
    }
}