using Sciences.API.Entities;
using Sciences.API.Exception;
using Sciences.API.FluentValidators;
using Sciences.API.Models.ScienceModels;
using Sciences.API.ParseHelper;
using Sciences.API.Repositories.Interfaces;

namespace Sciences.API.Managers;

public class ScienceManager
{
    private readonly IScienceRepository _scienceRepository;

    public ScienceManager(IScienceRepository scienceRepository)
    {
        _scienceRepository = scienceRepository;
    }
    
    public async Task<List<ScienceModel>> GetSciencesAsync()
    {
        var sciences = await _scienceRepository.GetSciences();
        return ParseService.ParseToScienceList(sciences);
    }

    public async Task<ScienceModel> AddScienceAsync(CreateScienceModel science)
    {
        var validator = new CreateScienceModelValidator();
        var result = validator.Validate(science);
        if (!result.IsValid)
        {
            throw new CreateScienceValidationIsNotValid("Invalid input try again");
        }
        var model = new Science()
        {
            Description = science.Description,
            Name = science.Name,
            Title = science.Title
        };
        await  _scienceRepository.AddScience(model);
        return ParseService.ParseToScienceModel(model);
    }

    public async Task<ScienceModel> UpdateScienceAsync(Guid scienceId,UpdateScienceModel science)
    {
        var model = await _scienceRepository.GetScienceById(scienceId);
        model.Description = science.Description;
        model.Name = science.Name;
        model.Title = science.Title;
        await _scienceRepository.UpdateScience(model);
        return ParseService.ParseToScienceModel(model);
    }

    public async Task DeleteScienceAsync(Guid scienceId)
    {
        await _scienceRepository.DeleteScience(scienceId);
    }

    public async Task<ScienceModel> GetScienceByIdAsync(Guid scienceId)
    {
        var science = await _scienceRepository.GetScienceById(scienceId);
        return ParseService.ParseToScienceModel(science);
    }
}