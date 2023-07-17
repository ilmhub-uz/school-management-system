using Sciences.API.Entities;

namespace Sciences.API.Repositories.Interfaces;

public interface ITopicTaskRepository
{
    Task<List<TopicTask>> GetTopicTasks(Guid scienceId, DateTime date);

    Task AddTopicTask(Guid scienceId, DateTime date, TopicTask task);

    Task UpdateTopicTask(TopicTask task);

    Task DeleteTopicTask(Guid scienceId,DateTime date,Guid taskId);

    Task<TopicTask> GetTopicTaskById(Guid scienceId, DateTime date, Guid taskId);
}
