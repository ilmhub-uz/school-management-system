using Sciences.API.Entities;
using Sciences.API.Models.ScienceModels;
using Sciences.API.Models.TopicModels;

namespace Sciences.API.Repositories;

public interface ITopicRepository
{
    Task<List<Topic>> GetTopics(Guid scienceId);
    Task AddTopic(Guid scienceId, Topic topic);
    Task UpdateTopic(Guid scienceId,Topic topic);
    Task DeleteTopic(Guid scienceId,Topic topic);
    Task<Topic> GetTopicById(Guid scienceId,Guid Id);
}