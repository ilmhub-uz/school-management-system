using MediatR;

namespace SchoolManagement.Services.Sciences.Notifications;

public class ScienceCreatedNotificationHandler : INotificationHandler<ScienceCreatedNotification>
{
    private readonly ILogger<ScienceCreatedNotificationHandler> _logger;

    public ScienceCreatedNotificationHandler(ILogger<ScienceCreatedNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ScienceCreatedNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Science created: Id: {notification.Id}");

        return Task.CompletedTask;
    }
}