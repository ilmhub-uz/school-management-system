namespace SchoolManagement.Common.Interfaces;

public interface IUserProvider
{
    Guid GetUserIdAsync();
    string GetUsernameAsync();
}