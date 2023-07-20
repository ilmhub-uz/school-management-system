using Chat.Api.Managers.Interfaces;
using Chat.Api.Models.ChatModels;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ChatsController : ControllerBase
{
    private readonly IChatManager _chatManager;

    public ChatsController(IChatManager chatManager)
    {
        _chatManager = chatManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] CreateChatModel createChatModel)
    {
        //davomi bor
        await _chatManager.CreateChat(createChatModel);
        return Ok();
    }

    [HttpGet("{chatId}")]
    public async Task<IActionResult> GetChat(int chatId)
    {
        var chatModel = await _chatManager.GetChat(chatId);
        if (chatModel == null)
            return BadRequest("Chat is not found");

        return Ok(chatModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetChats()
    {
        //davomi bor
        var chats = await _chatManager.GetChats();
        return Ok(chats);
    }

    [HttpPut("{chatId}")]
    public async Task<IActionResult> UpdateChats(int chatId, UpdateChatModel updateChat)
    {
        //davomi bor
        await _chatManager.UpdateChat(updateChat, chatId);
        return Ok();
    }

    [HttpDelete("{chatId}")]
    public async Task<IActionResult> DeleteChat(int chatId)
    {
        await _chatManager.DeleteChat(chatId);
        return Ok();
    }
}
