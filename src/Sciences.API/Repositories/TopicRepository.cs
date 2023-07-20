using Microsoft.EntityFrameworkCore;
using Sciences.API.Context;
using Sciences.API.Entities;
using Sciences.API.Exceptions;
using Sciences.API.Repositories.Interfaces;

namespace Sciences.API.Repositories;

public class TopicRepository : ITopicRepository
{

    private readonly ScienceDbContext _context;

    public TopicRepository(ScienceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Topic>> GetTopics()
    {
        return await _context.Topics.ToListAsync();
    }

    public async Task AddTopic(Topic topic)
    {
        _context.Topics.Add(topic);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTopic(Topic topic)
    {
        _context.Topics.Update(topic);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTopic(Topic topic)
    {
        _context.Topics.Remove(topic);
        await _context.SaveChangesAsync();
    }

    public async Task<Topic> GetTopicById(Guid topicId)
    {
        var topic = await _context.Topics.FirstOrDefaultAsync(t => t.Id == topicId);
        if (topic == null)
        {
            throw new TopicNotFoundException(topicId.ToString());
        }
        return topic;
    }
}