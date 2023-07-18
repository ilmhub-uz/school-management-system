namespace Sciences.API.Exceptions;

public class TopicTaskNotFoundException : System.Exception
{
    public TopicTaskNotFoundException(string topicTaskId) : base($"Topic not found with id :{topicTaskId}")
    {
        
    }
}