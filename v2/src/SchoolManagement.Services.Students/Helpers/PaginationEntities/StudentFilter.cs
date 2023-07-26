namespace SchoolManagement.Services.Students.Helpers.PaginationEntities;

public class StudentFilter : PaginationParams
{
    public string? UsernameText { get; set; }
    public DateTime? FromDateTime { get; set; }
    public DateTime? ToDateTime { get; set; }
}