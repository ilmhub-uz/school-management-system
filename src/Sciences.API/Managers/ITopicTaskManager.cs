using Sciences.API.Models.TopicTaskModels;

namespace Sciences.API.Managers;

public interface ITopicTaskManager
{
    Task<List<TopicTaskModel>> GetTopicTasksAsync(Guid topicId, DateTime date);

    Task<TopicTaskModel> AddTopicTaskAsync(Guid topicId, CreateTopicTaskModel task);

    Task<TopicTaskModel> UpdateTopicTaskAsync(Guid topicId, CreateTopicTaskModel task);

    Task DeleteTopicTaskAsync(Guid topicId);
}