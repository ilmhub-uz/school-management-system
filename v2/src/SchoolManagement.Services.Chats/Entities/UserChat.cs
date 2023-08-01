namespace SchoolManagement.Services.Chats.Entities;

public class UserChat
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public ulong ChatId { get; set; }
    public Chat? Chat { get; set; }
}
