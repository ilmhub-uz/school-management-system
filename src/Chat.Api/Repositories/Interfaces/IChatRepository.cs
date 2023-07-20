namespace Chat.Api.Repositories.Interfaces;

public interface IChatRepository
{
    public Task<List<Entities.Chat>?> GetChats();
    public Task AddChat(Entities.Chat chat);
    public Task<Entities.Chat?> GetChatById(int chatId);
    public Task UpdateChat(Entities.Chat chat);
    public Task DeleteChat(Entities.Chat chat);
}
