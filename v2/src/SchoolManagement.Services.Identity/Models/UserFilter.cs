using SchoolManagement.Services.Identity.Helpers;

namespace SchoolManagement.Services.Identity.Models;

public class UserFilter : PaginationParams
{
    public string? UserName { get; set; }
    public DateTime? FromCreatedAt { get; set; }
    public DateTime? ToCreatedAt { get; set; }
    public string? Role { get; set; }
}