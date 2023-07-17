using Sciences.API.Entities;

namespace Sciences.API.Repositories.Interfaces;

public interface ITopicTaskRepository
{
    Task<List<TopicTask>> GetTopicTasks(Guid scienceId, DateTime date);

    Task AddTopicTask(Guid scienceId, DateTime date, TopicTask task);

    Task UpdateTopicTask(Guid scienceId, DateTime date, TopicTask task);

    Task DeleteTopicTask(Guid scienceId,DateTime date,Guid taskId);
}
