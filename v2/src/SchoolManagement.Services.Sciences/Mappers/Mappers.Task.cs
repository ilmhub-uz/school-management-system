using SchoolManagement.Services.Sciences.Entities;
using SchoolManagement.Services.Sciences.Models;

namespace SchoolManagement.Services.Sciences.Mappers;

public static partial class Mappers
{
    public static TaskModel ToModel(this TopicTask task)
    {
        var topic = task.Topic?.ToModel();

        return new TaskModel(
            task.Id,
            task.Title,
            task.Description,
            task.Content,
            task.CreatedAt,
            task.UpdatedAt,
            topic);
    }
}