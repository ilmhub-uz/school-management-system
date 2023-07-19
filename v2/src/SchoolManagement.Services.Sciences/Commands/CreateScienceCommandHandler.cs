using MediatR;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Entities;
using SchoolManagement.Services.Sciences.Models;
using SchoolManagement.Services.Sciences.Notifications;

namespace SchoolManagement.Services.Sciences.Commands;

public class CreateScienceCommandHandler : IRequestHandler<CreateScienceCommand, ScienceModel>
{
	private readonly SciencesDbContext _sciencesDbContext;
	private readonly IMediator _mediator;

	public CreateScienceCommandHandler(SciencesDbContext sciencesDbContext, IMediator mediator)
	{
		_sciencesDbContext = sciencesDbContext;
		_mediator = mediator;
	}

	public async Task<ScienceModel> Handle(CreateScienceCommand request, CancellationToken cancellationToken)
	{
		var science = new Science()
		{
			Title = request.Title,
			Name = request.Name,
			Description = request.Description
		};

		_sciencesDbContext.Sciences.Add(science);
		await _sciencesDbContext.SaveChangesAsync();

		await _mediator.Publish(new ScienceCreatedNotification()
		{
			Id = science.Id,
			Title = science.Title,
			Description = science.Description,
			CreatedAt = science.CreatedAt,
			Name = science.Name
		});

		return science.ToModel();
	}
}