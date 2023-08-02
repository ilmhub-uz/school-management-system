﻿using SchoolManagement.Core.Entities;

namespace SchoolManagement.Services.Chats.Entities;

public class User : Entity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string UserName { get; set; }
    public string? PhotoUrl { get; set; }
    public virtual ICollection<Message>? Messages { get; set; }
    public virtual ICollection<UserChat>? UserChats { get; set; }

    public User Copy() => new User()
    {
	    Id = Id,
	    FirstName = FirstName,
	    LastName = LastName,
	    MiddleName = MiddleName,
        UserName = UserName
    };
}