namespace Sciences.API.Entities
{
    public class Science
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public List<Topic> Topics { get; set; }
        public Topic Topic { get; set; }

    }
}
