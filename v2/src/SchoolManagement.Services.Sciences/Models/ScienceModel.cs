namespace SchoolManagement.Services.Sciences.Models;

public record ScienceModel(
    Guid Id,
    string Name,
    string Title,
    string? Description,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
