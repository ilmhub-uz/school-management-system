using SchoolManagement.Services.Chats.Models;

namespace SchoolManagement.Services.Chats.Managers;

public interface IChatManager
{
    Task<List<ChatModel>> GetAllChats();
    Task<ChatModel> CreateAnotherChat(CreateChatModel model);
    Task<ChatModel> CreatePersonalChat(Guid currentUserId, Guid secondUserId);
    Task<ChatModel?> GetPersonalChatByUserId(Guid userId);
    Task<ChatModel> GetById(ulong chatId);
    Task<ChatModel?> GetByIdentifier(string chatIdentifier);
    Task UpdateChat(ulong chatId, UpdateChatModel model);
    Task Delete(ulong chatId);


        

}
