using Chat.Api.Managers.Interfaces;
using Chat.Api.Models.ChatModels;
using Chat.Api.Models.MessageModels;
using Chat.Api.Repositories.Interfaces;
using Mapster;

namespace Chat.Api.Managers;

public class ChatManager : IChatManager
{
    private readonly IChatRepository _chatRepository;

    public ChatManager(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task CreateChat(CreateChatModel createChat)
    {
        var chat = createChat.Adapt<Entities.Chat>();
        await _chatRepository.AddChat(chat);
    }

    public async Task DeleteChat(int chatId)
    {
        var chat = await _chatRepository.GetChatById(chatId);
        await _chatRepository.DeleteChat(chat);
    }

    public async Task<ChatModel?> GetChat(int chatId)
    {
        var chat = await _chatRepository.GetChatById(chatId);
        var chatModel = chat.Messages.Adapt<MessageModel>().Adapt<ChatModel>();
        return chatModel;
    }

    public async Task<List<ChatModel>> GetChats()
    {
        var chats = await _chatRepository.GetChats();
        return chats.Adapt<List<ChatModel>>();
    }

    public async Task UpdateChat(UpdateChatModel updateChat, int chatId)
    {
        var chat = await _chatRepository.GetChatById(chatId);
        chat.Name = updateChat.Name;
        await _chatRepository.UpdateChat(chat);
    }
}
