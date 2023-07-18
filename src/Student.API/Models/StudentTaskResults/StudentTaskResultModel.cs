namespace Student.API.Models.StudentTaskResults
{
	public class StudentTaskResultModel
	{
		public Guid TaskId { get; set; }
		public Guid StudentId { get; set; }
		public DateTime? UpdateAt { get; set; }
		public required string Content { get; set; }
	}
}
