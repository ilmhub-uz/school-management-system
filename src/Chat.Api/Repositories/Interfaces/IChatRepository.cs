using Chat.Api.Entities;

namespace Chat.Api.Repositories.Interfaces;

public interface IChatRepository
{
    public Task<List<Entities.Chat>> GetChats();
    public Task AddChat();
    public Task GetChatById(int chatId);
    public Task UpdateChat(int chatId);
    public Task DeleteChat(int chatId);
}
