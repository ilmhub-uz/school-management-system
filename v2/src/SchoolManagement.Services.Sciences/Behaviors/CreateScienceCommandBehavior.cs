using FluentValidation;
using MediatR;
using SchoolManagement.Services.Sciences.Commands;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Behaviors;

public class CreateScienceCommandBehavior : IPipelineBehavior<CreateScienceCommand, ScienceModel>
{
	private readonly IValidator<CreateScienceCommand> _validator;

	public CreateScienceCommandBehavior(IValidator<CreateScienceCommand> validator)
	{
		_validator = validator;
	}

	public async Task<ScienceModel> Handle(
		CreateScienceCommand request, 
		RequestHandlerDelegate<ScienceModel> next, CancellationToken cancellationToken)
	{
		var validationResult = _validator.Validate(request);

		if (!validationResult.IsValid)
		{
			throw new ValidationException("CreateScienceCommand is not valid", validationResult.Errors);
		}

		return await next();
	}
}