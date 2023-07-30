using SchoolManagement.Services.Chats.Models;

namespace SchoolManagement.Services.Chats.Managers;

public interface IMessageManager
{
    public ValueTask<List<MessageModel>?> GetMessages(int chatId);
    public ValueTask CreateMessage(CreateMessageModel createMessage);
    public ValueTask UpdateMessage(UpdateMessageModel updateMessage, ulong messageId);
    public ValueTask DeleteMessage(ulong messageId);
}
