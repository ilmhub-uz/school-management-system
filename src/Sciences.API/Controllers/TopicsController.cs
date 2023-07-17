using Microsoft.AspNetCore.Mvc;
using Sciences.API.Managers;
using Sciences.API.Models.TopicModels;

namespace Sciences.API.Controllers
{
    [Route("api/sciences/{scienceId}/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly TopicManager _topicManager;

        public TopicsController(TopicManager topicManager)
        {
            _topicManager = topicManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetTopics()
        {
            var topics = await _topicManager.GetTopicsAsync();
            return Ok(topics);
        }

        [HttpPost("{scienceId}")]
        public async Task<IActionResult> AddTopic(Guid scienceId, CreateTopicModel model)
        {
            var topic = await _topicManager.AddTopicAsync(scienceId, model);
            return Ok(topic);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateTopic(Guid topicId, UpdateTopicModel model)
        {
            var topic = await _topicManager.UpdateTopicAsync(topicId, model);
            return Ok(topic);
        }

        [HttpDelete("{topicId}")]
        public async Task<IActionResult> DelateTopic(Guid topicId)
        {
            await _topicManager.DelateTopicAsync(topicId);
            return Ok();
        }
    }
}