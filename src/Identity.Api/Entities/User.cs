﻿namespace Identity.Api.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public Status Status { get; set; }
    public List<UserRole>? UserRole { get; set; }
}
