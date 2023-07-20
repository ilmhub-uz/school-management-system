using Chat.Api.Context;
using Chat.Api.Entities;
using Chat.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly ChatDbContext _context;

    public MessageRepository(ChatDbContext context)
    {
        _context = context;
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

    public async Task<Message?> GetMessageById(int id)
    {
        var message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);

        return message;
    }

    public async Task<List<Message>?> GetMessagesByChatId(int chatId)
    {
        var messages = await _context.Messages.Where(m => m.ChatId == chatId).ToListAsync();
        return messages;
    }


    public async Task UpdateMessage(Message message)
    {
        _context.Messages.Update(message);
        await _context.SaveChangesAsync();
    }
}
