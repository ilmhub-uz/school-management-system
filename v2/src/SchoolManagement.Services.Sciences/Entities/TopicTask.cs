using SchoolManagement.Core.Entities;

namespace SchoolManagement.Services.Sciences.Entities;

public class TopicTask : Entity, IAuditable
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid TopicId { get; set; }
    public virtual Topic? Topic { get; set; }
}