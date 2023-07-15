using Sciences.API.Entities;
using Sciences.API.Models.ScienceModels;

namespace Sciences.API.Repositories;

public interface IScienceRepository
{
    Task<List<Science>> GetSciences();
    Task AddScience(Science science);
    Task UpdateScience(Science science);
    Task DeleteScience(Science science);
    Task<Science> GetScienceById(Guid id);
}