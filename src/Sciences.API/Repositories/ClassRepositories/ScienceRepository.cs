using Sciences.API.Entities;

namespace Sciences.API.Repositories.ClassRepositories;

public class ScienceRepository: IScienceRepository
{
    public Task<List<Science>> GetSciences()
    {
        throw new NotImplementedException();
    }

    public Task AddScience(Science science)
    {
        throw new NotImplementedException();
    }

    public Task UpdateScience(Science science)
    {
        throw new NotImplementedException();
    }

    public Task DeleteScience(Science science)
    {
        throw new NotImplementedException();
    }

    public Task<Science> GetScienceById(Guid id)
    {
        throw new NotImplementedException();
    }
}