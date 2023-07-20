using SchoolManagement.Services.Sciences.Entities;

namespace SchoolManagement.Services.Sciences.Models;

public record ScienceModel(
	Guid Id,
	string Name,
	string Title,
	string? Description,
	DateTime CreatedAt,
	DateTime? UpdatedAt);

public static class ScienceExtensions
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
}
