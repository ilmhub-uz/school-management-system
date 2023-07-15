using Chat.Api.Entities;

namespace Chat.Api.Repositories.Interfaces;

public interface IMessageRepository
{
    public Task AddMessage(Message message);
    public Task UpdateMessage(Message message);
    public Task DeleteMessage(Message message);
    public Task<Message?> GetMessageById(int id);
    public Task<List<Message>?> GetMessagesByChatId(int chatId);
    public Task<List<Message>?> GetMessagesByUserId(Guid userId);
}
