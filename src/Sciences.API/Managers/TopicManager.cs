using Sciences.API.Entities;
using Sciences.API.Models.TopicModels;
using Sciences.API.ParseHelper;
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
        return ParseService.ParseToTopicList(topics);
    }

    public async Task<TopicModel> AddTopicAsync(Guid scienceId, CreateTopicModel topic)
    {
        var model = new Topic()
        {
            Name = topic.Name,
            Title = topic.Title,
            ScienceId = scienceId,
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
        };
        await _topicRepository.AddTopic(model);
        return ParseService.ParseToTopicModel(model);
    }

    public async Task<TopicModel> UpdateTopicAsync(Guid topicId, UpdateTopicModel topic)
    {
        var model = await _topicRepository.GetTopicById(topicId);

        model.Name = topic.Name;
        model.Title = topic.Title;
        await _topicRepository.UpdateTopic(model);
        return ParseService.ParseToTopicModel(model);

    }

    public async Task DelateTopicAsync(Guid topicId)
    {
        var model = await _topicRepository.GetTopicById(topicId);
        await _topicRepository.DeleteTopic(model);

    }

    public async Task<TopicModel> GetTopicByIdAsync(Guid topicId)
    {
        var topic = await _topicRepository.GetTopicById(topicId);
        return ParseService.ParseToTopicModel(topic);
    }


}