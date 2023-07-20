using MediatR;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Entities;
using SchoolManagement.Services.Sciences.Mappers;
using SchoolManagement.Services.Sciences.Models;
using SchoolManagement.Services.Sciences.Extensions;

namespace SchoolManagement.Services.Sciences.Commands;

public class CreateScienceCommandHandler : RequestHandlerBase, IRequestHandler<CreateScienceCommand, ScienceModel>
{
	private readonly IMediator _mediator;

    public CreateScienceCommandHandler(SciencesDbContext sciencesDbContext, IMediator mediator) : base(sciencesDbContext)
    {
        _mediator = mediator;
    }

    public async Task<ScienceModel> Handle(CreateScienceCommand request, CancellationToken cancellationToken)
    {
        var normalizedTitle = request.Title!.ToNormalized();

        var science = new Science()
		{
			Name = normalizedTitle,
			Title = request.Title!,
            Description = request.Description
		};

		SciencesDb.Sciences.Add(science);
		await SciencesDb.SaveChangesAsync(cancellationToken);

		await _mediator.Publish(science.ToNotification(), cancellationToken);

		return science.ToModel();
	}
}