using Sciences.API.Entities;
using Sciences.API.Models.ScienceModels;
using Sciences.API.Models.TopicModels;

namespace Sciences.API.Repositories;

public interface ITopicRepository
{
    Task<List<Topic>> GetTopics();
    Task AddTopic(Topic topic);
    Task UpdateTopic(Topic topic);
    Task DeleteTopic(Topic topic);
    Task<Topic> GetTopicById(Guid Id);
}