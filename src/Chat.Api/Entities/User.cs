namespace Chat.Api.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string UserName { get; set; }
    public required string PhoneNumber { get; set; }
    public string? AvatarPath { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public EStatus Status { get; set; }
    public List<Message>? Messages { get; set; }
}
