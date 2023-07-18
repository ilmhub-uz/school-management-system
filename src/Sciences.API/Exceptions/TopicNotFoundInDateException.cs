namespace Sciences.API.Exceptions;

public class TopicNotFoundInDateException : System.Exception
{
    public TopicNotFoundInDateException(string dateTime) : base($"Topic not found in this date:{dateTime}")
    {
        
    }
}