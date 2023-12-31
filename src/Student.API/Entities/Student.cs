﻿namespace Student.API.Entities;

public class Student
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Username { get; set; }
    public string? PhotoUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public Status Status { get; set; }
    public List<StudentScience>? StudentSciences { get; set; }
    public List<StudentTaskResult>? TasksResults { get; set; }

}
