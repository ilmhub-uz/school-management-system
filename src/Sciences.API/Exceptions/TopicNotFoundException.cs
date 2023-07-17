namespace Sciences.API.Exceptions;

public class TopicNotFoundException:System.Exception
{
    public TopicNotFoundException(string message) : base($"Topic Not FOUND with id: {message}")
    {

    }
}