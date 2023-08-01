using Mapster;
using Microsoft.AspNetCore.SignalR;
using SchoolManagement.Services.Chats.Entities;
using SchoolManagement.Services.Chats.Hubs;
using SchoolManagement.Services.Chats.Models;
using SchoolManagement.Services.Chats.Repositories;
using System.Security.Claims;

namespace SchoolManagement.Services.Chats.Managers;

public class MessageManager : IMessageManager
{
    private readonly IMessageRepository _messageRepository;
    private readonly IChatManager _chatManager;
    private readonly IHubContext<ChatHub> _hubContext;
    private readonly IHttpContextAccessor _contextAccessor;

    public MessageManager(IMessageRepository messageRepository, IChatManager chatManager, IHubContext<ChatHub> hubContext, IHttpContextAccessor contextAccessor)
    {
        _messageRepository = messageRepository;
        _chatManager = chatManager;
        _hubContext = hubContext;
        _contextAccessor = contextAccessor;
    }

    public async ValueTask CreatePersonalMessage(CreateMessageModel createMessage)
    {
        var userId = Guid.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        var message = new Message() 
        {
            Content = createMessage.Content,
            CreatedAt = DateTime.UtcNow,
            ParentMessageId = createMessage.ParentMessageId,
            UserId = userId,
        };

        var chat = await _chatManager.GetPersonalChatByUserId(createMessage.ToUserId!.Value);
        if (chat == null) { }
            chat = await _chatManager.CreatePersonalChat(Guid.NewGuid(), createMessage.ToUserId.Value);

        message.ChatId = chat.Id;

        await _messageRepository.AddMessage(message);
        await _hubContext.Clients.Users(chat.UserChats.Select(u => u.UserId).ToString()).SendAsync("NewMessage", message.Adapt<MessageModel>());
    }

    public async ValueTask CreateAnotherMessage(CreateMessageModel createMessage)
    {
        var userId = Guid.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        var message = new Message()
        {
            Content = createMessage.Content,
            CreatedAt = DateTime.UtcNow,
            ParentMessageId = createMessage.ParentMessageId,
            UserId = userId,
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
        await _hubContext.Clients.All.SendAsync($"{chatModel.Identifier}", message.Adapt<MessageModel>());
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
        if (messages == null)
            messages = new List<Message>();

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
