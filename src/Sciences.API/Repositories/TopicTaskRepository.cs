using Sciences.API.Context;
using Sciences.API.Entities;
using Sciences.API.Repositories.Interfaces;

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
        var science = await _scienceRepository.GetScienceById(scienceId);
        var topic = science.Topics.FirstOrDefault(t => t.Date == date);
        if (topic == null) throw new System.Exception("Topic Not Found");
        return 
    }

    public async Task AddTopicTask(Guid scienceId, DateTime date)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateTopicTask(Guid scienceId, DateTime date, Guid taskId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteTopicTask(Guid scienceId, DateTime date, Guid taskId)
    {
        throw new NotImplementedException();
    }
}