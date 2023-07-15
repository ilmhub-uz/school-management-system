namespace Sciences.API.Entities;

public class Science
{
    public required Guid Id { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt {get; set; }
    public required string Name { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public virtual List<Topic>? Topics { get; set; }
}