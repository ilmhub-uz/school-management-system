using Chat.Api.Models.ChatModels;

namespace Chat.Api.Managers.Interfaces;

public interface IChatManager
{
    public Task CreateChat(CreateChatModel createChat);
    public Task<ChatModel?> GetChat(int chatId);
    public Task UpdateChat(UpdateChatModel updateChat, int chatId);
    public Task DeleteChat(int chatId);
    public Task<List<ChatModel>?> GetChats();
}
