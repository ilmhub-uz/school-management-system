using MassTransit;
using SchoolManagement.Services.Identity.Entities;

namespace SchoolManagement.Services.Identity.Producers;

public class UserProducer : IUserProducer
{
	private readonly IBus _bus;

	public UserProducer(IBus bus)
	{
		_bus = bus;
	}

	public async Task PublishUser(User user)
	{
		await _bus.Publish<User>(user);
	}
}