using Microsoft.EntityFrameworkCore;
using Sciences.API.Context;
using Sciences.API.Entities;
using Sciences.API.Models.TopicTaskModels;
using Sciences.API.ParseHelper;

namespace Sciences.API.Managers;

public class TopicTaskManager:ITopicTaskManager
{
    private readonly ScienceDbContext _context;

    public TopicTaskManager(ScienceDbContext context)
    {
        _context = context;
    }

    public async Task<List<TopicTaskModel>> GetTopicTasksAsync(Guid topicId, DateTime date)
    {
        var topicTasks = await _context.TopicTasks
            .Where(t => t.TopicId == topicId && t.CreatedAt == date)
            .ToListAsync();

        return ParseService.ParseToTopicTaskList(topicTasks);
    }

    public async Task <TopicTaskModel>AddTopicTaskAsync(Guid topicId, CreateTopicTaskModel task)
    {
        var topicTask = new TopicTask
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Title = task.Title,
            TopicId = topicId,
            Content = task.Content,
            Description = task.Description,

        };
        _context.TopicTasks.Add(topicTask);
        await _context.SaveChangesAsync();
        return ParseService.ParseToTopicTaskModel(topicTask);

    }

    public async Task<TopicTaskModel> UpdateTopicTaskAsync(Guid topicId, CreateTopicTaskModel task)
    {
        var topicTask = IsExists(topicId);
        topicTask.Title = task.Title;
        topicTask.Content = task.Content;
        topicTask.Description = task.Description;
        await _context.SaveChangesAsync();
        return ParseService.ParseToTopicTaskModel(topicTask);
    }

    public async Task DeleteTopicTaskAsync(Guid topicId)
    { 
        var topicTask = IsExists(topicId);
        _context.TopicTasks.Remove(topicTask);
       await _context.SaveChangesAsync();

    }

    
    private TopicTask IsExists(Guid topicId)
    {
        var topicTask = _context.TopicTasks.FirstOrDefault(t => t.TopicId == topicId);
        if (topicTask == null)
            throw new System.Exception("NOT FOUND");
        return topicTask;

    }
}