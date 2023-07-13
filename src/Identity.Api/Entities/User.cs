namespace Identity.Api.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }
    public required string UserName { get; set; }
}
