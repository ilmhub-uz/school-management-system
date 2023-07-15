using Chat.Api.Context;
using Chat.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly ChatDbContext _context;

    public ChatRepository(ChatDbContext context)
    {
        _context = context;
    }

    public async Task AddChat(Entities.Chat chat)
    {
        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteChat(Entities.Chat chat)
    {
        _context.Chats.Remove(chat);
        await _context.SaveChangesAsync();
    }

    public async Task<Entities.Chat?> GetChatById(int chatId)
    {
        var chat = await _context.Chats.FirstOrDefaultAsync(c => c.Id == chatId);
        return chat;
    }

    public async Task<List<Entities.Chat>?> GetChats()
    {
        //hozircha shu holatda qolib turadi va keyinchalik vaziyatga qarab ozgartiriladi
        var chats = await _context.Chats.ToListAsync();
        return chats;
    }

    public async Task UpdateChat(Entities.Chat chat)
    {
        _context.Update(chat);
        await _context.SaveChangesAsync();
    }
}
