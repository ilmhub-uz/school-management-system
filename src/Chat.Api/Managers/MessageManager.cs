using Chat.Api.Entities;
using Chat.Api.Managers.Interfaces;
using Chat.Api.Models.MessageModels;
using Chat.Api.Repositories.Interfaces;
using Mapster;

namespace Chat.Api.Managers;

public class MessageManager : IMessageManager
{
    private readonly IMessageRepository _messageRepository;

    public MessageManager(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task CreateMessage(CreateMessageModel createMessage)
    {
        var message = createMessage.Adapt<Message>();

        await _messageRepository.AddMessage(message);
    }

    public async Task DeleteMessage(int id)
    {
        var message = await _messageRepository.GetMessageById(id);
        await _messageRepository.DeleteMessage(message);
    }

    public async Task<MessageModel> GetMessageById(int id)
    {
        var message = await _messageRepository.GetMessageById(id);
        var messageModel = message.Adapt<MessageModel>();
        return messageModel;
    }

    public async Task<List<MessageModel>> GetMessagesByChatId(int id)
    {
        var messages = await _messageRepository.GetMessagesByChatId(id);
        var messagesModel = messages.Adapt<List<MessageModel>>();

        return messagesModel;
    }

    public async Task<List<MessageModel>> GetMessagesByUserId(Guid userId)
    {
        var messages = await _messageRepository.GetMessagesByUserId(userId);
        var messagesModel = messages.Adapt<List<MessageModel>>();

        return messagesModel;
    }

    public async Task UpdateMessage(UpdateMessageModel updateMessage, int id)
    {
        var message = await _messageRepository.GetMessageById(id);
        message.Content = updateMessage.Content;
        message.UpdatedAt = DateTime.UtcNow;

        await _messageRepository.UpdateMessage(message);
    }
}
