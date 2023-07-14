namespace Sciences.API.Models.ScienceModels;

public class CreateScienceModel
{
    public required string Name { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}