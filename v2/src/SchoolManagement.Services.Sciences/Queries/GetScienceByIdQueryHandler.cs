using MediatR;
using SchoolManagement.Services.Sciences.Context;
using SchoolManagement.Services.Sciences.Exceptions;
using SchoolManagement.Services.Sciences.Mappers;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Queries;

public class GetScienceByIdQueryHandler : RequestHandlerBase, IRequestHandler<GetScienceByIdQuery, ScienceModel>
{
    public GetScienceByIdQueryHandler(SciencesDbContext sciencesDbContext) : base(sciencesDbContext)
    {
    }

    public async Task<ScienceModel> Handle(GetScienceByIdQuery request, CancellationToken cancellationToken)
    {
        var science = await SciencesDb.Sciences.FindAsync(request.Id);

        if (science == null)
        {
            throw new RecordNotFoundException("Science");
        }

        return science.ToModel();
    }
}