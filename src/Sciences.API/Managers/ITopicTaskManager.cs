using Sciences.API.Models.TopicTaskModels;

namespace Sciences.API.Managers;

public interface ITopicTaskManager
{
    Task<List<TopicTaskModel>> GetTopicTasksAsync(Guid topicId, DateTime date);

    Task <TopicTaskModel> AddTopicTaskAsync(CreateTopicTaskModel task);

    Task <TopicTaskModel> UpdateTopicTaskAsync(CreateTopicTaskModel task);

    Task DeleteTopicTaskAsync(Guid topicId);
}