using SchoolManagement.Services.Sciences.Entities;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Mappers;

public static partial class Mappers
{
    public static TopicModel ToModel(this Topic topic)
    {
        var science = topic.Science?.ToModel();
        var tasks = topic.Tasks?.ToList().Select(ToModel);

        return new TopicModel(
            topic.Id,
            topic.Name,
            topic.Title,
            topic.Description,
            topic.Content,
            topic.Date,
            topic.CreatedAt,
            topic.UpdatedAt,
            science,
            tasks);
    }
}