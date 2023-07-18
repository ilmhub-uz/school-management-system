namespace Student.API.Models.StudentTaskResults
{
	public class UpdateStudentTaskResultModel
	{
		public Guid TaskId { get; set; }
		public Guid StudentID { get; set; }
		public required DateTime CreateDate { get; set; }
		public required string Content { get; set; }
	}
}
