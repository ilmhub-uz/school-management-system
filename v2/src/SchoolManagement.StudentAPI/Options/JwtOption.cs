namespace SchoolManagement.StudentAPI.Options;

public class JwtOption
{
    public required string SigningKey { get; set; }
    public required string ValidAudience { get; set; }
    public required string ValidIssuer { get; set; }
    public required int ExpiresInSeconds { get; set; }
}