using SchoolManagement.Core.Entities;
using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Models
{
    public class UserModel:Entity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public required string UserName { get; set; }
        public string? PhotoUrl { get; set; }
        public virtual ICollection<MessageModel>? Messages { get; set; }
        public virtual ICollection<ChatModel>? Chats { get; set; }
    }
}
