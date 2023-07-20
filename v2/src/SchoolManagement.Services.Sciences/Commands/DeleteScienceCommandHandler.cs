using MediatR;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Exceptions;

namespace SchoolManagement.Services.Sciences.Commands;

public class DeleteScienceCommandHandler : RequestHandlerBase, IRequestHandler<DeleteScienceCommand>
{
    public DeleteScienceCommandHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task Handle(DeleteScienceCommand request, CancellationToken cancellationToken)
    {
        var science = await SciencesDb.Sciences.FindAsync(request.Id);

        if (science == null)
        {
            throw new RecordNotFoundException("Science");
        }

        SciencesDb.Sciences.Remove(science);

        await SciencesDb.SaveChangesAsync(cancellationToken);
    }
}