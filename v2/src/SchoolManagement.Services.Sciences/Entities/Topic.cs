using SchoolManagement.Core.Entities;

namespace SchoolManagement.Services.Sciences.Entities;

public class Topic : Entity, IAuditable
{
    public required string Name { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public DateTime? Date { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid ScienceId { get; set; }
    public virtual Science? Science { get; set; }
    public virtual ICollection<TopicTask>? Tasks { get; set; }
}