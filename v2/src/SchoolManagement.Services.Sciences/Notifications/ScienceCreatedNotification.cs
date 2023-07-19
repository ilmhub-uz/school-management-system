using MediatR;

namespace SchoolManagement.Services.Sciences.Notifications;

public class ScienceCreatedNotification : INotification
{
	public Guid Id { get; set; }
	public required string Name { get; set; }
	public required string Title { get; set; }
	public DateTime CreatedAt { get; set; }
	public string? Description { get; set; }
}