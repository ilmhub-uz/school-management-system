using System.Text.Json.Serialization;

namespace SchoolManagement.Services.Sciences.Models;

public class TopicModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public DateTime? Date { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ScienceModel? Science { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<TaskModel>? Tasks { get; set; }

    public TopicModel(
        Guid id,
        string name,
        string title,
        string? description,
        string? content,
        DateTime? date,
        DateTime createdAt,
        DateTime? updatedAt,
        ScienceModel? science,
        IEnumerable<TaskModel>? tasks)
    {
        Id = id;
        Name = name;
        Title = title;
        Description = description;
        Content = content;
        Date = date;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Science = science;
        Tasks = tasks;
    }

    public TopicModel(
        Guid id,
        string name,
        string title,
        string? description,
        string? content,
        DateTime? date,
        DateTime createdAt,
        DateTime? updatedAt) : this(id, name, title, description, content, date, createdAt, updatedAt, default, default)
    {
    }
}