using SchoolManagement.Services.Chats.Context;
using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Repositories
{
    public interface IChatRepository
    {
        Task<List<Chat>?> GetChats();
        Task<Chat?> GetChatById(ulong chatId);
        Task<Chat?> GetChatByIdentifier(string chatIdentifier);
        Task<Chat?> GetPersonalChatByUserIds(Guid userId, Guid secondUserId);
        Task AddChat(Chat chat);
        Task DeleteChat(Chat chat);
        Task UpdateChat(Chat chat);
       
    }
}
