using MediatR;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Exceptions;
using SchoolManagement.Services.Sciences.Extensions;

namespace SchoolManagement.Services.Sciences.Commands;

public class UpdateScienceCommandHandler : RequestHandlerBase, IRequestHandler<UpdateScienceCommand>
{
    public UpdateScienceCommandHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task Handle(UpdateScienceCommand request, CancellationToken cancellationToken)
    {
        var science = await SciencesDb.Sciences.FindAsync(request.Id);

        if (science == null)
        {
            throw new RecordNotFoundException("Science");
        }

        science.Name = request.Title!.ToNormalized();
        science.Title = request.Title!;
        science.Description = request.Description;

        SciencesDb.Sciences.Update(science);

        await SciencesDb.SaveChangesAsync(cancellationToken);
    }
}