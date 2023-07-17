using Sciences.API.Entities;
using Sciences.API.Models.TopicTaskModels;
using Sciences.API.ParseHelper;
using Sciences.API.Repositories.Interfaces;

namespace Sciences.API.Managers;

public class TopicTaskManager
{
    private readonly ITopicTaskRepository _taskRepository;

    public TopicTaskManager(ITopicTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<List<TopicTask>> GetTopicTasks(Guid scienceId, DateTime date)
    {
        return await _taskRepository.GetTopicTasks(scienceId, date);    
    }

    public async Task<TopicTaskModel> AddTopicTask(Guid scienceId, DateTime date, CreateTopicTaskModel model)
    {
        var task = new TopicTask()
        {
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
            Title = model.Title,
            Content = model.Content,
            Description = model.Description,
            TopicId = model.TopicId
        };
        await _taskRepository.AddTopicTask(scienceId,date,task);
        return ParseService.ParseTopicTaskModel(task);

    }

    public async Task<TopicTaskModel> UpdateTopicTask(Guid scienceId, DateTime date, Guid taskId,CreateTopicTaskModel model)
    {
        var task = await _taskRepository.GetTopicTaskById(scienceId, date, taskId);
        task.Title = model.Title;
        task.Content = model.Content;
        task.Description = model.Description;
        await _taskRepository.UpdateTopicTask(task);
        return ParseService.ParseTopicTaskModel(task);
    }

    public async Task<string> DeleteTopicTask(Guid scienceId, DateTime date, Guid taskId)
    {
         await _taskRepository.DeleteTopicTask(scienceId,date,taskId);
         return "Topic task deleted";
    }


}