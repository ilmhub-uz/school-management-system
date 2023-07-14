using Sciences.API.Entities;
using Sciences.API.Models.ScienceModels;

namespace Sciences.API.Repositories;

public interface IScienceRepository
{
    Task<List<Science>> GetSciences();
    Task AddScience(CreateScienceModel model);
    Task UpdateScience(Guid scienceId,UpdateScienceModel model);
    Task DeleteScience(Guid scienceId);
    Task<Science> GetScienceById(Guid scienceId);
}