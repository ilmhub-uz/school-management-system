using Sciences.API.Models.TopicModels;

namespace Sciences.API.Models.ScienceModels;


public class ScienceModel
{

    public required Guid Id { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required string Name { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public List<TopicModel>? Topics { get; set; }
}