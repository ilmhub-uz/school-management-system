using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Chats.Managers;
using SchoolManagement.Services.Chats.Models;

namespace SchoolManagement.Services.Chats.Controllers;

[Route("chats/{chatId}/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageManager _messageManager;

    public MessagesController(IMessageManager messageManager)
    {
        _messageManager = messageManager;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetMessages(int chatId)
    {
        var messages = await _messageManager.GetMessages(chatId);
        
        return Ok(messages);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateMessage(CreateMessageModel createMessage)
    {
        try
        {
            if (createMessage.ToUserId != null)
            {
                await _messageManager.CreatePersonalMessage(createMessage);
                return Ok();
            }
            else
            {
                await _messageManager.CreateAnotherMessage(createMessage);
                return Ok();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{messageId}")]
    public async ValueTask<IActionResult> UpdateMessage(UpdateMessageModel updateMessage, ulong messageId)
    {
        try
        {
            await _messageManager.UpdateMessage(updateMessage, messageId);
            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{messageId}")]
    public async ValueTask<IActionResult> DeleteMessage(ulong messageId)
    {
        try
        {
            await _messageManager.DeleteMessage(messageId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
