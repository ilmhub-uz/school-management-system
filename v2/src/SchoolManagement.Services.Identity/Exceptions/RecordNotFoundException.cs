namespace SchoolManagement.Services.Identity.Exceptions;

public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(string record = "Record") : base($"{record} not found") { }
}