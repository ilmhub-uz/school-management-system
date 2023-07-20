namespace SchoolManagement.Services.Identity.Exceptions;

public class LoginValidationException : Exception
{
    public LoginValidationException() : base("Username or password is incorrect") { }
}