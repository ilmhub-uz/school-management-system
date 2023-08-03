using Microsoft.EntityFrameworkCore;
using SchoolManagement.Services.Chats.Context;
using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly ChatsDbContext _context;
    public ChatRepository(ChatsDbContext context)
    {
        _context = context;
    }
    public async Task<List<Chat>?> GetChats()
    {
        var chats = await _context.Chats.ToListAsync();
        if (chats is null || chats.Count == 0)
        {
            return new List<Chat>();
        }
        return chats;
    }
    public async Task<Chat?> GetChatById(ulong chatId)
    {
        var chat = await _context.Chats.FirstOrDefaultAsync(u => u.Id == chatId);
        return chat;
    }
    public async Task<Chat?> GetChatByIdentifier(string chatIdentifier)
    {
        var chat = await _context.Chats.FirstOrDefaultAsync(u => u.Identifier == chatIdentifier);
        return chat;
    }

    public async Task AddChat(Chat chat)
    {
        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteChat(Chat chat)
    {
        _context.Chats.Remove(chat);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateChat(Chat chat)
    {
        _context.Chats.Update(chat);
        await _context.SaveChangesAsync();
    }

    public async Task<Chat?> GetPersonalChatByUserIds(Guid userId, Guid secondUserId)
    {
        var chat = await _context.Chats
            .Where(c => c.ChatType == ChatType.Personal)
            .FirstOrDefaultAsync(c => c.UsersId.Contains(userId) && c.UsersId.Contains(secondUserId));

        return chat;
    }
}
