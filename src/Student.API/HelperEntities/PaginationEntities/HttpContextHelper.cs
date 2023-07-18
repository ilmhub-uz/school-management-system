namespace Student.API.HelperEntities.PaginationEntities;

public class HttpContextHelper
{
    public static HttpContext? CurrentContext;

    public HttpContextHelper(IHttpContextAccessor accessor)
    {
        CurrentContext = accessor.HttpContext;
    }

    public void AddResponseHeader(string key, string value)
    {
        if (CurrentContext?.Response.Headers.Keys.Contains(key) == true)
            CurrentContext.Response.Headers.Remove(key);

        CurrentContext?.Response.Headers.Add("Access-Control-Expose-Headers", key);
        CurrentContext?.Response.Headers.Add(key, value);
    }
}