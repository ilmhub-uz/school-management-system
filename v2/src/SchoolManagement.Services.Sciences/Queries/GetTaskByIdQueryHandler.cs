using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Exceptions;
using SchoolManagement.Services.Sciences.Mappers;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public class GetTaskByIdQueryHandler : RequestHandlerBase, IRequestHandler<GetTaskByIdQuery, TaskModel>
{
    public GetTaskByIdQueryHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task<TaskModel> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await SciencesDb.TopicTasks
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task == null)
        {
            throw new RecordNotFoundException("Task");
        }

        return task.ToModel();
    }

}