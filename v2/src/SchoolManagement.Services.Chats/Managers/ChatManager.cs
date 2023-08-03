using Mapster;
using SchoolManagement.Services.Chats.Entities;
using SchoolManagement.Services.Chats.Models;
using SchoolManagement.Services.Chats.Repositories;
using System.Security.Claims;

namespace SchoolManagement.Services.Chats.Managers;

public class ChatManager : IChatManager
{
    private readonly IChatRepository _chatRepository;
    private readonly IHttpContextAccessor _contextAccessor;
    public ChatManager(IChatRepository chatRepository, IHttpContextAccessor contextAccessor)
    {
        _chatRepository = chatRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<ChatModel> CreateAnotherChat(CreateChatModel model)
    {
        var chat = new Chat()
        {
            ChatType = model.ChatType,
            Identifier = model.Identifier,
            Name = model.Name,
            Messages = new List<Message>(),
        };

        await _chatRepository.AddChat(chat);

        return chat.Adapt<ChatModel>();
    }
    public async Task<ChatModel> CreatePersonalChat(Guid currentUserId, Guid secondUserId)
    {
        var chat = new Chat()
        {
            ChatType = ChatType.Personal,
        };
        await _chatRepository.AddChat(chat);

        chat.UsersId = new List<Guid>()
        {
            currentUserId,
            secondUserId,
        };
        await _chatRepository.UpdateChat(chat);
        
        return chat.Adapt<ChatModel>();
    }

    public async Task Delete(ulong chatId)
    {
        var chat = await _chatRepository.GetChatById(chatId);
        if (chat == null)
        {
            throw new Exception("Chat not found");
        }
        await _chatRepository.DeleteChat(chat);
    }

    public async Task<List<ChatModel>> GetAllChats()
    {
        var chats = await _chatRepository.GetChats();
        if (chats == null)
        {
            return new List<ChatModel>();
        }
        var chatList = new List<ChatModel>();
        foreach (var chat in chats)
        {
            chatList.Add(chat.Adapt<ChatModel>());
        }
        return chatList;
    }

    public async Task<ChatModel> GetById(ulong chatId)
    {
        var chat = await _chatRepository.GetChatById(chatId);
        if (chat == null)
        {
            throw new Exception("Chat is not found");
        }
        return chat.Adapt<ChatModel>();
    }

    public async Task<ChatModel?> GetByIdentifier(string chatIdentifier)
    {
        var chat = await _chatRepository.GetChatByIdentifier(chatIdentifier);
        if (chat == null)
            chat = new Chat();

        return chat.Adapt<ChatModel>();
    }

    public async Task<ChatModel?> GetPersonalChatByUserId(Guid secondUserId)
    {
        var userId = Guid.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        var chat = await _chatRepository.GetPersonalChatByUserIds(Guid.NewGuid(), secondUserId);
        if (chat == null)
            chat = new Chat();

        return chat.Adapt<ChatModel>();
    }

    public async Task UpdateChat(ulong chatId, UpdateChatModel model)
    {
        var chat = await _chatRepository.GetChatById(chatId);
        if (chat == null)
        {
            throw new Exception("Chat is not found");
        }
        await _chatRepository.UpdateChat(chat);
    }
}