namespace Sciences.API.Entities
{
    public class Topic
    {
        public Guid Id { get; set; }
        public required string Theme_Name { get; set; }
        public DateTime Day { get; set; }
        public List<ScienceTask> Tasks { get; set; }
        public ScienceTask Task { get; set; }
    }
}
