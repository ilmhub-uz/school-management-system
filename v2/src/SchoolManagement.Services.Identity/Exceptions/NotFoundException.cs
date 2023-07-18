namespace SchoolManagement.Services.Identity.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string record = "Record") : base($"{record} not found") { }
}