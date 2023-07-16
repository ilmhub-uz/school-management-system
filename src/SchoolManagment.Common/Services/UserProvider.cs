using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Common.CustomExceptions;
using SchoolManagement.Common.Interfaces;

namespace SchoolManagement.Common.Services;

public class UserProvider : IUserProvider
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserProvider(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    private HttpContext? Context => _contextAccessor.HttpContext;

    public Guid GetUserIdAsync()
    {
        if (Context is null)
            throw new HttpContextNullException(Context);

        var userIdString = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userIdString is null) 
            throw new UserIdIsNullException();

        if (!Guid.TryParse(userIdString, out Guid userId))
            throw new CouldNotParseStringToGuidException(userIdString);

        return userId;
    }

    public string GetUsernameAsync()
    {
        if (Context is null)
            throw new HttpContextNullException(Context);

        var userName = Context.User.FindFirstValue(ClaimTypes.Name);

        return userName ?? throw new UserIdIsNullException();
    }
}