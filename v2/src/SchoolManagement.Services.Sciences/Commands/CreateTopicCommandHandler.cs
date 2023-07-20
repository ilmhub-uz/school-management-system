using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Entities;
using SchoolManagement.Services.Sciences.Exceptions;
using SchoolManagement.Services.Sciences.Mappers;
using SchoolManagement.Services.Sciences.Models;
using SchoolManagement.Services.Sciences.Extensions;

namespace SchoolManagement.Services.Sciences.Commands;

public class CreateTopicCommandHandler : RequestHandlerBase, IRequestHandler<CreateTopicCommand, TopicModel>
{
    public CreateTopicCommandHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task<TopicModel> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        if (await SciencesDb.Sciences.AnyAsync(s => s.Id != request.ScienceId, cancellationToken))
        {
            throw new RecordNotFoundException("Science");
        }

        var normalizedTitle = request.Title!.ToNormalized();

        var topic = new Topic()
		{
			Name = normalizedTitle,
			Title = request.Title!,
            Description = request.Description,
            Content = request.Content,
            Date = request.Date,
            ScienceId = request.ScienceId
		};

		SciencesDb.Topics.Add(topic);
		await SciencesDb.SaveChangesAsync(cancellationToken);

		return topic.ToModel();
	}
}