using Sciences.API.Context;
using Sciences.API.Entities;
using Sciences.API.Exceptions;
using Sciences.API.Repositories.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sciences.API.Repositories;

public class TopicTaskRepository: ITopicTaskRepository
{
    private readonly ScienceDbContext _context;
    private readonly IScienceRepository _scienceRepository;
    private readonly ITopicTaskRepository _taskRepository;

    public TopicTaskRepository(ScienceDbContext context, ITopicTaskRepository taskRepository, IScienceRepository scienceRepository)
    {
        _context = context;
        _taskRepository = taskRepository;
        _scienceRepository = scienceRepository;
    }

    public async Task<List<TopicTask>> GetTopicTasks(Guid scienceId, DateTime date)
    {
        var topic = await GetTopicByDate(scienceId,date);
        return topic.Tasks.ToList();
    }

    public async Task AddTopicTask(Guid scienceId, DateTime date,TopicTask task)
    {
        var topic = await GetTopicByDate(scienceId, date);
        topic.Tasks.Add(task);
        await _context.SaveChangesAsync();

    }

    public async Task UpdateTopicTask(Guid scienceId, DateTime date, TopicTask task)
    {
        await GetTopicByDate(scienceId, date);
        _context.TopicTasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTopicTask(Guid scienceId, DateTime date, Guid taskId)
    {
        var topic = await GetTopicByDate(scienceId, date);
        var task = topic.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null) 
            throw new TopicNotFoundException(taskId.ToString());
        _context.TopicTasks.Remove(task);
        await _context.SaveChangesAsync();
    }

    private async Task<Topic> GetTopicByDate(Guid scienceId, DateTime date)
    {
        var science = await _scienceRepository.GetScienceById(scienceId);
        var topic = science.Topics!.FirstOrDefault(t => t.Date == date);
        if (topic == null)
            throw new TopicNotFoundInDateException(date.ToString("M"));
        return topic;
    }
}