using Sciences.API.Entities;

namespace Sciences.API.Repositories.Interfaces;

public interface ITopicRepository
{
    Task<List<Topic>> GetTopics();
    Task AddTopic( Topic topic);
    Task UpdateTopic(Topic topic);
    Task DeleteTopic( Topic topic);
    Task<Topic> GetTopicById( Guid topicId);
}