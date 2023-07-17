using Sciences.API.Entities;
using Sciences.API.Models.ScienceModels;
using Sciences.API.Models.TopicModels;
using Sciences.API.Models.TopicTaskModels;

namespace Sciences.API.ParseHelper;

public class ParseService
{
    public static ScienceModel ParseToScienceModel(Science science)
    {
        var model = new ScienceModel()
        {
            Id = science.Id,
            Name = science.Name,
            Description = science.Description,
            CreatedAt = science.CreatedAt,
            Title = science.Title,
            UpdatedAt = science.UpdatedAt,
            Topics = ParseToTopicList(science.Topics)
        };
        return model;
    }

    public static List<ScienceModel> ParseToScienceList(List<Science>? sciences)
    {
        if (sciences == null || sciences.Count == 0)
        {
            return new List<ScienceModel>();
        }
        else
        {
            var list = new List<ScienceModel>();
            foreach (var science in sciences)
            {
                list.Add(ParseToScienceModel(science));
            }
            return list;
        }
    }

    public static TopicModel ParseToTopicModel(Topic topic)
    {
        var model = new TopicModel()
        {
            Id = topic.Id,
            CreatedAt = topic.CreatedAt,
            Name = topic.Name,
            Date = topic.Date,
            ScienceId = topic.ScienceId,
            Title = topic.Title,
            UpdatedAt = topic.UpdatedAt
        };
        return model;
    }

    public static List<TopicModel> ParseToTopicList(List<Topic>? models)
    {
        if (models == null || models.Count == 0)
        {
            return new List<TopicModel>();
        }
        else
        {
            var list = new List<TopicModel>();
            foreach (var model in models)
            {
                list.Add(ParseToTopicModel(model));
            }
            return list;
        }
        
    }

    public static TopicTaskModel ParseTopicTaskModel(TopicTask model)
    {
        return new TopicTaskModel()
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Title = model.Title,
            Content = model.Content,
            Description = model.Description,
            Topic = ParseToTopicModel(model.Topic!),
            TopicId = model.TopicId
        };
    }

    public static List<TopicTaskModel> ParseList(List<TopicTask> models)
    {
        var topicModels = new List<TopicTaskModel>();

        foreach (var model in models)
        {
            topicModels.Add(ParseTopicTaskModel(model));
        }
        return topicModels;
    }

}