using Mapster;
using SchoolManagement.Services.Chats.Entities;
using SchoolManagement.Services.Chats.Models;
using SchoolManagement.Services.Chats.Repositories;

namespace SchoolManagement.Services.Chats.Managers;

public class MessageManager : IMessageManager
{
    private readonly IMessageRepository _messageRepository;

    public MessageManager(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async ValueTask CreateMessage(CreateMessageModel createMessage)
    {
        var message = new Message() 
        {
            Content = createMessage.Content,
            CreatedAt = DateTime.UtcNow,
            ParentMessageId = createMessage.ParentMessageId,
            UserId = createMessage.UserId,
        };

        await _messageRepository.AddMessage(message);
    }

    public async ValueTask DeleteMessage(ulong messageId)
    {
        var message = await _messageRepository.GetMessageById(messageId);
        if (message == null)
            throw new Exception("Message is not found!");

        await _messageRepository.DeleteMessage(message);
    }

    public async ValueTask<List<MessageModel>?> GetMessages(int chatId)
    {
        var messages = await _messageRepository.GetMessages(chatId);
        
        return messages.Adapt<List<MessageModel>>();
    }

    public async ValueTask UpdateMessage(UpdateMessageModel updateMessage, ulong messageId)
    {
        var message = await _messageRepository.GetMessageById(messageId);
        if (message == null)
            throw new Exception("Message is not found");

        message.Content = updateMessage.Content;
        message.UpdatedAt = DateTime.UtcNow;
        
        await _messageRepository.UpdateMessage(message);
    }
}
