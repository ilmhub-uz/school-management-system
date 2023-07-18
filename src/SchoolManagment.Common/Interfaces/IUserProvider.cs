namespace SchoolManagement.Common.Interfaces;

public interface IUserProvider
{
    Guid GetUserId();
    string GetUsername();
}