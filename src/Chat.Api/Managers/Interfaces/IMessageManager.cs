using Chat.Api.Models.MessageModels;

namespace Chat.Api.Managers.Interfaces;

public interface IMessageManager
{
    public Task<MessageModel> GetMessageById(int id);
    public Task<List<MessageModel>> GetMessagesByChatId(int id);
    public Task CreateMessage(CreateMessageModel createMessage);
    public Task DeleteMessage(int id);
    public Task UpdateMessage(UpdateMessageModel updateMessage, int id);
}
