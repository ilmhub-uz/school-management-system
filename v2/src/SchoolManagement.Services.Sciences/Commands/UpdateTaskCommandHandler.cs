using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Exceptions;

namespace SchoolManagement.Services.Sciences.Commands;

public class UpdateTaskCommandHandler : RequestHandlerBase, IRequestHandler<UpdateTaskCommand>
{
    public UpdateTaskCommandHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await SciencesDb.TopicTasks.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task == null)
        {
            throw new RecordNotFoundException("Task");
        }

        task.Title = request.Title!;
        task.Description = request.Description;
        task.Content = request.Content;

        SciencesDb.TopicTasks.Update(task);

        await SciencesDb.SaveChangesAsync(cancellationToken);
    }
}