﻿using System.ComponentModel.DataAnnotations;

namespace Identity.Api.Models;

public class CreateUserModel
{
    public required string Password { get; set; }
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
    public required string UserName { get; set; }
}