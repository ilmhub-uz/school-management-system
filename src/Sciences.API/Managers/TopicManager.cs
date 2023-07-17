using Sciences.API.Models.TopicModels;
using Sciences.API.Repositories.Interfaces;

namespace Sciences.API.Managers;

public class TopicManager
{
    private readonly ITopicRepository _topicRepository;

    public TopicManager(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<List<TopicModel>> GetTopicsAsync()
    {
        var topics = await _topicRepository.GetTopics();
        if (topics == null || topics.Count == 0)
        {
            return new List<TopicModel>();
        }

    }
}