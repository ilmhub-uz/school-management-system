using SchoolManagement.Core.Entities;
using SchoolManagement.Services.Chats.Entities;

namespace SchoolManagement.Services.Chats.Models
{
    public class CreateChatModel
    {
        public string? Identifier { get; set; }
        public string? Name { get; set; }
        public ChatType ChatType { get; set; }
        
    }
}
