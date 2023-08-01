using Mapster;
using SchoolManagement.Services.Chats.Entities;
using SchoolManagement.Services.Chats.Models;
using SchoolManagement.Services.Chats.Repositories;

namespace SchoolManagement.Services.Chats.Managers;

public class MessageManager : IMessageManager
{
    private readonly IMessageRepository _messageRepository;
    private readonly IChatManager _chatManager;

    public MessageManager(IMessageRepository messageRepository, IChatManager chatManager)
    {
        _messageRepository = messageRepository;
        _chatManager = chatManager;
    }

    public async ValueTask CreatePersonalMessage(CreateMessageModel createMessage)
    {
        var message = new Message() 
        {
            Content = createMessage.Content,
            CreatedAt = DateTime.UtcNow,
            ParentMessageId = createMessage.ParentMessageId,
            //Claimdan olish kerak
            UserId = Guid.NewGuid(),
        };

        var chat = await _chatManager.GetPersonalChatByUserId(createMessage.ToUserId!.Value);
        if (chat == null) { }
            chat = await _chatManager.CreatePersonalChat();

        message.ChatId = chat.Id;

        await _messageRepository.AddMessage(message);
    }

    public async ValueTask CreateAnotherMessage(CreateMessageModel createMessage)
    {
        var message = new Message()
        {
            Content = createMessage.Content,
            CreatedAt = DateTime.UtcNow,
            ParentMessageId = createMessage.ParentMessageId,
            //Claimdan olish kerak
            UserId = Guid.NewGuid(),
        }; 

        var chatModel = await _chatManager.GetByIdentifier(createMessage.ChatIdentifier);
        if (chatModel == null)
        {
            var createChat = new CreateChatModel()
            {
                Identifier = createMessage.ChatIdentifier,
                ChatType = ChatType.Group,
            };

            chatModel = await _chatManager.CreateAnotherChat(createChat);
        }

        message.ChatId = chatModel.Id;
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
