namespace Student.API.Models.StudentTaskResults
{
	public class AddStudentTaskResultModel
	{
		public Guid TaskId { get; set; }
		public Guid StudentId { get; set; }
		public required string Context { get; set; }
	}
}
