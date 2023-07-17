namespace Sciences.API.Entities;

public class Topic
{
    public required Guid Id { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required string Name { get; set; }
    public required string Title { get; set; }
    public DateTime? Date { get; set; }
    public virtual Science? Science { get; set; }
    public required Guid ScienceId { get; set; }
    public virtual List<TopicTask>? Tasks { get; set; }
}