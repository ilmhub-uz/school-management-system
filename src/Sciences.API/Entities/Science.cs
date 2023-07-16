namespace Sciences.API.Entities;

public class Science
{
    public  Guid Id { get; set; }
    public  DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt {get; set; }
    public  string Name { get; set; }
    public  string Title { get; set; }
    public string? Description { get; set; }
    public List<Topic>? Topics { get; set; }
}