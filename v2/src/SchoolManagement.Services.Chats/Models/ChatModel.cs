using SchoolManagement.Core.Entities;
using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Models
{
    public class ChatModel:Entity<ulong>
    {
        public string? Identifier { get; set; }
        public string? Name { get; set; }
        public ChatType ChatType { get; set; }
        public virtual ICollection<MessageModel>? Messages { get; set; }
        public virtual ICollection<UserChat>? UserChats { get; set; }
    }
}
