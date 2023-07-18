using SchoolManagement.Core.Entities;

namespace SchoolManagement.Services.Sciences.Entities;

public class Science : Entity, IAuditable
{
    public required string Name { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual ICollection<Topic>? Topics { get; set; }
}