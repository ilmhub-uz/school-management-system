namespace Student.API.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string PhoneNumber { get; set; }
    public string Username { get; set; }
    public string PhotoUrl { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
    public Status Status { get; set; }
}
