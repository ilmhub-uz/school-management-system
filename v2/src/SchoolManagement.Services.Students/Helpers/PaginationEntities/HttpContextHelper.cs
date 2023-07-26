namespace SchoolManagement.Services.Students.Helpers.PaginationEntities;
  
public class HttpContextHelper
{
    public HttpContext? CurrentContext;

    public HttpContextHelper(IHttpContextAccessor accessor)
    {
        CurrentContext = accessor.HttpContext;
    }

    public void AddResponseHeader(string key, string value)
    {
        if (CurrentContext is not null)
        {
            if(CurrentContext.Response.Headers.Keys.Contains(key))
                CurrentContext.Response.Headers.Add(key, value);

            CurrentContext.Response.Headers.Add("Access-Control-Expose-Headers", key);
            CurrentContext.Response.Headers.Add(key, value);
        }
    }
}