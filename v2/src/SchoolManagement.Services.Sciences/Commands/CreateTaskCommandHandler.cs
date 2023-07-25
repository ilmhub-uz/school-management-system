using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Entities;
using SchoolManagement.Services.Sciences.Exceptions;
using SchoolManagement.Services.Sciences.Mappers;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Commands;

public class CreateTaskCommandHandler : RequestHandlerBase, IRequestHandler<CreateTaskCommand, TaskModel>
{
    public CreateTaskCommandHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task<TaskModel> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        if (await SciencesDb.Topics.AnyAsync(s => s.Id != request.TopicId, cancellationToken))
        {
            throw new RecordNotFoundException("Topic");
        }

        var task = new TopicTask()
        {
            Title = request.Title!,
            Description = request.Description,
            Content = request.Content,
            TopicId = request.TopicId
        };

        SciencesDb.TopicTasks.Add(task);
        await SciencesDb.SaveChangesAsync(cancellationToken);

        return task.ToModel();
    }
}