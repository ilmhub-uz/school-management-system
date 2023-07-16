namespace SchoolManagement.Common.CustomExceptions;

public class CouldNotParseStringToGuidException : Exception
{
    public CouldNotParseStringToGuidException(string userId)
        : base($"Could not parse String to Guid:  {userId}")
    { }
}