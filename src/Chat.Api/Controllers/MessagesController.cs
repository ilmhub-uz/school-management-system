using Chat.Api.Managers.Interfaces;
using Chat.Api.Models.MessageModels;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers;

[Route("chats/{chatId}/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageManager _messageManager;
    private readonly IChatManager _chatManager;

    public MessagesController(IMessageManager messageManager, IChatManager chatManager)
    {
        _messageManager = messageManager;
        _chatManager = chatManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetMessages(int chatId)
    {
        if (await _chatManager.GetChat(chatId) == null)
            throw new Exception("Chat is not found");

        var messages = await _messageManager.GetMessagesByChatId(chatId);
        if (messages == null)
            return NotFound("Message is not found");

        return Ok(messages);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMessage(int chatId, [FromBody] CreateMessageModel createMessageModel)
    {
        if (await _chatManager.GetChat(chatId) == null)
            throw new Exception("Chat is not found");

        await _messageManager.CreateMessage(createMessageModel);

        return Ok();
    }

    [HttpPut("{messageId}")]
    public async Task<IActionResult> UpdateMessage(int chatId, [FromBody] UpdateMessageModel updateMessageModel, int messageId)
    {
        if (await _chatManager.GetChat(chatId) == null)
            throw new Exception("Chat is not found");

        await _messageManager.UpdateMessage(updateMessageModel, messageId);
        return Ok();
    }

    [HttpDelete("{messageId}")]
    public async Task<IActionResult> DeleteMessage(int chatId, int messageId)
    {
        if (await _chatManager.GetChat(chatId) == null)
            throw new Exception("Chat is not found");

        await _messageManager.DeleteMessage(messageId);

        return Ok();
    }
}
