namespace Sciences.API.Entities;

public class TopicTask
{
    public required Guid Id { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
    public virtual Topic? Topic { get; set; }
    public required Guid TopicId { get; set; }
}