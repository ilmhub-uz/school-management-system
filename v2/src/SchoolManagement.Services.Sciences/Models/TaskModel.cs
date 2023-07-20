using System.Text.Json.Serialization;

namespace SchoolManagement.Services.Sciences.Models;

public class TaskModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TopicModel? Topic { get; set; }

    public TaskModel(Guid id, string title, string? description, string? content, DateTime createdAt, DateTime? updatedAt, TopicModel? topic)
    {
        Id = id;
        Title = title;
        Description = description;
        Content = content;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Topic = topic;
    }
}