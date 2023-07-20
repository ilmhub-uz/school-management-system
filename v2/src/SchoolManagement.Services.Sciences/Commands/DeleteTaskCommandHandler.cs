using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Exceptions;

namespace SchoolManagement.Services.Sciences.Commands;

public class DeleteTaskCommandHandler : RequestHandlerBase, IRequestHandler<DeleteTaskCommand>
{
    public DeleteTaskCommandHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await SciencesDb.TopicTasks.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task == null)
        {
            throw new RecordNotFoundException("Task");
        }

        SciencesDb.TopicTasks.Remove(task);

        await SciencesDb.SaveChangesAsync(cancellationToken);
    }
}