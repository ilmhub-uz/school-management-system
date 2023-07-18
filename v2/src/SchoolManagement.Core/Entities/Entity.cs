namespace SchoolManagement.Core.Entities;

public class Entity<T> where T : struct
{
	public T Id { get; set; }
}

public class Entity : Entity<Guid>
{

}

public interface IAuditable
{
	public DateTime CreatedAt { get; set; }
	public DateTime? UpdatedAt { get; set; }
}