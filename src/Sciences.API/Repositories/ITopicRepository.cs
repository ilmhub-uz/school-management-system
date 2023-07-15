using Sciences.API.Entities;
using Sciences.API.Models.ScienceModels;
using Sciences.API.Models.TopicModels;

namespace Sciences.API.Repositories;

public interface ITopicRepository
{
    Task<List<TopicModel>> GetTopics();
    Task <TopicModel> AddTopic(Guid scienceId,CreateTopicModel model);
    Task UpdateTopic(Guid scienceId, Guid topicId, CreateTopicModel model);
    Task DeleteTopic(Guid scienceId,Guid topicId);
    Task<TopicModel> GetTopicById(Guid scienceId,Guid topicId);
}