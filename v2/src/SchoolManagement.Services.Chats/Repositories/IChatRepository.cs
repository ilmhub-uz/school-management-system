using SchoolManagement.Services.Chats.Context;
using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Repositories
{
    public interface IChatRepository
    {
        Task<List<Chat>?> GetChats();
        Task<Chat?> GetChatById(ulong chatId);
        Task AddChat(Chat chat);
        Task DeleteChat(Chat chat);
        Task UpdateChat(Chat chat);
       
    }
}
