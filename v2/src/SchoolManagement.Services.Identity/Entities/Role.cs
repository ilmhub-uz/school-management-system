using SchoolManagement.Core.Entities;

namespace SchoolManagement.Services.Identity.Entities;

public class Role : Entity
{
	public required string Name { get; set; }
}