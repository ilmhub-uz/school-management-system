﻿namespace Chat.Api.Models.MessageModels;

public class CreateMessageModel
{
    public Guid UserId { get; set; }
    public int ChatId { get; set; }
    public string Content { get; set; }
}
