namespace SchoolManagement.StudentAPI.Options;

public class SwaggerEndPoint
{
	public const string ConfigurationSectionName = "SwaggerEndPoints";

	public string? Name { get; set; }
    public string? Version { get; set; }
    public string? Url { get; set; }
}