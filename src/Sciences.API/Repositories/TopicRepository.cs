using Microsoft.EntityFrameworkCore;
using Sciences.API.Context;
using Sciences.API.Entities;
using Sciences.API.Repositories.Interfaces;

namespace Sciences.API.Repositories;

public class TopicRepository:ITopicRepository
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

    public Task UpdateTopic(Topic topic)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTopic(Topic topic)
    {
        throw new NotImplementedException();
    }

    public Task<Topic> GetTopicById(Guid topicId)
    {
        throw new NotImplementedException();
    }
}