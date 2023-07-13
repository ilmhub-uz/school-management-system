namespace Sciences.API.Entities;

public class TopicTask
{
    public Guid Id { get; set; }

    public Guid TopicId { get; set; }
    public Topic? Topic { get; set; }

    public Guid ScienceId { get; set; }
    public Science? Science { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
}