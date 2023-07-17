using Sciences.API.Models.TopicTaskModels;

namespace Sciences.API.Models.TopicModels;

public class TopicModel
{
    
    public  Guid Id { get; set; }
    public  DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public  string Name { get; set; }
    public  string Title { get; set; }
    public DateTime? Date { get; set; }
    public  Guid ScienceId { get; set; }
    public List<TopicTaskModel> Tasks { get; set; }
}