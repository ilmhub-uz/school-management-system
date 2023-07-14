using Sciences.API.Entities;
using Sciences.API.Models.ScienceModels;
using Sciences.API.Models.TopicModels;

namespace Sciences.API.Repositories;

public interface ITopicRepository
{
    Task<List<Topic>> GetTopics();
    Task <CreateTopicModel> AddTopic(Guid scienceId,CreateTopicModel model);
    Task UpdateTopic(Guid scienceId, Guid topicId, UpdateTopicModel model);
    Task DeleteTopic(Guid scienceId,Guid topicId);
    Task<Topic> GetTopicById(Guid scienceId,Guid topicId);
}