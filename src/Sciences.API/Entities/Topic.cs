namespace Sciences.API.Entities
{
    public class Topic
    {
            public Guid Id { get; set; }
            public required string Name { get; set; }
            public Guid ScienceId { get; set; }
            public DateTime Created_At { get; set; } = DateTime.Now;
            public DateTime? Updated_At { get; set; }
            public DateTime? Date { get; set; }
            public string Title { get; set; }
    }
}
