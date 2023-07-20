using SchoolManagement.Services.Sciences.Entities;
using SchoolManagement.Services.Sciences.Models;
using SchoolManagement.Services.Sciences.Notifications;

namespace SchoolManagement.Services.Sciences.Mappers;

public static partial class Mappers
{
    public static ScienceModel ToModel(this Science science)
    {
        return new ScienceModel(
            science.Id,
            science.Name,
            science.Title,
            science.Description,
            science.CreatedAt,
            science.UpdatedAt);
    }

    public static ScienceCreatedNotification ToNotification(this Science science)
    {
        return new ScienceCreatedNotification
        {
            Id = science.Id,
            Name = science.Name,
            Title = science.Title,
            CreatedAt = science.CreatedAt,
            Description = science.Description
        };
    }
}
