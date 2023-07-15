using Sciences.API.Entities;

namespace Sciences.API.Repositories.Interfaces;

public interface IScienceRepository
{
    Task<List<Science>> GetSciences();
    Task AddScience(Science science);
    Task UpdateScience(Science science);
    Task DeleteScience(Science science);
    Task<Science> GetScienceById(Guid id);
}