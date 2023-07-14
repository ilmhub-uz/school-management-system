using Sciences.API.Entities;

namespace Sciences.API.Models.TopicModels;

public class CreateTopicModel
{
    public required string Name { get; set; }
    public required string Title { get; set; }
}