using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Repositories
{
    public interface IMessageRepository
    {
        Task<List<Message>?> GetMessages(int chatId);
        Task<Message?> GetMessageById(ulong messageId);
        Task AddMessage(Message message);
        Task DeleteMessage(Message message);
        Task UpdateMessage(Message message);
    }
}
