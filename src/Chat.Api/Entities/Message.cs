namespace Chat.Api.Entities;

public class Message
{
    public int Id { get; set; }
    public required int ChatId { get; set; }
    public Chat? Chat { get; set; }  
    public required Guid UserId { get; set; }
    public User? User { get; set; }  
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set;}
}
