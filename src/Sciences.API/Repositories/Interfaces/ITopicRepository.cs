using Sciences.API.Entities;

namespace Sciences.API.Repositories.Interfaces;

public interface ITopicRepository
{
    Task<List<Topic>> GetTopics(Guid scienceId);
    Task AddTopic(Guid scienceId, Topic topic);
    Task UpdateTopic(Guid scienceId, Topic topic);
    Task DeleteTopic(Guid scienceId, Topic topic);
    Task<Topic> GetTopicById(Guid scienceId, Guid topicId);
}