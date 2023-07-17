namespace Sciences.API.Models.TopicTaskModels;

public class CreateTopicTaskModel
{
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
    public required Guid TopicId { get; set; }
}