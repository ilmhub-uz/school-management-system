using SchoolManagement.Services.Identity.Entities;

namespace SchoolManagement.Services.Identity.Managers;

public interface ITokenManager
{
    (string, double) GenerateToken(User user);
}