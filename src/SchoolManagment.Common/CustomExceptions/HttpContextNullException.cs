using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Common.CustomExceptions;

public class HttpContextNullException : Exception
{
    public HttpContextNullException(HttpContext? context)
        : base($"HttpContext is null:  {context}")
    { }
}