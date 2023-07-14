namespace Sciences.API.Models.ScienceModels;

public class UpdateScienceModel
{
    public required string Name { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}