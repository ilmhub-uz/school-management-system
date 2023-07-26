using SchoolManagement.Services.Chats.Models;

namespace SchoolManagement.Services.Chats.Managers;

public interface IChatManager
{
    Task<List<ChatModel>> GetAllChats();
    Task<ChatModel> AddChat(CreateChatModel model);
    Task<ChatModel> GetById(ulong chatId);
    Task UpdateChat(ulong chatId, UpdateChatModel model);
    Task Delete(ulong chatId);


        

}
