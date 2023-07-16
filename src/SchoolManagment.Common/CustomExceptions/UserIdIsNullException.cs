namespace SchoolManagement.Common.CustomExceptions;

internal class UserIdIsNullException : Exception
{
    public UserIdIsNullException()
        : base(" UserId is null!")
    {
        
    }
}