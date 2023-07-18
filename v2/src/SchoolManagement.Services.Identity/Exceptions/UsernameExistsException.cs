namespace SchoolManagement.Services.Identity.Exceptions;

public class UsernameExistsException : Exception
{
    public UsernameExistsException() : base("Username already exists.")
    {

    }
}