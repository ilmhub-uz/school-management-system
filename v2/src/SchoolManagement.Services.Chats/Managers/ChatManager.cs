using Mapster;
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

    public async Task<ChatModel> AddChat(CreateChatModel model)
    {
        var chat = new Chat()
        {
            ChatType = model.ChatType,
            Identifier = model.Identifier,
            Name = model.Name,
            Messages = new List<Message>(),
            Users = new List<User>(),
        };
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
            throw new Exception("Chat not found");
        }
        return chat.Adapt<ChatModel>();
    }

    public async Task UpdateChat(ulong chatId, UpdateChatModel model)
    {
        var chat = await _chatRepository.GetChatById(chatId);
        if (chat == null)
        {
            throw new Exception("Chat not found");
        }
        await _chatRepository.UpdateChat(chat);
    }
}