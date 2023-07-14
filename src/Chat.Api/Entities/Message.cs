namespace Chat.Api.Entities;

public class Message
{
    public required  int Id { get; set; }
    public required int ChatId { get; set; }
    public Chat? Chat { get; set; }  
    public required Guid UserId { get; set; }
    public User? User { get; set; }  
    public string? Text { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set;}
}
