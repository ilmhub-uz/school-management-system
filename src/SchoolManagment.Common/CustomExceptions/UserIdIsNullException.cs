namespace SchoolManagement.Common.CustomExceptions;

public class UserIdIsNullException : Exception
{
    public UserIdIsNullException()
        : base(" UserId is null!")
    { }
}