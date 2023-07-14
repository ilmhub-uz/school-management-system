using Sciences.API.Entities;
using Sciences.API.Models.ScienceModels;
using Sciences.API.Models.TopicModels;

namespace Sciences.API.Repositories;

public interface ITopicRepository
{
    Task<List<Topic>> GetTopics();
    Task AddTopic(CreateTopicModel model);
    Task UpdateTopic(Guid scienceId, UpdateTopicModel model);
    Task DeleteTopic(Guid topicId);
    Task<Science> GetTopicById(Guid topicId);
}