using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Chats.Context;
using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        private readonly ChatsDbContext _context;

        public MessageRepository(ChatsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Message>?> GetMessages(ulong chatId)
        {
            return await _context.Messages.Where(m => m.ChatId == chatId).ToListAsync();
        }

        public async Task<Message?> GetMessageById(ulong messageId)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == messageId);
            return message;
        }

        public async Task AddMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
        }
    }
}
