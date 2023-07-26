using SchoolManagement.Services.Chats.Entities;
using SchoolManagement.Services.Chats.Models;
using SchoolManagement.Services.Chats.Repositories;

namespace SchoolManagement.Services.Chats.Managers;

public class ChatManager : IChatManager
{
    private readonly IChatRepository _chatRepository;
    public ChatManager(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public Task<ChatModel> AddChat(CreateChatModel model)
    {
        var chat = new Chat()
        {
            ChatType= model.ChatType,
            Identifier=model.Identifier,
            Name=model.Name,
            Messages = new List<Message>(),
            Users= new List<User>(),
        };
        return chat.Select(e => e.Adapt<ChatModel>());
    }

    public Task Delete(ulong chatId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ChatModel>> GetAllChats()
    {
        throw new NotImplementedException();
    }

    public Task<ChatModel> GetById(ulong chatId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateChat(ulong chatId, UpdateChatModel model)
    {
        throw new NotImplementedException();
    }
}
