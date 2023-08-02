using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Chats.Managers;
using SchoolManagement.Services.Chats.Models;

namespace SchoolManagement.Services.Chats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatManager _chatManager;
        public ChatsController(IChatManager chatManager)
        {
            _chatManager = chatManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var chats = await _chatManager.GetAllChats();
            return Ok(chats);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChat([FromBody] CreateChatModel model)
        {
            try
            {
                var chat = await _chatManager.CreateAnotherChat(model);
                return Ok(chat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{chatId}")]
        public async Task<IActionResult> UpdateChat(ulong chatId, UpdateChatModel model)
        {
            try
            {
                await _chatManager.UpdateChat(chatId, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{chatId}")]
        public async Task<IActionResult> DeleteChat(ulong chatId)
        {

            try
            {
                await _chatManager.Delete(chatId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetByChatId(ulong chatId)
        {
            try
            {
               var chat = await _chatManager.GetById(chatId);
                return Ok(chat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
