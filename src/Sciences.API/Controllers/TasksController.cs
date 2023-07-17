using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sciences.API.Managers;
using Sciences.API.Models.TopicTaskModels;

namespace Sciences.API.Controllers
{
    [Route("api/sciences/{scienceId}/topics/{date}[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // BU shunchaki birinchi versiya xato va kamchiliklari keyingi versiyada jamoamiz bilan to'grilanadi
        private readonly ITopicTaskManager _taskManager;

        public TasksController(ITopicTaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        [HttpGet("{topicId}")]
        public async Task<IActionResult> GetTasks(Guid topicId, DateTime date)
        {
            await _taskManager.GetTopicTasksAsync(topicId, date);
            return Ok();
        }

        [HttpPost("{topicId}")]
        public async Task<IActionResult> AddTask(Guid topicId, CreateTopicTaskModel model)
        {
            await _taskManager.AddTopicTaskAsync(topicId,model);
            return Ok();
        }

        [HttpPut("{topicId}")]
        public async Task<IActionResult> UpdateTask(Guid topicId, CreateTopicTaskModel model)
        {
            await _taskManager.UpdateTopicTaskAsync(topicId,model); 
            return Ok();
        }

        [HttpDelete("{topicId}")]
        public async Task<IActionResult> DelateTask(Guid topicId)
        {
            await _taskManager.DeleteTopicTaskAsync(topicId);
            return Ok();
        }
    }
}
