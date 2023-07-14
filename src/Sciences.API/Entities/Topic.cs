namespace Sciences.API.Entities;

public class Topic
{
    public required Guid Id { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required string Name { get; set; }
    public required string Title { get; set; }
    public DateTime? Date { get; set; }
    public Science? Science { get; set; }
    public required Guid ScienceId { get; set; }
    public List<TopicTask> Tasks { get; set; }
}