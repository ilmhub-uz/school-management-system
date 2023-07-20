namespace SchoolManagement.Services.Sciences.Context;

public class RequestHandlerBase
{
    protected readonly SciencesDbContext SciencesDb;

    public RequestHandlerBase(SciencesDbContext sciencesDbContext)
    {
        SciencesDb = sciencesDbContext;
    }
}