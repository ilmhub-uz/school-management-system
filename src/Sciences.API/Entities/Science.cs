namespace Sciences.API.Entities;

public class Science
{
    public Guid? Id { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt {get; set; }
    public required string Name { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public List<Topic>? Topics { get; set; }
}