using Microsoft.EntityFrameworkCore;
using Sciences.API.Context;
using Sciences.API.Entities;

namespace Sciences.API.Repositories.ClassRepositories;

public class TopicRepository : ITopicRepository
{
    private readonly ScienceDbContext _context;

    public TopicRepository(ScienceDbContext context)
    {
        _context = context;
    }
    public async Task<List<Topic>> GetTopics(Guid scienceId)
    {
        var sciences = await _context.Sciences.Where(i => i.Id == scienceId).
            Include(i=>i.Topics)
            .FirstOrDefaultAsync();
        var topics = sciences!.Topics;
        return topics!;
    }

    public async Task AddTopic(Topic topic)
    {
        await _context.Topics.AddAsync(topic);
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

    public async Task<Topic> GetTopicById( Guid Id)
    {
        var topic = await _context.Topics.Where(t => t.Id == Id).FirstOrDefaultAsync();
        return topic!;
    }
}