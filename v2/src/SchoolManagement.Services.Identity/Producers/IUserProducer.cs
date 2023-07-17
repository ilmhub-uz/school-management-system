using SchoolManagement.Services.Identity.Entities;

namespace SchoolManagement.Services.Identity.Producers;

public interface IUserProducer
{
	Task PublishUser(User  user);
}